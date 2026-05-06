namespace Corti;

public partial interface IAlphaTemplateVersionsClient
{
    WithRawResponseTask<IEnumerable<TemplateVersion>> ListAsync(
        string templateId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<TemplateVersion> CreateAsync(
        string templateId,
        CreateTemplateVersionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

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
}
