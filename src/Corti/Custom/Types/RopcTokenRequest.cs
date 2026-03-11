namespace Corti;

/// <summary>
/// ROPC (resource owner password credentials) token request: clientId, username, password.
/// Use <see cref="RopcTokenRequestWithScopes"/> to request optional scopes when calling GetTokenAsync directly.
/// </summary>
public record RopcTokenRequest
{
    public required string ClientId { get; init; }
    public required string Username { get; init; }
    public required string Password { get; init; }
}
