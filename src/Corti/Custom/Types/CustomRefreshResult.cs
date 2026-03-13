namespace Corti;

/// <summary>
/// Custom: Return value for <see cref="CortiClientAuth.Bearer.RefreshAccessToken"/> and <see cref="CortiClientAuth.BearerCustomRefresh.RefreshAccessToken"/> delegates. Matches <see cref="AuthTokenResponse"/> fields so callers can map directly from a GetTokenAsync result.
/// </summary>
public record CustomRefreshResult
{
    public required string AccessToken { get; init; }
    public int? ExpiresIn { get; init; }
    public string? TokenType { get; init; }
    public int? RefreshExpiresIn { get; init; }
    public string? RefreshToken { get; init; }
    public string? IdToken { get; init; }
    public int? NotBeforePolicy { get; init; }
    public string? Scope { get; init; }
    public string? SessionState { get; init; }
}
