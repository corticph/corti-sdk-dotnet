namespace Corti;

public partial interface IAuthClient
{
    /// <summary>
    /// Exchange credentials for a short-lived access token. Supports grant_type client_credentials (server-to-server)
    /// or authorization_code (after user redirect). Use the returned access_token in the Authorization header when calling the Corti API.
    /// </summary>
    WithRawResponseTask<AuthTokenResponse> TokenAsync(
        string tenantName,
        AuthTokenRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
