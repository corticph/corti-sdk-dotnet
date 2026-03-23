using Corti;

namespace Corti.Core;

/// <summary>
/// Patch: Uses CustomAuthClient (real tenant token endpoint) instead of AuthClient so token refresh hits the real OAuth endpoint. Implements IAuthTokenProvider for use in CortiClient. Auto-uses refresh_token grant when a valid refresh token is stored; falls back to client_credentials.
/// </summary>
public partial class OAuthTokenProvider : IAuthTokenProvider
{
    private const double BufferInMinutes = 2;

    private readonly CustomAuthClient _client;

    private string? _accessToken;

    private DateTime? _expiresAt;

    private string _clientId;

    private string _clientSecret;

    // Patch: refresh token state — stored after initial grant, used to avoid re-authenticating from scratch.
    private string? _refreshToken;

    private DateTime? _refreshExpiresAt;

    public OAuthTokenProvider(string clientId, string clientSecret, CustomAuthClient client)
    {
        _clientId = clientId;
        _clientSecret = clientSecret;
        _client = client;
    }

    public async Task<string> GetAccessTokenAsync()
    {
        if (_accessToken == null || DateTime.UtcNow >= _expiresAt)
        {
            AuthTokenResponse tokenResponse;
            // Patch: prefer refresh_token grant when a valid refresh token is available.
            if (_refreshToken != null && _refreshExpiresAt.HasValue && DateTime.UtcNow < _refreshExpiresAt.Value)
                tokenResponse = await _client
                    .GetTokenAsync(new OAuthRefreshTokenRequest
                    {
                        ClientId = _clientId,
                        RefreshToken = _refreshToken,
                        ClientSecret = _clientSecret,
                    })
                    .ConfigureAwait(false);
            else
                tokenResponse = await _client
                    .GetTokenAsync(new OAuthTokenRequest { ClientId = _clientId, ClientSecret = _clientSecret })
                    .ConfigureAwait(false);

            _accessToken = tokenResponse.AccessToken;
            _expiresAt = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn).AddMinutes(-BufferInMinutes);
            // Patch: store refresh token from response for subsequent refreshes.
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
