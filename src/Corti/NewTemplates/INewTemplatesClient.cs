namespace Corti;

public partial interface INewTemplatesClient
{
    WithRawResponseTask<Template> GetAsync(
        string templateId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task DeleteAsync(
        string templateId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<Template> UpdateAsync(
        string templateId,
        UpdateTemplateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task ListAsync(RequestOptions? options = null, CancellationToken cancellationToken = default);

    Task CreateAsync(RequestOptions? options = null, CancellationToken cancellationToken = default);
}
