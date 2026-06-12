using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

[Serializable]
public record TranscribeConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The locale of the primary spoken language.
    /// </summary>
    [JsonPropertyName("primaryLanguage")]
    public required string PrimaryLanguage { get; set; }

    /// <summary>
    /// When true, returns interim (preview) transcript results (`isFinal=false`) for reduced latency than final transcripts. Defaults to false.
    /// </summary>
    [JsonPropertyName("interimResults")]
    public bool? InterimResults { get; set; }

    /// <summary>
    /// When true, converts spoken punctuation such as 'period' or 'slash' into '.' or '/'. Defaults to false. Overrides automaticPunctuation when both are enabled.
    /// </summary>
    [JsonPropertyName("spokenPunctuation")]
    public bool? SpokenPunctuation { get; set; }

    /// <summary>
    /// When true, automatically punctuates and capitalizes in the final transcript. Defaults to false. Overridden by spokenPunctuation when both are enabled.
    /// </summary>
    [JsonPropertyName("automaticPunctuation")]
    public bool? AutomaticPunctuation { get; set; }

    /// <summary>
    /// Commands that should be registered and detected
    /// </summary>
    [JsonPropertyName("commands")]
    public IEnumerable<TranscribeCommand>? Commands { get; set; }

    [JsonPropertyName("formatting")]
    public TranscribeFormatting? Formatting { get; set; }

    [JsonPropertyName("audioEvents")]
    public TranscribeAudioEventsConfig? AudioEvents { get; set; }

    /// <summary>
    /// Define the audio format of the incoming audio stream - optional but recommended. When omitted, the server auto-detects the format from the first audio chunk using ffprobe. Supported audio will be processed. Unsupported return an error but might in some cases error silently. If provided (recommended), the provided MIME type must be supported and the audio must match the MIME type. An unsupported MIME type results in `CONFIG_REJECTED`. Audio that differs from the MIME type will return audio validation errors on the socket. See full list of supported MIME types [here](/stt/audio).
    /// </summary>
    [JsonPropertyName("audioFormat")]
    public string? AudioFormat { get; set; }

    /// <summary>
    /// Define replacements to have terms (single words or multi-word phrases) replaced in final text output with your preferred style. For example, replace "BID" with "twice daily". Configuration is case insensitive and limited to 1,000 replacements per stream.
    /// </summary>
    [JsonPropertyName("replacements")]
    public IEnumerable<TranscribeConfigReplacementsItem>? Replacements { get; set; }

    /// <summary>
    /// Define words, terms, and phrases to be recognized by Corti speech-to-text. Especially useful for proper nouns (e.g., surnames), but also supportive of words not being recognized consistently. Configuration is case sensitive and limited to 1,000 key terms per stream.
    /// </summary>
    [JsonPropertyName("keyterms")]
    public TranscribeConfigKeyterms? Keyterms { get; set; }

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
