using Corti;

namespace Corti.Documents;

public partial interface ISectionsClient
{
    public Corti.Documents.Sections.IVersionsClient Versions { get; }
    WithRawResponseTask<IEnumerable<Section>> ListAsync(
        ListSectionsRequest request,
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

    /// <summary>
    /// Delete section
    /// </summary>
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
