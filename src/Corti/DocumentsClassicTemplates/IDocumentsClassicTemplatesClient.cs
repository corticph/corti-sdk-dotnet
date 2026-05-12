namespace Corti;

public partial interface IDocumentsClassicTemplatesClient
{
    /// <summary>
    /// Retrieves a list of template sections with optional filters for organization and language.
    /// </summary>
    WithRawResponseTask<TemplatesSectionListResponse> TemplatesSectionListAsync(
        TemplatesSectionListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a list of templates with optional filters for organization, language, and status.
    /// </summary>
    WithRawResponseTask<TemplatesListResponse> TemplatesListAsync(
        TemplatesListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves template by key.
    /// </summary>
    WithRawResponseTask<TemplatesItem> TemplatesGetAsync(
        string key,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
