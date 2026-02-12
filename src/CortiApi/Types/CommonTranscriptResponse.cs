using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record CommonTranscriptResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The channel associated with this phrase/utterance.
    /// </summary>
    [JsonPropertyName("channel")]
    public required int Channel { get; set; }

    /// <summary>
    /// The identifier of the participant.
    /// </summary>
    [JsonPropertyName("participant")]
    public required int Participant { get; set; }

    /// <summary>
    /// Id to tag an identified speaker. Auto-increments.
    /// </summary>
    [JsonPropertyName("speakerId")]
    public required int SpeakerId { get; set; }

    /// <summary>
    /// The spoken phrase or utterance extracted from the audio.
    /// </summary>
    [JsonPropertyName("text")]
    public required string Text { get; set; }

    /// <summary>
    /// Start time in milliseconds for phrase/utterance.
    /// </summary>
    [JsonPropertyName("start")]
    public required int Start { get; set; }

    /// <summary>
    /// End time in milliseconds for phrase/utterance.
    /// </summary>
    [JsonPropertyName("end")]
    public required int End { get; set; }

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
