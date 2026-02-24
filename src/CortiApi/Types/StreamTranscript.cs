using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

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
