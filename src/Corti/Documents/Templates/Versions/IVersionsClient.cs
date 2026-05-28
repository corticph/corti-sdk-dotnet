using Corti;

namespace Corti.Documents.Templates;

public partial interface IVersionsClient
{
    WithRawResponseTask<IEnumerable<ShallowTemplateVersionResponse>> ListAsync(
        string templateId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new template version. Returns raw authored values without inheritance resolution or section expansion.
    /// </summary>
    WithRawResponseTask<ShallowTemplateVersionResponse> CreateAsync(
        string templateId,
        CreateTemplateVersionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<ShallowTemplateVersionResponse> GetAsync(
        string templateId,
        string versionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// A published version cannot be deleted. When deleting a last remaining version of a template, simply create a new version again if needed.
    /// </summary>
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
