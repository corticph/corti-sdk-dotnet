namespace Corti;

public partial interface IAlphaDocumentsClient
{
    /// <summary>
    /// Generates a structured document using one of four template-supply paths: a stored template reference (optionally with runtime overrides), an ad-hoc assembly of stored sections, or a fully inline dynamic template. Exactly one of `templateRef`, `assemblyTemplate`, or `dynamicTemplate` must be provided.
    ///
    /// With the exception of the plain `templateRef` path (no overrides), every call persists a new auto-generated template aggregate that snapshots the resolved content. The snapshot is drift-proof: subsequent edits to base templates or sections do not affect previously generated documents.
    /// </summary>
    WithRawResponseTask<GuidedDocumentResponse> GenerateAsync(
        GuidedDocumentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
