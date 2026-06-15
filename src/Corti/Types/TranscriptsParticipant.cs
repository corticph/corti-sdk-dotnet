using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

[Serializable]
public record TranscriptsParticipant : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The audio channel to associate with a participant role.
    /// </summary>
    [JsonPropertyName("channel")]
    public required int Channel { get; set; }

    /// <summary>
    /// The role of the participant (e.g., 'doctor', 'patient', use 'multiple' for single channel).
    /// </summary>
    [JsonPropertyName("role")]
    public required TranscriptsParticipantRoleEnum Role { get; set; }

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
