using Corti;
using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti.Agentic.Agents;

[Serializable]
public record AgenticConnectorsPatchRequest
{
    /// <summary>
    /// Whether the connector is active.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// New connector name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// New connector URL; `null` clears it.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// New connector config; `null` clears it.
    /// </summary>
    [JsonPropertyName("config")]
    public Dictionary<string, object?>? Config { get; set; }

    [JsonPropertyName("auth")]
    public CommonConnectorAuth? Auth { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
