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
    /// Free-form label for the participant role (e.g., 'doctor', 'patient', 'Attending Physician'). Must not be empty or whitespace-only after trimming, must not contain control characters, and must not exceed 100 characters or 10 words.
    /// </summary>
    [JsonPropertyName("role")]
    public required string Role { get; set; }

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
