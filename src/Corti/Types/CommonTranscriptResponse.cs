using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

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
    /// The spoken phrase or utterance extracted from the audio. Will be a single word or entity if `wordLevel.enabled` was set to `true` when the transcript was created.
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

    /// <summary>
    /// The separator to prepend to this item's `text` when joining transcript output: an ordinary space " ", no separator "" (for example, punctuation that attaches to the previous item, or the first item of a stream), or a non-breaking space "\u00A0" used before some punctuation marks in some locales. If the property is omitted, treat it as an empty string.
    /// </summary>
    [JsonPropertyName("delimiterBefore")]
    public string? DelimiterBefore { get; set; }

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
