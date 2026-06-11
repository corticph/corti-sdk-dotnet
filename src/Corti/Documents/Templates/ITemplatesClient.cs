using Corti;

namespace Corti.Documents;

public partial interface ITemplatesClient
{
    public Corti.Documents.Templates.IVersionsClient Versions { get; }

    /// <summary>
    /// Returns a list of templates and their metadata. Fetch a specific templateId to get the expanded sections.
    /// Use query parameters to filter by language, region, specialty, label, publish status, or source.
    /// </summary>
    WithRawResponseTask<IEnumerable<GuidedTemplate>> ListAsync(
        GuidedTemplatesListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new template with an initial version. When `publish` is true (default),
    /// the response includes the published version with full inheritance resolution applied
    /// (template-level and section-level inheritance walked).
    /// </summary>
    WithRawResponseTask<GuidedTemplate> CreateAsync(
        GuidedTemplatesCreateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the template with its published version fully resolved (inheritance walked,
    /// sections expanded with their own inheritance applied). To see raw authored
    /// values without inheritance, use GET /documents/templates/{templateID}/versions/{versionID}.
    /// </summary>
    WithRawResponseTask<GuidedTemplate> GetAsync(
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

    /// <summary>
    /// Updates the template's metadata fields (name, description, languages, regions, specialties, labels).
    /// Generation content (template instructions, section composition) is managed through versions
    /// and cannot be updated here.
    /// </summary>
    WithRawResponseTask<GuidedTemplate> UpdateAsync(
        string templateId,
        GuidedTemplatesUpdateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
