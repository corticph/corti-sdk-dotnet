namespace Corti;

/// <summary>
/// Patch: Extends OAuthTokenRequest with optional Scopes for CustomAuthClient.GetTokenAsync (openid is always included, then these, deduplicated).
/// </summary>
public record OAuthTokenRequestWithScopes : OAuthTokenRequest
{
    /// <summary>Optional scopes; "openid" is always included and merged with these, deduplicated.</summary>
    public IEnumerable<string>? Scopes { get; init; }
}
