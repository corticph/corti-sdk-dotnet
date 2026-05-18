using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record GenerateDocumentsRequest
{
    /// <summary>
    /// Pass the optional `X-Corti-Retention-Policy: none` header to generate and return the document without saving it to the database. The response will be 200 with `EphemeralDocumentResponse`. Without the header the document is saved and the response is 201 with `CreateDocumentResponse`.
    /// </summary>
    [JsonIgnore]
    public GenerateDocumentsRequestXCortiRetentionPolicy? CortiRetentionPolicy { get; set; }

    [JsonIgnore]
    public required GuidedDocumentRequest Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
