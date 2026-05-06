namespace Corti;

public partial interface IAlphaTemplateVersionsClient
{
    WithRawResponseTask<TemplateVersion> GetAsync(
        string templateId,
        string versionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task DeleteAsync(
        string templateId,
        string versionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sets this version as the published version of the template.
    /// </summary>
    WithRawResponseTask<StatusResponse> PublishAsync(
        string templateId,
        string versionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task ListAsync(
        string templateId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task CreateAsync(
        string templateId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
