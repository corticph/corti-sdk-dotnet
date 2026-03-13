namespace Corti.Core;

/// <summary>
/// Custom: Bearer token provider. Supports three refresh strategies (in priority order):
/// 1. <c>refreshAccessToken</c> delegate — user-provided callback, always takes priority.
/// 2. Built-in SDK refresh grant — uses <c>clientId</c> + <c>refreshToken</c> via <see cref="CustomAuthClient"/>.
/// 3. Static — returns the initial access token until it has no expiry set.
/// Created by CortiClient for <see cref="CortiClientAuth.Bearer"/> (with refresh fields) and <see cref="CortiClientAuth.BearerCustomRefresh"/>.
/// </summary>
public sealed class BearerWithRefreshTokenProvider : IAuthTokenProvider
{
    private const double BufferInMinutes = 2;

    private readonly CustomAuthClient _client;
    private readonly string? _clientId;
    // Custom: user-provided refresh delegate; takes priority over built-in SDK refresh path.
    private readonly Func<string?, CancellationToken, Task<CustomRefreshResult>>? _refreshAccessToken;

    private string? _accessToken;
    private DateTime? _expiresAt;
    private string? _refreshToken;
    private DateTime? _refreshExpiresAt;

    public BearerWithRefreshTokenProvider(
        string? clientId,
        string? accessToken,
        string? refreshToken,
        int? expiresIn,
        int? refreshExpiresIn,
        Func<string?, CancellationToken, Task<CustomRefreshResult>>? refreshAccessToken,
        CustomAuthClient client
    )
    {
        _clientId = clientId;
        _accessToken = accessToken;
        _refreshToken = refreshToken;
        _refreshAccessToken = refreshAccessToken;
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
        var isExpiredOrAbsent = _accessToken == null || (_expiresAt.HasValue && DateTime.UtcNow >= _expiresAt.Value);

        // Priority 1: user-provided refresh delegate — called when token is absent or expired.
        if (_refreshAccessToken != null && isExpiredOrAbsent)
        {
            var result = await _refreshAccessToken(_refreshToken, CancellationToken.None).ConfigureAwait(false);
            _accessToken = result.AccessToken;
            _expiresAt = result.ExpiresIn.HasValue
                ? DateTime.UtcNow.AddSeconds(result.ExpiresIn.Value).AddMinutes(-BufferInMinutes)
                : (DateTime?)null;
            if (result.RefreshToken != null)
            {
                _refreshToken = result.RefreshToken;
                _refreshExpiresAt = result.RefreshExpiresIn.HasValue
                    ? DateTime.UtcNow.AddSeconds(result.RefreshExpiresIn.Value).AddMinutes(-BufferInMinutes)
                    : (DateTime?)null;
            }
            return $"Bearer {_accessToken}";
        }

        // Priority 2: built-in SDK refresh grant — requires clientId + a valid stored refresh token.
        if (isExpiredOrAbsent && _clientId != null && _refreshToken != null && _refreshExpiresAt.HasValue && DateTime.UtcNow < _refreshExpiresAt.Value)
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

        return $"Bearer {_accessToken}";
    }
}
