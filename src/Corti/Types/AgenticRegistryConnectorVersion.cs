using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// An immutable per-version configuration record of a registry connector. Once published, a version never changes; new releases add new versions.
/// </summary>
[Serializable]
public record AgenticRegistryConnectorVersion : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Semantic version (SemVer) of this configuration record.
    /// </summary>
    [JsonPropertyName("version")]
    public required string Version { get; set; }

    /// <summary>
    /// JSON Schema (draft 2020-12) describing the configuration accepted by the attach-time `registry.config` object for this version.
    /// </summary>
    [JsonPropertyName("configSchema")]
    public Dictionary<string, object?> ConfigSchema { get; set; } =
        new Dictionary<string, object?>();

    [JsonPropertyName("payload")]
    public required AgenticRegistryConnectorPayload Payload { get; set; }

    /// <summary>
    /// When this version was published.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

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
