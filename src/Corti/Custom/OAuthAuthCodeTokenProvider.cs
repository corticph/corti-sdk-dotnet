using Corti;

namespace Corti.Core;

/// <summary>
/// Authorization code token provider. Exchanges the one-time code for an access token on first use
/// (authorization_code grant). Subsequent renewals use the stored refresh token (refresh_token grant
/// with ClientSecret). If the refresh token is absent or expired, throws — the code flow cannot be
/// re-initiated automatically.
/// </summary>
public sealed class OAuthAuthCodeTokenProvider : IAuthTokenProvider
{
    private const double BufferInMinutes = 2;

    private readonly CustomAuthClient _client;
    private readonly string _clientId;
    private readonly string _clientSecret;
    private readonly string _code;
    private readonly string _redirectUri;

    private string? _accessToken;
    private DateTime? _expiresAt;
    private string? _refreshToken;
    private DateTime? _refreshExpiresAt;

    public OAuthAuthCodeTokenProvider(
        string clientId,
        string clientSecret,
        string code,
        string redirectUri,
        CustomAuthClient client
    )
    {
        _clientId = clientId;
        _clientSecret = clientSecret;
        _code = code;
        _redirectUri = redirectUri;
        _client = client;
    }

    public async Task<string> GetAccessTokenAsync()
    {
        if (_accessToken != null && _expiresAt.HasValue && DateTime.UtcNow < _expiresAt.Value)
            return $"Bearer {_accessToken}";

        AuthTokenResponse tokenResponse;

        if (_refreshToken != null && _refreshExpiresAt.HasValue && DateTime.UtcNow < _refreshExpiresAt.Value)
        {
            // Renew via refresh_token grant; ClientSecret is required for authorization code clients.
            tokenResponse = await _client
                .GetTokenAsync(new OAuthRefreshTokenRequest
                {
                    ClientId = _clientId,
                    RefreshToken = _refreshToken,
                    ClientSecret = _clientSecret,
                })
                .ConfigureAwait(false);
        }
        else if (_accessToken == null)
        {
            // First use: exchange the authorization code.
            tokenResponse = await _client
                .GetTokenAsync(new OAuthAuthCodeTokenRequest
                {
                    ClientId = _clientId,
                    ClientSecret = _clientSecret,
                    Code = _code,
                    RedirectUri = _redirectUri,
                })
                .ConfigureAwait(false);
        }
        else
        {
            throw new InvalidOperationException(
                "Authorization code token has expired and no valid refresh token is available. " +
                "Re-initiate the authorization code flow to obtain a new token.");
        }

        _accessToken = tokenResponse.AccessToken;
        _expiresAt = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn).AddMinutes(-BufferInMinutes);

        if (tokenResponse.RefreshToken != null)
        {
            _refreshToken = tokenResponse.RefreshToken;
            _refreshExpiresAt = tokenResponse.RefreshExpiresIn.HasValue
                ? DateTime.UtcNow.AddSeconds(tokenResponse.RefreshExpiresIn.Value).AddMinutes(-BufferInMinutes)
                : (DateTime?)null;
        }

        return $"Bearer {_accessToken}";
    }
}
