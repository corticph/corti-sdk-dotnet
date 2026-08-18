using Corti;
using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti.Agentic;

[Serializable]
public record AgenticAgentsCreateRequest
{
    /// <summary>
    /// Human-readable, unique-per-tenant agent name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Free-form agent description.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// System prompt prepended to every invocation.
    /// </summary>
    [JsonPropertyName("systemPrompt")]
    public string? SystemPrompt { get; set; }

    /// <summary>
    /// Tenant default if omitted.
    /// </summary>
    [JsonPropertyName("model")]
    public string? Model { get; set; }

    [JsonPropertyName("visibility")]
    public AgentsVisibility? Visibility { get; set; }

    [JsonPropertyName("lifecycle")]
    public AgentsLifecycle? Lifecycle { get; set; }

    /// <summary>
    /// Connectors to attach at creation. Defaults to an empty array.
    /// </summary>
    [JsonPropertyName("connectors")]
    public IEnumerable<CommonConnectorCreateRequest>? Connectors { get; set; }

    [JsonPropertyName("labels")]
    public Dictionary<string, string>? Labels { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
