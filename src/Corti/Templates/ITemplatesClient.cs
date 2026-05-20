namespace Corti;

public partial interface ITemplatesClient
{
    /// <summary>
    /// Retrieves a list of template sections with optional filters for organization and language.
    /// </summary>
    WithRawResponseTask<TemplatesSectionListResponse> SectionListAsync(
        SectionListTemplatesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a list of templates with optional filters for organization, language, and status.
    /// </summary>
    WithRawResponseTask<TemplatesListResponse> ListAsync(
        ListTemplatesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves template by key.
    /// </summary>
    WithRawResponseTask<TemplatesItem> GetAsync(
        string key,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
