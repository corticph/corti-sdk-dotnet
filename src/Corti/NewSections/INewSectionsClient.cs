namespace Corti;

public partial interface INewSectionsClient
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

    WithRawResponseTask<Section> UpdateAsync(
        string sectionId,
        UpdateSectionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task ListAsync(RequestOptions? options = null, CancellationToken cancellationToken = default);

    Task CreateAsync(RequestOptions? options = null, CancellationToken cancellationToken = default);
}
