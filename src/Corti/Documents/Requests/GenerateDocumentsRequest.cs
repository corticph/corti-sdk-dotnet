using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record GenerateDocumentsRequest
{
    /// <summary>
    /// With the optional header `X-Corti-Retention-Policy:none` the API will generate and return the document as expected, but the generated document will not be saved to the database. The response will include the header `X-Corti-Retention-Policy:acknowledged` to confirm that your retention preference was respected. If the header is omitted or set to any other value, the default retention policy will apply, and the document will be stored in the database.
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
