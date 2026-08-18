using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// What the connector can do once attached.
/// </summary>
[Serializable]
public record AgenticRegistryConnectorCapabilities : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Emits incremental updates during a task.
    /// </summary>
    [JsonPropertyName("streaming")]
    public bool? Streaming { get; set; }

    /// <summary>
    /// Accepted input media types.
    /// </summary>
    [JsonPropertyName("inputModes")]
    public IEnumerable<string>? InputModes { get; set; }

    /// <summary>
    /// Produced output media types.
    /// </summary>
    [JsonPropertyName("outputModes")]
    public IEnumerable<string>? OutputModes { get; set; }

    /// <summary>
    /// Names of tools the connector exposes to the agent.
    /// </summary>
    [JsonPropertyName("tools")]
    public IEnumerable<string>? Tools { get; set; }

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
