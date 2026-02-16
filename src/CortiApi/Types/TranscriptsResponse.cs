using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record TranscriptsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The unique identifier of the transcript.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Additional information about the participants involved in the transcript.
    /// </summary>
    [JsonPropertyName("metadata")]
    public required TranscriptsMetadata Metadata { get; set; }

    /// <summary>
    /// An array of transcripts.
    /// </summary>
    [JsonPropertyName("transcripts")]
    public IEnumerable<CommonTranscriptResponse>? Transcripts { get; set; }

    [JsonPropertyName("usageInfo")]
    public required CommonUsageInfo UsageInfo { get; set; }

    /// <summary>
    /// The unique identifier for the associated recording.
    /// </summary>
    [JsonPropertyName("recordingId")]
    public required string RecordingId { get; set; }

    /// <summary>
    /// The current status of the transcript processing.
    /// </summary>
    [JsonPropertyName("status")]
    public required TranscriptsStatusEnum Status { get; set; }

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
