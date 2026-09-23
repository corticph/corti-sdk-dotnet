using Corti;

namespace Corti.Documents;

public partial interface IClassicClient
{
    /// <summary>
    /// List Documents
    ///
    /// &lt;Note&gt;
    /// This endpoint is deprecated in favour of the corresponding GUIDED endpoint. See the [deprecation notice](/release-notes/changelog-upcoming#2026-08-21) for more details and migration guidance.
    /// &lt;/Note&gt;
    /// </summary>
    WithRawResponseTask<DocumentsListResponse> ListAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint offers different ways to generate a document. Find guides to document generation [here](/textgen/documents-standard).
    ///
    /// &lt;Note&gt;
    /// This endpoint is deprecated in favour of the corresponding GUIDED endpoint. See the [deprecation notice](/release-notes/changelog-upcoming#2026-08-21) for more details and migration guidance.
    /// &lt;/Note&gt;
    /// </summary>
    WithRawResponseTask<DocumentsGetResponse> CreateAsync(
        string id,
        DocumentsCreateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Document.
    ///
    /// &lt;Note&gt;
    /// This endpoint is deprecated in favour of the corresponding GUIDED endpoint. See the [deprecation notice](/release-notes/changelog-upcoming#2026-08-21) for more details and migration guidance.
    /// &lt;/Note&gt;
    /// </summary>
    WithRawResponseTask<DocumentsGetResponse> GetAsync(
        string id,
        string documentId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// &lt;Note&gt;
    /// This endpoint is deprecated in favour of the corresponding GUIDED endpoint. See the [deprecation notice](/release-notes/changelog-upcoming#2026-08-21) for more details and migration guidance.
    /// &lt;/Note&gt;
    /// </summary>
    WithRawResponseTask DeleteAsync(
        string id,
        string documentId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// &lt;Note&gt;
    /// This endpoint is deprecated in favour of the corresponding GUIDED endpoint. See the [deprecation notice](/release-notes/changelog-upcoming#2026-08-21) for more details and migration guidance.
    /// &lt;/Note&gt;
    /// </summary>
    WithRawResponseTask<DocumentsGetResponse> UpdateAsync(
        string id,
        string documentId,
        DocumentsUpdateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
