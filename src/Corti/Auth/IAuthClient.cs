namespace Corti;

public partial interface IAuthClient
{
    WithRawResponseTask<AuthTokenResponse> GetTokenAsync(
        OAuthTokenRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Exchange credentials for a short-lived access token. Supports grant_type client_credentials (server-to-server),
    /// authorization_code (with client_secret), authorization_code with PKCE (code_verifier), password (ROPC), or refresh_token. Use the returned access_token in the Authorization header when calling the Corti API.
    /// </summary>
    WithRawResponseTask<AuthTokenResponse> TokenAsync(
        string tenantName,
        AuthTokenRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
