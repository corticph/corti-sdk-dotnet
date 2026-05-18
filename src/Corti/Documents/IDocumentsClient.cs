using Corti.Documents;

namespace Corti;

public partial interface IDocumentsClient
{
    public Corti.Documents.ITemplatesClient Templates { get; }
    public ISectionsClient Sections { get; }

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
        DocumentsCreateRequest request,
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

    /// <summary>
    /// Generates a structured document using one of three template-supply paths: a stored template reference (optionally with runtime overrides), an ad-hoc assembly of stored sections, or a fully inline dynamic template. Exactly one of `templateRef`, `assemblyTemplate`, or `dynamicTemplate` must be provided.
    ///
    /// With the exception of the plain `templateRef` path (no overrides), every call persists a new auto-generated template aggregate that snapshots the resolved content. The snapshot is drift-proof: subsequent edits to base templates or sections do not affect previously generated documents.
    ///
    /// Pass the `X-Corti-Retention-Policy: none` header to generate and return the document without saving it to the database. The response will be 200 with `EphemeralDocumentResponse`. Without the header the document is saved and the response is 201 with `CreateDocumentResponse`.
    /// </summary>
    WithRawResponseTask<CreateEphemeralDocumentResponse> GenerateAsync(
        GenerateDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
