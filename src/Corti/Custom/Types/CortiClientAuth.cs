namespace Corti;

public abstract record CortiClientAuth
{
    /// <summary>Client credentials: clientId + clientSecret (OAuth client_credentials flow).</summary>
    public sealed record ClientCredentials(string ClientId, string ClientSecret) : CortiClientAuth;

    /// <summary>Pre-obtained access token. If <see cref="RefreshAccessToken"/> is provided it is called when the token expires (takes priority over the built-in <see cref="ClientId"/>+<see cref="RefreshToken"/> path). If <see cref="RefreshToken"/> and <see cref="ClientId"/> are provided, the SDK refresh grant is used on expiry.</summary>
    public sealed record Bearer(
        string AccessToken,
        Func<string?, CancellationToken, Task<CustomRefreshResult>>? RefreshAccessToken = null,
        string? ClientId = null,
        string? RefreshToken = null,
        int? ExpiresIn = null,
        int? RefreshExpiresIn = null
    ) : CortiClientBearerAuth;

    /// <summary>Custom: <see cref="RefreshAccessToken"/> is called to obtain (and renew) the access token. <see cref="AccessToken"/>/<see cref="RefreshToken"/> may optionally seed the first call to avoid an immediate refresh round-trip; <see cref="RefreshToken"/> is passed as the argument to <see cref="RefreshAccessToken"/>.</summary>
    public sealed record BearerCustomRefresh(
        Func<string?, CancellationToken, Task<CustomRefreshResult>> RefreshAccessToken,
        string? AccessToken = null,
        int? ExpiresIn = null,
        string? RefreshToken = null,
        int? RefreshExpiresIn = null
    ) : CortiClientBearerAuth;

    /// <summary>ROPC (resource owner password credentials): clientId + username + password. Same pattern as ClientCredentials (no scope when used with CortiClient); use GetTokenAsync(OAuthRopcTokenRequest) with <see cref="OAuthRopcTokenRequestWithScopes"/> for optional scopes.</summary>
    public sealed record Ropc(string ClientId, string Username, string Password) : CortiClientAuth;
}

/// <summary>Narrow base for Bearer and BearerCustomRefresh — the only auth variants whose JWT can be decoded to supply TenantName and Environment automatically. Used by <see cref="CortiClientBearerOptions"/>.</summary>
public abstract record CortiClientBearerAuth : CortiClientAuth;
