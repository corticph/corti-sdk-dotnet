using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Reference to a registry connector version in an attach request. Presence of the `registry` object marks the connector as registry-sourced: the inline definition fields and `registry` are mutually exclusive — exactly one of them must be present per connector, otherwise the request is rejected with `400`. An omitted `version` resolves to the latest version at attach time; the resolved version is recorded on attach and never re-synced afterwards.
/// </summary>
[Serializable]
public record AgenticRegistryConnectorReference : IJsonOnDeserialized
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
    /// Pins a specific configuration version; omitted means the latest version at attach time.
    /// </summary>
    [JsonPropertyName("version")]
    public string? Version { get; set; }

    /// <summary>
    /// Attach-time configuration, validated against the version's `configSchema`.
    /// </summary>
    [JsonPropertyName("config")]
    public Dictionary<string, object?>? Config { get; set; }

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
