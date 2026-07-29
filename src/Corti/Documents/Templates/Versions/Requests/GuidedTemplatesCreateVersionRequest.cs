using Corti;
using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti.Documents.Templates;

[Serializable]
public record GuidedTemplatesCreateVersionRequest
{
    /// <summary>
    /// Identifies a distinct entity within Corti's multi-tenant system. Ensures correct routing and authentication of the request.
    /// </summary>
    [JsonIgnore]
    public required string TenantName { get; set; }

    [JsonPropertyName("generation")]
    public required GuidedTemplatesVersionGeneration Generation { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
