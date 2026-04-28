using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record StreamConfigStatusMessage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Configuration status result
    /// </summary>
    [JsonPropertyName("type")]
    public required StreamConfigStatusMessageType Type { get; set; }

    /// <summary>
    /// Optional reason for rejection (e.g., 'language unavailable')
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    /// <summary>
    /// The resolved configuration. Only present when type is CONFIG_ACCEPTED.
    /// </summary>
    [JsonPropertyName("configuration")]
    public StreamConfig? Configuration { get; set; }

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
