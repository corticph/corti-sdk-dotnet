namespace Corti;

public abstract record CortiClientAuth
{
    /// <summary>Client credentials: clientId + clientSecret (OAuth client_credentials flow).</summary>
    public sealed record ClientCredentials(string ClientId, string ClientSecret) : CortiClientAuth;

    /// <summary>Pre-obtained access token (no refresh). Aligned with TS auth.accessToken.</summary>
    public sealed record Bearer(string AccessToken) : CortiClientAuth;

    /// <summary>ROPC (resource owner password credentials): clientId + username + password. Same pattern as ClientCredentials (no scope when used with CortiClient); use GetTokenAsync(RopcTokenRequest) with <see cref="RopcTokenRequestWithScopes"/> for optional scopes.</summary>
    public sealed record Ropc(string ClientId, string Username, string Password) : CortiClientAuth;
}
