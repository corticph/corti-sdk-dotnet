namespace Corti.Core;

/// <summary>
/// Custom: Bearer token provider that uses a refresh token to automatically renew the access token when it expires. Created by CortiClient when CortiClientAuth.Bearer includes both ClientId and RefreshToken. Falls back to the initial access token if refresh token is expired or unavailable.
/// </summary>
public sealed class BearerWithRefreshTokenProvider : IAuthTokenProvider
{
    private const double BufferInMinutes = 2;

    private readonly CustomAuthClient _client;
    private readonly string _clientId;

    private string _accessToken;
    private DateTime? _expiresAt;
    private string? _refreshToken;
    private DateTime? _refreshExpiresAt;

    public BearerWithRefreshTokenProvider(
        string clientId,
        string accessToken,
        string refreshToken,
        int? expiresIn,
        int? refreshExpiresIn,
        CustomAuthClient client
    )
    {
        _clientId = clientId;
        _accessToken = accessToken;
        _refreshToken = refreshToken;
        _client = client;
        _expiresAt = expiresIn.HasValue
            ? DateTime.UtcNow.AddSeconds(expiresIn.Value).AddMinutes(-BufferInMinutes)
            : (DateTime?)null;
        _refreshExpiresAt = refreshExpiresIn.HasValue
            ? DateTime.UtcNow.AddSeconds(refreshExpiresIn.Value).AddMinutes(-BufferInMinutes)
            : (DateTime?)null;
    }

    public async Task<string> GetAccessTokenAsync()
    {
        if (_expiresAt.HasValue && DateTime.UtcNow >= _expiresAt.Value)
        {
            if (_refreshToken != null && _refreshExpiresAt.HasValue && DateTime.UtcNow < _refreshExpiresAt.Value)
            {
                var tokenResponse = await _client
                    .GetTokenAsync(new OAuthRefreshTokenRequest
                    {
                        ClientId = _clientId,
                        RefreshToken = _refreshToken,
                    })
                    .ConfigureAwait(false);

                _accessToken = tokenResponse.AccessToken;
                _expiresAt = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn).AddMinutes(-BufferInMinutes);
                if (tokenResponse.RefreshToken != null)
                {
                    _refreshToken = tokenResponse.RefreshToken;
                    _refreshExpiresAt = tokenResponse.RefreshExpiresIn.HasValue
                        ? DateTime.UtcNow.AddSeconds(tokenResponse.RefreshExpiresIn.Value).AddMinutes(-BufferInMinutes)
                        : (DateTime?)null;
                }
            }
        }
        return $"Bearer {_accessToken}";
    }
}
