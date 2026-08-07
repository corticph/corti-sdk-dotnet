using Corti;
using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti.Agentic;

[Serializable]
public record AgenticPatchRequest
{
    /// <summary>
    /// New agent name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// New description; `null` clears it.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// New system prompt; `null` clears it.
    /// </summary>
    [JsonPropertyName("systemPrompt")]
    public string? SystemPrompt { get; set; }

    /// <summary>
    /// New model identifier; `null` falls back to the tenant default.
    /// </summary>
    [JsonPropertyName("model")]
    public string? Model { get; set; }

    [JsonPropertyName("visibility")]
    public AgenticVisibility? Visibility { get; set; }

    [JsonPropertyName("lifecycle")]
    public AgenticLifecycle? Lifecycle { get; set; }

    /// <summary>
    /// Replacement connector list; `null` clears connectors.
    /// </summary>
    [JsonPropertyName("connectors")]
    public IEnumerable<CommonConnectorCreateRequest>? Connectors { get; set; }

    /// <summary>
    /// Replacement labels; `null` clears labels.
    /// </summary>
    [JsonPropertyName("labels")]
    public Dictionary<string, string?>? Labels { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
