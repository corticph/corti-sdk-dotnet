using Corti;

namespace Corti.Documents.Sections;

public partial interface IVersionsClient
{
    WithRawResponseTask<IEnumerable<SectionVersion>> ListAsync(
        string sectionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<SectionVersion> CreateAsync(
        string sectionId,
        SectionGeneration request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<SectionVersion> GetAsync(
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
    WithRawResponseTask<StatusResponse> PublishAsync(
        string sectionId,
        string versionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
