namespace Corti;

public partial interface ITemplatesClient
{
    /// <summary>
    /// Retrieves a list of template sections with optional filters for organization and language.
    ///
    /// &lt;Note&gt;
    /// This endpoint is deprecated in favour of the corresponding GUIDED endpoint. See the [deprecation notice](/release-notes/changelog-upcoming#2026-08-21) for more details and migration guidance.
    /// &lt;/Note&gt;
    /// </summary>
    WithRawResponseTask<TemplatesSectionListResponse> SectionListAsync(
        TemplatesSectionListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a list of templates with optional filters for organization, language, and status.
    ///
    /// &lt;Note&gt;
    /// This endpoint is deprecated in favour of the corresponding GUIDED endpoint. See the [deprecation notice](/release-notes/changelog-upcoming#2026-08-21) for more details and migration guidance.
    /// &lt;/Note&gt;
    /// </summary>
    WithRawResponseTask<TemplatesListResponse> ListAsync(
        TemplatesListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves template by key.
    ///
    /// &lt;Note&gt;
    /// This endpoint is deprecated in favour of the corresponding GUIDED endpoint. See the [deprecation notice](/release-notes/changelog-upcoming#2026-08-21) for more details and migration guidance.
    /// &lt;/Note&gt;
    /// </summary>
    WithRawResponseTask<TemplatesItem> GetAsync(
        string key,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
