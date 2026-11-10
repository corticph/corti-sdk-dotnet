using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// The registry source of an attached connector. Present only on registry-sourced connectors; inline connectors omit `registry` entirely. `version` is the version resolved at attach time (the latest at that moment unless pinned); it is never re-synced.
/// </summary>
[Serializable]
public record AgenticRegistryConnectorReferenceResolved : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Scoped slug of the registry connector.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Configuration version resolved at attach time; not re-synced when the registry publishes newer versions.
    /// </summary>
    [JsonPropertyName("version")]
    public required string Version { get; set; }

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
