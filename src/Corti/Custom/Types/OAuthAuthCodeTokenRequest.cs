namespace Corti;

/// <summary>Authorization code grant request: exchanges a one-time code for an access token.</summary>
public record OAuthAuthCodeTokenRequest
{
    public required string ClientId { get; init; }
    public required string ClientSecret { get; init; }
    public required string Code { get; init; }
    public required string RedirectUri { get; init; }
}

/// <summary>Authorization code grant request with optional additional scopes. "openid" is always included.</summary>
public record OAuthAuthCodeTokenRequestWithScopes : OAuthAuthCodeTokenRequest
{
    public IEnumerable<string>? Scopes { get; init; }
}
