namespace Corti;

public partial interface IAlphaTemplatesClient
{
    WithRawResponseTask<IEnumerable<Template>> ListAsync(
        ListAlphaTemplatesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<Template> CreateAsync(
        CreateTemplateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

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
}
