namespace Corti;

/// <summary>ROPC token request with optional scopes; "openid" is always included and merged with these, deduplicated.</summary>
public record OAuthRopcTokenRequestWithScopes : OAuthRopcTokenRequest
{
    public IEnumerable<string>? Scopes { get; init; }
}
