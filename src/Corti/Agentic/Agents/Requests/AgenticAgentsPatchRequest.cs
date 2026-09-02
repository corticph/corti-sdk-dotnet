using Corti;
using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti.Agentic;

[Serializable]
public record AgenticAgentsPatchRequest
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

    /// <summary>
    /// New cap on the orchestrator's ReAct loop iterations per run. Omitted leaves the current value unchanged; there is no `null`-reset — send 10 to restore the default.
    /// </summary>
    [JsonPropertyName("maxLoops")]
    public int? MaxLoops { get; set; }

    [JsonPropertyName("visibility")]
    public AgentsVisibility? Visibility { get; set; }

    [JsonPropertyName("lifecycle")]
    public AgentsLifecycle? Lifecycle { get; set; }

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
