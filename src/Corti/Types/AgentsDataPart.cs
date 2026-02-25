using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record AgentsDataPart : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The kind of the part, always "data".
    /// </summary>
    [JsonPropertyName("kind")]
    public required AgentsDataPartKind Kind { get; set; }

    /// <summary>
    /// JSON data payload.
    /// </summary>
    [JsonPropertyName("data")]
    public Dictionary<string, object?> Data { get; set; } = new Dictionary<string, object?>();

    /// <summary>
    /// Additional metadata for the data part.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, object?>? Metadata { get; set; }

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
