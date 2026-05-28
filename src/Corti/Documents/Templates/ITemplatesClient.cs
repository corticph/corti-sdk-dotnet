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

    /// <summary>
    /// Creates a new template with an initial version. When `publish` is true (default),
    /// the response includes the published version with full inheritance resolution applied
    /// (template-level and section-level inheritance walked).
    /// </summary>
    WithRawResponseTask<Template> CreateAsync(
        CreateTemplateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the template with its published version fully resolved (inheritance walked,
    /// sections expanded with their own inheritance applied). To see raw authored
    /// values without inheritance, use GET /documents/templates/{templateID}/versions/{versionID}.
    /// </summary>
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
        UpdateTemplateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
