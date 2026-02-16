using OneOf;

namespace CortiApi;

public partial interface IDocumentsClient
{
    /// <summary>
    /// List Documents
    /// </summary>
    WithRawResponseTask<DocumentsListResponse> ListAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint offers different ways to generate a document. Find guides to document generation [here](/textgen/documents-standard).
    /// </summary>
    WithRawResponseTask<DocumentsGetResponse> CreateAsync(
        string id,
        OneOf<DocumentsCreateRequestWithTemplateKey, DocumentsCreateRequestWithTemplate> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Document.
    /// </summary>
    WithRawResponseTask<DocumentsGetResponse> GetAsync(
        string id,
        string documentId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task DeleteAsync(
        string id,
        string documentId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<DocumentsGetResponse> UpdateAsync(
        string id,
        string documentId,
        DocumentsUpdateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
