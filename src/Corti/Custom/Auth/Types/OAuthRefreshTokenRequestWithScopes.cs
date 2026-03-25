namespace Corti;

/// <summary>Refresh token request with optional scopes; "openid" is always included and merged with these, deduplicated.</summary>
public record OAuthRefreshTokenRequestWithScopes : OAuthRefreshTokenRequest
{
    public IEnumerable<string>? Scopes { get; init; }
}
