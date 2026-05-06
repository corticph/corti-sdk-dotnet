namespace Corti;

public partial interface IAlphaSectionVersionsClient
{
    WithRawResponseTask<SectionVersion> GetAsync(
        string sectionId,
        string versionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

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

    Task ListAsync(
        string sectionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task CreateAsync(
        string sectionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
