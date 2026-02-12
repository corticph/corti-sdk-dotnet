namespace CortiApi;

public partial interface IAuthClient
{
    /// <summary>
    /// Obtain an OAuth2 access token. Supports multiple grant types (client_credentials, authorization_code, refresh_token, password).
    /// The path parameter tenantName (realm) identifies the Keycloak realm; use the same value as the Tenant-Name header for API requests.
    /// </summary>
    WithRawResponseTask<GetTokenResponse> GetTokenAsync(
        GetTokenAuthRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
