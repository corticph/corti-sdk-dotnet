using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// The configuration payload of a registry connector version: `systemPrompt`, `mcpServers`, and any bundled schema definitions. Configuration only — presentation metadata lives on the connector record. For `agent`-type connectors, `systemPrompt` is required and always exposed by the API.
/// </summary>
[Serializable]
public record AgenticRegistryConnectorPayload : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// System prompt for the connector. Required and always exposed by the API for `agent`-type connectors; ignored for the other types.
    /// </summary>
    [JsonPropertyName("systemPrompt")]
    public string? SystemPrompt { get; set; }

    /// <summary>
    /// MCP servers bundled by the connector. Each entry names the server; auth collections carry one `CommonConnectorAuthEntry` per bundled server, keyed by server name.
    /// </summary>
    [JsonPropertyName("mcpServers")]
    public IEnumerable<AgenticRegistryConnectorPayloadMcpServersItem>? McpServers { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
