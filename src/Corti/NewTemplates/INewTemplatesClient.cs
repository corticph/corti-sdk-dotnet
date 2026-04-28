namespace Corti;

public partial interface INewTemplatesClient
{
    WithRawResponseTask<Template> UpdateAsync(
        string templateId,
        UpdateTemplateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
