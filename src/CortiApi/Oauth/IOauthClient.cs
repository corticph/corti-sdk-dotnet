namespace CortiApi;

public partial interface IOauthClient
{
    /// <summary>
    /// Minimal endpoint for Fern OAuth; implementation should call the real token endpoint.
    /// </summary>
    WithRawResponseTask<GetTokenOauthResponse> GetTokenAsync(
        GetTokenOauthRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
