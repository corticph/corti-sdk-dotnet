using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

[Serializable]
public record StreamTranscript : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Interaction ID that the transcript segments are associated with
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The transcribed text
    /// </summary>
    [JsonPropertyName("transcript")]
    public required string Transcript { get; set; }

    /// <summary>
    /// Indicates whether the transcript is finalized or interim
    /// </summary>
    [JsonPropertyName("final")]
    public required bool Final { get; set; }

    /// <summary>
    /// Speaker identifier (-1 if diarization is off)
    /// </summary>
    [JsonPropertyName("speakerId")]
    public required int SpeakerId { get; set; }

    [JsonPropertyName("participant")]
    public required StreamParticipant Participant { get; set; }

    [JsonPropertyName("time")]
    public required StreamTranscriptTime Time { get; set; }

    /// <summary>
    /// The separator to prepend to `transcript` when joining this segment with previous output from the same speaker and channel: an ordinary space " ", no separator "" (for example, a segment beginning with punctuation, or the first segment of a stream), or a non-breaking space "\u00A0" used before some punctuation marks in some locales. If the property is omitted, treat it as an empty string. The spacing between different speakers or channels is not provided; see [Transcript Text Handling](https://docs.corti.ai/stt/best-practices-transcribe#join-words-and-segments-with-delimiterbefore)
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
