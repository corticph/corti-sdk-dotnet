using Corti;

namespace Corti.Core;

/// <summary>
/// PKCE authorization code token provider. Exchanges the one-time code for an access token on first use
/// (authorization_code grant with code_verifier; no client secret). Subsequent renewals use the stored
/// refresh token (refresh_token grant, no ClientSecret). If the refresh token is absent or expired,
/// throws — the PKCE flow cannot be re-initiated automatically.
/// </summary>
public sealed class OAuthPkceTokenProvider : IAuthTokenProvider
{
    private const double BufferInMinutes = 2;

    private readonly CustomAuthClient _client;
    private readonly string _clientId;
    private readonly string _code;
    private readonly string _redirectUri;
    private readonly string _codeVerifier;

    private string? _accessToken;
    private DateTime? _expiresAt;
    private string? _refreshToken;
    private DateTime? _refreshExpiresAt;

    public OAuthPkceTokenProvider(
        string clientId,
        string code,
        string redirectUri,
        string codeVerifier,
        CustomAuthClient client
    )
    {
        _clientId = clientId;
        _code = code;
        _redirectUri = redirectUri;
        _codeVerifier = codeVerifier;
        _client = client;
    }

    public async Task<string> GetAccessTokenAsync()
    {
        if (_accessToken != null && _expiresAt.HasValue && DateTime.UtcNow < _expiresAt.Value)
            return $"Bearer {_accessToken}";

        AuthTokenResponse tokenResponse;

        if (_refreshToken != null && _refreshExpiresAt.HasValue && DateTime.UtcNow < _refreshExpiresAt.Value)
        {
            // Renew via refresh_token grant; PKCE clients do not use ClientSecret.
            tokenResponse = await _client
                .GetTokenAsync(new OAuthRefreshTokenRequest
                {
                    ClientId = _clientId,
                    RefreshToken = _refreshToken,
                })
                .ConfigureAwait(false);
        }
        else if (_accessToken == null)
        {
            // First use: exchange the authorization code with PKCE code_verifier.
            tokenResponse = await _client
                .GetTokenAsync(new OAuthPkceTokenRequest
                {
                    ClientId = _clientId,
                    Code = _code,
                    RedirectUri = _redirectUri,
                    CodeVerifier = _codeVerifier,
                })
                .ConfigureAwait(false);
        }
        else
        {
            throw new InvalidOperationException(
                "PKCE token has expired and no valid refresh token is available. " +
                "Re-initiate the PKCE authorization flow to obtain a new token.");
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
