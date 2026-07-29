using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti;

[Serializable]
public record FactsExtractRequest
{
    /// <summary>
    /// Identifies a distinct entity within Corti's multi-tenant system. Ensures correct routing and authentication of the request.
    /// </summary>
    [JsonIgnore]
    public required string TenantName { get; set; }

    [JsonPropertyName("context")]
    public IEnumerable<CommonTextContext> Context { get; set; } = new List<CommonTextContext>();

    /// <summary>
    /// The desired output language code for extracted facts. Check [languages page](/stt/languages) for more.
    /// </summary>
    [JsonPropertyName("outputLanguage")]
    public required string OutputLanguage { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
