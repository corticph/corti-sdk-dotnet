using System.Text.Json.Serialization;
using Corti.Core;

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
    /// The primary spoken language of the recording. Check https://docs.corti.ai/about/languages for more.
    /// </summary>
    [JsonPropertyName("primaryLanguage")]
    public required string PrimaryLanguage { get; set; }

    /// <summary>
    /// Indicates whether spoken dictation commands should be converted to punctuation (e.g., 'comma' → ',').
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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
