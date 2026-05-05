namespace Corti;

public partial interface INewTemplateVersionsClient
{
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

    Task GetAsync(
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

    Task PublishAsync(
        string templateId,
        string versionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
