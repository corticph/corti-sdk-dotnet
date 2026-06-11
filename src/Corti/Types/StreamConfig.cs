using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record StreamConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("transcription")]
    public required StreamConfigTranscription Transcription { get; set; }

    [JsonPropertyName("mode")]
    public required StreamConfigMode Mode { get; set; }

    /// <summary>
    /// Optional parameter to specify data retention policy for the generated transcripts and facts. Use value 'none' to indicate data should not be stored in the database. Use value 'retain' to indicate that the data should be retained according to standard retention policies. If configuration is not provided, then the default retention policy will apply.
    /// </summary>
    [JsonPropertyName("retentionPolicy")]
    public StreamConfigRetentionPolicy? RetentionPolicy { get; set; }

    [JsonPropertyName("audioEvents")]
    public StreamAudioEventsConfig? AudioEvents { get; set; }

    /// <summary>
    /// Define the audio format of the incoming audio stream - optional but recommended. When omitted, the server auto-detects the format from the first audio chunk using ffprobe. Supported audio will be processed. Unsupported return an error but might in some cases error silently. If provided (recommended), the provided MIME type must be supported and the audio must match the MIME type. An unsupported MIME type results in `CONFIG_REJECTED`. Audio that differs from the MIME type will return audio validation errors on the socket. See full list of supported MIME types [here](/stt/audio).
    /// </summary>
    [JsonPropertyName("audioFormat")]
    public string? AudioFormat { get; set; }

    /// <summary>
    /// Define replacements to have terms (single words or multi-word phrases) replaced in final text output with your preferred style. For example, replace "BID" with "twice daily". Configuration is case insensitive and limited to 1,000 replacements per stream.
    /// </summary>
    [JsonPropertyName("replacements")]
    public IEnumerable<StreamConfigReplacementsItem>? Replacements { get; set; }

    /// <summary>
    /// Define words, terms, and phrases to be recognized by Corti speech-to-text. Especially useful for proper nouns (e.g., surnames), but also supportive of words not being recognized consistently. Configuration is case sensitive and limited to 1,000 key terms per stream.
    /// </summary>
    [JsonPropertyName("keyterms")]
    public StreamConfigKeyterms? Keyterms { get; set; }

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
