namespace Corti;

/// <summary>
/// Refresh token request: exchange a refresh token for a new access token (refresh_token grant).
/// Use <see cref="OAuthRefreshTokenRequestWithScopes"/> to request optional scopes when calling GetTokenAsync directly.
/// </summary>
public record OAuthRefreshTokenRequest
{
    public required string ClientId { get; init; }
    public required string RefreshToken { get; init; }
    public string? ClientSecret { get; init; }
}
