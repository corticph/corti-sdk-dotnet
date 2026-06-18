using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti;

[Serializable]
public record TranscriptsCreateRequest
{
    /// <summary>
    /// The unique identifier for the recording.
    /// </summary>
    [JsonPropertyName("recordingId")]
    public required string RecordingId { get; set; }

    /// <summary>
    /// The primary spoken language of the recording. Check https://docs.corti.ai/stt/languages for more.
    /// </summary>
    [JsonPropertyName("primaryLanguage")]
    public required string PrimaryLanguage { get; set; }

    /// <summary>
    /// When true, converts spoken punctuation such as 'period' or 'slash' into symbols (e.g., '.', '/'). When enabled, automatic punctuation is turned off. Takes precedence over `automaticPunctuation` when both are enabled.
    /// </summary>
    [JsonPropertyName("spokenPunctuation")]
    public bool? SpokenPunctuation { get; set; }

    /// <summary>
    /// When true, automatically punctuates and capitalizes the transcript. Defaults to true. Overridden by `spokenPunctuation` when both are enabled.
    /// </summary>
    [JsonPropertyName("automaticPunctuation")]
    public bool? AutomaticPunctuation { get; set; }

    /// <summary>
    /// **Deprecated** — replaced by `spokenPunctuation` and `automaticPunctuation`. Ignored when either of those fields is provided. When `true` and neither new field is provided, it is treated as `spokenPunctuation: true` (automatic punctuation off). No removal date is currently planned.
    /// </summary>
    [JsonPropertyName("isDictation")]
    public bool? IsDictation { get; set; }

    /// <summary>
    /// If true, each audio channel is transcribed separately.
    /// </summary>
    [JsonPropertyName("isMultichannel")]
    public bool? IsMultichannel { get; set; }

    /// <summary>
    /// If true, separates speakers within an audio channel returning incrementing ids for transcript segments.
    /// </summary>
    [JsonPropertyName("diarize")]
    public bool? Diarize { get; set; }

    /// <summary>
    /// An array of participants, each specifying a role and an assigned audio channel in the recording. Leave empty when shouldDiarize: true
    /// </summary>
    [JsonPropertyName("participants")]
    public IEnumerable<TranscriptsParticipant>? Participants { get; set; }

    /// <summary>
    /// If true, the request will return immediately with a 202 status and the transcript will be processed asynchronously. Poll [Get Transcript Status](/api-reference/transcripts/get-transcript-status) to check transcript processing status - `processing`, `completed`, `failed`.
    /// </summary>
    [JsonPropertyName("async")]
    public bool? Async { get; set; }

    /// <summary>
    /// Define replacements to have terms (single words or multi-word phrases) replaced in final text output with your preferred style. For example, replace "BID" with "twice daily". Configuration is case insensitive and limited to 1,000 replacements per stream.
    /// </summary>
    [JsonPropertyName("replacements")]
    public IEnumerable<TranscriptsCreateRequestReplacementsItem>? Replacements { get; set; }

    /// <summary>
    /// Define words, terms, and phrases to be recognized by Corti speech-to-text. Especially useful for proper nouns (e.g., surnames), but also supportive of words not being recognized consistently. Configuration is case sensitive and limited to 1,000 key terms per stream.
    /// </summary>
    [JsonPropertyName("keyterms")]
    public TranscriptsCreateRequestKeyterms? Keyterms { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
