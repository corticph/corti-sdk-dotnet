namespace Corti;

public partial interface ILanguagesClient
{
    /// <summary>
    /// Returns a list of available languages with their enabled endpoints details.
    /// </summary>
    WithRawResponseTask<LanguagesListResponse> ListAsync(
        LanguagesListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
