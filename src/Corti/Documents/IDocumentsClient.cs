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
    /// Context can combine different types or reference an interactionId to automatically fetch existing context to pass to the LLM. Note that discarded facts are not passed to the LLM.
    /// With the exception of the plain `templateRef` path (no overrides), every call creates a new auto-generated template aggregate that snapshots the resolved prompts as a drift-proof receipt, persisted for 30 days.
    /// </summary>
    WithRawResponseTask<CreateEphemeralDocumentResponse> GenerateAsync(
        GuidedDocumentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
