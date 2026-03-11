using Corti;

namespace Corti.Core;

/// <summary>
/// ROPC (resource owner password credentials) token provider; uses CustomAuthClient.GetTokenAsync(RopcTokenRequest) for refresh. Same pattern as OAuthTokenProvider (no scopes when used from CortiClient; buffer, expiry).
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
            var request = new RopcTokenRequest
            {
                ClientId = _clientId,
                Username = _username,
                Password = _password,
            };
            var tokenResponse = await _client
                .GetTokenAsync(request)
                .ConfigureAwait(false);
            _accessToken = tokenResponse.AccessToken;
            _expiresAt = DateTime
                .UtcNow.AddSeconds(tokenResponse.ExpiresIn)
                .AddMinutes(-BufferInMinutes);
        }
        return $"Bearer {_accessToken}";
    }
}
