using Corti.Documents;

namespace Corti;

public partial interface IDocumentsClient
{
    public IClassicClient Classic { get; }
    public Corti.Documents.ITemplatesClient Templates { get; }
    public ISectionsClient Sections { get; }

    /// <summary>
    /// Guided Documents list (`GET /documents/`). For classic interaction-scoped documents, use `client.documents.classic.list`.
    ///
    /// Returns a list of previously generated documents.
    /// Use query parameters to filter by template, interaction, or label.
    /// </summary>
    WithRawResponseTask<IEnumerable<GuidedDocument>> ListAsync(
        GuidedDocumentsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Generates a structured document using one of three template-supply paths: a stored template reference (optionally with runtime overrides), an ad-hoc assembly of stored sections, or a fully inline dynamic template. Exactly one of `templateRef`, `assemblyTemplate`, or `dynamicTemplate` must be provided.
    /// Context can combine different types or reference an interactionId to automatically fetch existing context to pass to the LLM. Note that discarded facts are not passed to the LLM.
    /// With the exception of the plain `templateRef` path (no overrides), every call creates a new auto-generated template aggregate that snapshots the resolved prompts as a drift-proof receipt, persisted for 30 days.
    /// </summary>
    WithRawResponseTask<GuidedDocumentsCreateEphemeralResponse> GenerateAsync(
        GuidedDocumentsGenerateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Guided Documents get (`GET /documents/{documentID}`). For classic interaction-scoped documents, use `client.documents.classic.get`.
    ///
    /// Returns a previously generated document by ID, including its rendered string output
    /// and structured object.
    /// </summary>
    WithRawResponseTask<GuidedDocument> GetAsync(
        string documentId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Guided Documents delete (`DELETE /documents/{documentID}`). For classic interaction-scoped documents, use `client.documents.classic.delete`.
    ///
    /// Deletes the document. This cannot be undone.
    /// </summary>
    WithRawResponseTask DeleteAsync(
        string documentId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Guided Documents update (`PATCH /documents/{documentID}`). For classic interaction-scoped documents, use `client.documents.classic.update`.
    ///
    /// Updates the document's `name`, `labels`, or rendered output (`stringDocument` / `structuredDocument`).
    /// Use this to persist edits made to a previously generated document.
    /// </summary>
    WithRawResponseTask<GuidedDocument> UpdateAsync(
        string documentId,
        GuidedDocumentsUpdateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
