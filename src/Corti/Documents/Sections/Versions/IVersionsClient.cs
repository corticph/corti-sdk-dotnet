using Corti;

namespace Corti.Documents.Sections;

public partial interface IVersionsClient
{
    /// <summary>
    /// Returns raw authored section versions without inheritance resolution. To see resolved content, use GET /sections/{sectionID} instead.
    /// </summary>
    WithRawResponseTask<IEnumerable<GuidedSectionVersion>> ListAsync(
        string sectionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new section version. Returns raw authored values without inheritance resolution.
    /// </summary>
    WithRawResponseTask<GuidedSectionVersion> CreateAsync(
        string sectionId,
        GuidedSectionsCreateVersionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns raw authored section version without inheritance resolution. To see resolved content, use GET /sections/{sectionID} instead.
    /// </summary>
    WithRawResponseTask<GuidedSectionVersion> GetAsync(
        string sectionId,
        string versionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Currently published version cannot be deleted. Last remaining version can be deleted, simply create a new section version again if needed.
    /// </summary>
    Task DeleteAsync(
        string sectionId,
        string versionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sets this version as the published version of the section.
    /// </summary>
    WithRawResponseTask<CommonStatusResponse> PublishAsync(
        string sectionId,
        string versionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
