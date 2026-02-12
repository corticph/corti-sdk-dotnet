using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record StreamConfigParticipant : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Audio channel number (e.g. 0 or 1)
    /// </summary>
    [JsonPropertyName("channel")]
    public required int Channel { get; set; }

    /// <summary>
    /// Role of the participant (e.g., doctor, patient, or multiple)
    /// </summary>
    [JsonPropertyName("role")]
    public required StreamConfigParticipantRole Role { get; set; }

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
