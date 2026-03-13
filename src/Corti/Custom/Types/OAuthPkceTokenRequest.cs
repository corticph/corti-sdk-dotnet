namespace Corti;

/// <summary>
/// PKCE authorization code token exchange request (no client secret; uses code_verifier).
/// </summary>
public record OAuthPkceTokenRequest
{
    public required string ClientId { get; init; }
    public required string Code { get; init; }
    public required string RedirectUri { get; init; }
    public required string CodeVerifier { get; init; }
}

/// <summary>
/// PKCE token request with optional scopes.
/// </summary>
public record OAuthPkceTokenRequestWithScopes : OAuthPkceTokenRequest
{
    public IEnumerable<string>? Scopes { get; init; }
}
