namespace Corti;

public partial interface ISectionsClient
{
    WithRawResponseTask<Section> GetAsync(
        string sectionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task DeleteAsync(
        string sectionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<Section> PatchAsync(
        string sectionId,
        UpdateSectionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
