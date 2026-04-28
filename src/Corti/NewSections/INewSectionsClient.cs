namespace Corti;

public partial interface INewSectionsClient
{
    WithRawResponseTask<IEnumerable<Section>> ListAsync(
        ListNewSectionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<Section> CreateAsync(
        CreateSectionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

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
}
