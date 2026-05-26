using Corti;

namespace Corti.Documents;

public partial interface ITemplatesClient
{
    public Corti.Documents.Templates.IVersionsClient Versions { get; }
    WithRawResponseTask<IEnumerable<Template>> ListAsync(
        ListTemplatesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<Template> CreateAsync(
        GuidedTemplatesCreateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<Template> GetAsync(
        string templateId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a template and its versions. Returns 409 if other templates or sections inherit from this template.
    /// </summary>
    Task DeleteAsync(
        string templateId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<Template> UpdateAsync(
        string templateId,
        GuidedTemplatesUpdateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
