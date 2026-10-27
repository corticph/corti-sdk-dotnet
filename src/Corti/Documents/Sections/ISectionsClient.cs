using Corti;

namespace Corti.Documents;

public partial interface ISectionsClient
{
    public Corti.Documents.Sections.IVersionsClient Versions { get; }

    /// <summary>
    /// Returns a list of sections and their metadata. Fetch a sectionId to get the full generation content.
    /// Use query parameters to filter by language, region, specialty, label, publish status, or source.
    /// </summary>
    WithRawResponseTask<IEnumerable<GuidedSectionListItem>> ListAsync(
        GuidedSectionsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new section with an initial version. When `publish` is true (default),
    /// the response includes the published version with full inheritance resolution applied
    /// (section inheritance chain walked to fill missing fields).
    /// </summary>
    WithRawResponseTask<GuidedSection> CreateAsync(
        GuidedSectionsCreateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the section with its published version fully resolved (inheritance chain walked
    /// to fill missing fields). To see raw authored values without inheritance, use
    /// GET /documents/sections/{sectionID}/versions/{versionID}.
    /// </summary>
    WithRawResponseTask<GuidedSection> GetAsync(
        string sectionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a section and its versions. Returns 409 if other sections inherit from this section.
    /// </summary>
    WithRawResponseTask DeleteAsync(
        string sectionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates the section's metadata fields (name, description, languages, regions, specialties, labels).
    /// Generation content (instructions, output schema) is managed through versions and cannot be updated here.
    /// </summary>
    WithRawResponseTask<GuidedSection> UpdateAsync(
        string sectionId,
        GuidedSectionsUpdateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the templates and sections that a change to this section can affect.
    ///
    /// The `templates` group lists templates whose published version links this section or a
    /// descendant section. It also lists templates that inherit their section list from a parent
    /// template that links the section. The `sections` group lists the descendant sections that
    /// inherit from this section.
    ///
    /// Counts respect the caller's visibility, so the same section can return different
    /// counts for different callers.
    ///
    /// A template appears once. When a template reaches the section through more than one
    /// path, the response keeps the strongest path. The order is `direct`, then
    /// `inheritedSection`, then `inheritedTemplate`.
    ///
    /// Each `items` array holds at most 50 entries. When the 50-entry display cap or the
    /// inheritance depth cap removes entries, `truncated` is true.
    ///
    /// Returns 404 when the caller cannot see the section.
    /// </summary>
    WithRawResponseTask<GuidedSectionImpactResponse> ImpactAsync(
        string sectionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
