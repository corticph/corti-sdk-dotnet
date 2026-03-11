namespace Corti;

public record OAuthTokenRequestWithScopes : OAuthTokenRequest
{
    /// <summary>Optional scopes; "openid" is always included and merged with these, deduplicated.</summary>
    public IEnumerable<string>? Scopes { get; init; }
}
