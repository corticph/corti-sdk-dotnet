using Corti;

namespace Corti.Core;

/// <summary>
/// Custom: ROPC (resource owner password credentials) token provider; uses CustomAuthClient.GetTokenAsync(OAuthRopcTokenRequest) for initial auth. Auto-uses refresh_token grant when a valid refresh token is stored; falls back to password grant. Same pattern as OAuthTokenProvider (no scopes when used from CortiClient; buffer, expiry).
/// </summary>
public sealed class OAuthRopcTokenProvider : IAuthTokenProvider
{
    private const double BufferInMinutes = 2;

    private readonly CustomAuthClient _client;
    private readonly string _clientId;
    private readonly string _username;
    private readonly string _password;

    private string? _accessToken;
    private DateTime? _expiresAt;

    // Refresh token state — stored after initial ROPC grant, used to avoid re-authenticating from scratch.
    private string? _refreshToken;
    private DateTime? _refreshExpiresAt;

    public OAuthRopcTokenProvider(
        string clientId,
        string username,
        string password,
        CustomAuthClient client
    )
    {
        _clientId = clientId;
        _username = username;
        _password = password;
        _client = client;
    }

    public async Task<string> GetAccessTokenAsync()
    {
        if (_accessToken == null || DateTime.UtcNow >= _expiresAt)
        {
            AuthTokenResponse tokenResponse;
            // Prefer refresh_token grant when a valid refresh token is available; ClientSecret omitted (not stored for ROPC).
            if (_refreshToken != null && _refreshExpiresAt.HasValue && DateTime.UtcNow < _refreshExpiresAt.Value)
                tokenResponse = await _client
                    .GetTokenAsync(new OAuthRefreshTokenRequest
                    {
                        ClientId = _clientId,
                        RefreshToken = _refreshToken,
                    })
                    .ConfigureAwait(false);
            else
                tokenResponse = await _client
                    .GetTokenAsync(new OAuthRopcTokenRequest
                    {
                        ClientId = _clientId,
                        Username = _username,
                        Password = _password,
                    })
                    .ConfigureAwait(false);

            _accessToken = tokenResponse.AccessToken;
            _expiresAt = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn).AddMinutes(-BufferInMinutes);
            // Store refresh token from response for subsequent refreshes.
            if (tokenResponse.RefreshToken != null)
            {
                _refreshToken = tokenResponse.RefreshToken;
                _refreshExpiresAt = tokenResponse.RefreshExpiresIn.HasValue
                    ? DateTime.UtcNow.AddSeconds(tokenResponse.RefreshExpiresIn.Value).AddMinutes(-BufferInMinutes)
                    : (DateTime?)null;
            }
        }
        return $"Bearer {_accessToken}";
    }
}
