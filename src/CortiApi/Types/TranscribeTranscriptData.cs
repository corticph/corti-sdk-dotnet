using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

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
