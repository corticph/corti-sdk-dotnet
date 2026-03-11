namespace Corti;

public abstract record CortiClientAuth
{
    /// <summary>Client credentials: clientId + clientSecret (OAuth client_credentials flow).</summary>
    public sealed record ClientCredentials(string ClientId, string ClientSecret) : CortiClientAuth;

    /// <summary>Pre-obtained access token (no refresh). Aligned with TS auth.accessToken.</summary>
    public sealed record Bearer(string AccessToken) : CortiClientAuth;
}
