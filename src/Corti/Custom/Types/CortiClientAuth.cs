namespace Corti;

public abstract record CortiClientAuth
{
    /// <summary>Client credentials: clientId + clientSecret (OAuth client_credentials flow).</summary>
    public sealed record ClientCredentials(string ClientId, string ClientSecret) : CortiClientAuth;

    /// <summary>Pre-obtained access token. If <see cref="RefreshToken"/> and <see cref="ClientId"/> are also provided, the token will be refreshed automatically when it expires.</summary>
    public sealed record Bearer(
        string AccessToken,
        string? ClientId = null,
        string? RefreshToken = null,
        int? ExpiresIn = null,
        int? RefreshExpiresIn = null
    ) : CortiClientAuth;

    /// <summary>ROPC (resource owner password credentials): clientId + username + password. Same pattern as ClientCredentials (no scope when used with CortiClient); use GetTokenAsync(OAuthRopcTokenRequest) with <see cref="OAuthRopcTokenRequestWithScopes"/> for optional scopes.</summary>
    public sealed record Ropc(string ClientId, string Username, string Password) : CortiClientAuth;
}
