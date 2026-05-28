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

    /// <summary>
    /// Creates a new section with an initial version. When `publish` is true (default),
    /// the response includes the published version with full inheritance resolution applied
    /// (section inheritance chain walked to fill missing fields).
    /// </summary>
    WithRawResponseTask<Section> CreateAsync(
        CreateSectionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the section with its published version fully resolved (inheritance chain walked
    /// to fill missing fields). To see raw authored values without inheritance, use
    /// GET /documents/sections/{sectionID}/versions/{versionID}.
    /// </summary>
    WithRawResponseTask<Section> GetAsync(
        string sectionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a section and its versions. Returns 409 if other sections inherit from this section.
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
