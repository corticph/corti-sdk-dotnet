using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

[Serializable]
public record StreamConfigTranscription : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Primary spoken language for transcription
    /// </summary>
    [JsonPropertyName("primaryLanguage")]
    public required string PrimaryLanguage { get; set; }

    /// <summary>
    /// Controls how recognized transcript text is processed before it is returned. `standard` (default) applies Corti's standard transcript processing and configured transcript features. `raw` returns the core speech recognition result without transcript transformations or enhancements, which can reduce latency and processing cost but may reduce transcript accuracy. When `raw` is defined, features that transform transcript text (such as formatting or replacements) are not available; features that describe the recognition result (such as timestamps, word-level output, diarization, and audio events) remain supported where applicable. The `text` and `rawTranscriptText` fields contain the same core recognition result.
    /// </summary>
    [JsonPropertyName("transcriptProcessing")]
    public StreamConfigTranscriptionTranscriptProcessing? TranscriptProcessing { get; set; }

    /// <summary>
    /// Enable speaker diarization.
    /// </summary>
    [JsonPropertyName("diarize")]
    public bool? Diarize { get; set; }

    /// <summary>
    /// **Deprecated** — renamed to `diarize`. Still accepted for backward compatibility; `diarize` takes precedence when both are provided. `CONFIG_ACCEPTED` echoes both fields during the deprecation period. No removal date is currently planned.
    /// </summary>
    [JsonPropertyName("isDiarization")]
    public bool? IsDiarization { get; set; }

    /// <summary>
    /// Enable multi-channel audio processing
    /// </summary>
    [JsonPropertyName("isMultichannel")]
    public bool? IsMultichannel { get; set; }

    /// <summary>
    /// List of participants with roles assigned to a channel
    /// </summary>
    [JsonPropertyName("participants")]
    public IEnumerable<StreamConfigParticipant> Participants { get; set; } =
        new List<StreamConfigParticipant>();

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
