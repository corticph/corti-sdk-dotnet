namespace Corti;

/// <summary>
/// Provides the value for the Authorization header (e.g. "Bearer ..."). Used by CortiClient to support both client_credentials (refresh) and static access token.
/// </summary>
public interface IAuthTokenProvider
{
    Task<string> GetAccessTokenAsync();
}
