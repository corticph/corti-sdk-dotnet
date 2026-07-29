using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti;

[Serializable]
public record GenerateDocumentsRequest
{
    /// <summary>
    /// Identifies a distinct entity within Corti's multi-tenant system. Ensures correct routing and authentication of the request.
    /// </summary>
    [JsonIgnore]
    public required string TenantName { get; set; }

    [JsonIgnore]
    public required GuidedDocumentsGenerateRequest Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
