using Corti;

namespace Corti.Documents;

public partial interface ISectionsClient
{
    public Corti.Documents.Sections.IVersionsClient Versions { get; }
    WithRawResponseTask<IEnumerable<GuidedSection>> ListAsync(
        ListSectionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<GuidedSection> CreateAsync(
        GuidedSectionsCreateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<GuidedSection> GetAsync(
        string sectionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a section and its versions. Returns 409 if other sections inherit from this section.
    /// </summary>
    Task DeleteAsync(
        string sectionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<GuidedSection> UpdateAsync(
        string sectionId,
        GuidedSectionsUpdateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
