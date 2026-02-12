namespace CortiApi;

public partial interface IAuthClient
{
    /// <summary>
    /// Obtain an OAuth2 access token using client credentials
    /// </summary>
    WithRawResponseTask<GetTokenResponse> GetTokenAsync(
        GetTokenAuthRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
