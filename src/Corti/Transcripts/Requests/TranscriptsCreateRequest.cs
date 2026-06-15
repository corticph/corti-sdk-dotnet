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
    /// If true, spoken punctuation will be converted to symbols (e.g., 'comma' → ',').
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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
