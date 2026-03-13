namespace Corti;

/// <summary>
/// Returns a static access token as the Authorization header value (no refresh). Aligned with TS SDK auth.accessToken.
/// </summary>
public sealed class BearerTokenProvider : IAuthTokenProvider
{
    private readonly string _bearerValue;

    public BearerTokenProvider(string accessToken)
    {
        var token = accessToken ?? string.Empty;
        _bearerValue = string.IsNullOrEmpty(token)
            ? string.Empty
            : (token.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase) ? token : "Bearer " + token);
    }

    public Task<string> GetAccessTokenAsync() => Task.FromResult(_bearerValue);
}
