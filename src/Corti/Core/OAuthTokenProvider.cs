using Corti;

namespace Corti.Core;

/// <summary>
/// Patch: Uses CortiAuth (real tenant token endpoint) instead of AuthClient (fake-token) so token refresh hits the real OAuth endpoint.
/// </summary>
public partial class OAuthTokenProvider
{
    private const double BufferInMinutes = 2;

    private CortiAuth _client;

    private string? _accessToken;

    private DateTime? _expiresAt;

    private string _clientId;

    private string _clientSecret;

    public OAuthTokenProvider(string clientId, string clientSecret, CortiAuth client)
    {
        _clientId = clientId;
        _clientSecret = clientSecret;
        _client = client;
    }

    public async Task<string> GetAccessTokenAsync()
    {
        if (_accessToken == null || DateTime.UtcNow >= _expiresAt)
        {
            var tokenResponse = await _client
                .GetTokenAsync(
                    new OAuthTokenRequest { ClientId = _clientId, ClientSecret = _clientSecret }
                )
                .ConfigureAwait(false);
            _accessToken = tokenResponse.AccessToken;
            _expiresAt = DateTime
                .UtcNow.AddSeconds(tokenResponse.ExpiresIn)
                .AddMinutes(-BufferInMinutes);
        }
        return $"Bearer {_accessToken}";
    }
}
