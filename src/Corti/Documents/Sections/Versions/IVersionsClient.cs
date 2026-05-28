using Corti;

namespace Corti.Documents.Sections;

public partial interface IVersionsClient
{
    WithRawResponseTask<IEnumerable<GuidedSectionVersion>> ListAsync(
        string sectionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<GuidedSectionVersion> CreateAsync(
        string sectionId,
        GuidedSectionsCreateVersionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

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
