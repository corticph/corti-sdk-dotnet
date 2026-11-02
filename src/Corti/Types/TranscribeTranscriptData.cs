using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

[Serializable]
public record TranscribeTranscriptData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Transcript segment with punctuations applied and command phrases removed
    /// </summary>
    [JsonPropertyName("text")]
    public required string Text { get; set; }

    /// <summary>
    /// The raw transcript without spoken punctuation applied and without command phrases removed
    /// </summary>
    [JsonPropertyName("rawTranscriptText")]
    public required string RawTranscriptText { get; set; }

    /// <summary>
    /// Start time of the transcript segment in seconds
    /// </summary>
    [JsonPropertyName("start")]
    public required double Start { get; set; }

    /// <summary>
    /// End time of the transcript segment in seconds
    /// </summary>
    [JsonPropertyName("end")]
    public required double End { get; set; }

    /// <summary>
    /// If false, then interim transcript result
    /// </summary>
    [JsonPropertyName("isFinal")]
    public required bool IsFinal { get; set; }

    /// <summary>
    /// The separator to prepend to this item's `text` when joining: an ordinary space " ", no separator "" (for example, a punctuation mark that attaches to the previous item, or the first item of a session or of a finalized batch), or a non-breaking space "\u00A0" used before some punctuation marks in some locales. If the property is omitted, treat it as an empty string. When joining one finalized batch to another, add the separator yourself, typically a single space. See the join rule in [Transcript Text Handling](https://docs.corti.ai/stt/best-practices-transcribe#join-words-and-segments-with-delimiterbefore)
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
