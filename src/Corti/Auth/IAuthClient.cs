namespace Corti;

public partial interface IAuthClient
{
    /// <summary>
    /// Exchange client_id and client_secret for a short-lived access token (OAuth 2.0 client credentials).
    /// Use the returned access_token in the Authorization header when calling the Corti API.
    /// </summary>
    WithRawResponseTask<AuthTokenResponse> TokenAsync(
        AuthTokenRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
