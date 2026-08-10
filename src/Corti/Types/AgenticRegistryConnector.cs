using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// A discoverable, pre-built connector offered by the platform registry.
/// Only `id`, `type`, `name`, `title`, `description`, and `configSchema` are populated by the server today. `version`, `provider`, `capabilities`, `tags`, and `documentationUrl` are declared for forward compatibility but are not yet returned.
/// </summary>
[Serializable]
public record AgenticRegistryConnector : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Stable, namespaced registry identifier; use as a `registry` connector's `name`.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The connector kind this entry provisions when attached to an agent.
    /// </summary>
    [JsonPropertyName("type")]
    public required CommonConnectorType Type { get; set; }

    /// <summary>
    /// Programmatic name (MCP convention).
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Human-readable display name (MCP convention).
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// Description for list and detail views. May contain CommonMark.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Latest published version (SemVer recommended).
    /// </summary>
    [JsonPropertyName("version")]
    public string? Version { get; set; }

    /// <summary>
    /// Display icons (MCP convention).
    /// </summary>
    [JsonPropertyName("icons")]
    public IEnumerable<AgenticRegistryIcon>? Icons { get; set; }

    /// <summary>
    /// Name of the publishing organisation.
    /// </summary>
    [JsonPropertyName("provider")]
    public string? Provider { get; set; }

    /// <summary>
    /// Connector homepage (MCP convention).
    /// </summary>
    [JsonPropertyName("websiteUrl")]
    public string? WebsiteUrl { get; set; }

    /// <summary>
    /// Documentation URL for the connector.
    /// </summary>
    [JsonPropertyName("documentationUrl")]
    public string? DocumentationUrl { get; set; }

    [JsonPropertyName("capabilities")]
    public AgenticRegistryConnectorCapabilities? Capabilities { get; set; }

    /// <summary>
    /// Keywords for search and filtering.
    /// </summary>
    [JsonPropertyName("tags")]
    public IEnumerable<string>? Tags { get; set; }

    /// <summary>
    /// JSON Schema (draft 2020-12) describing the connector's accepted `config`.
    /// </summary>
    [JsonPropertyName("configSchema")]
    public Dictionary<string, object?>? ConfigSchema { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
