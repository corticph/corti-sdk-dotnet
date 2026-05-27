using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// Minimal transcript segment. Only `text` is required.
/// </summary>
[Serializable]
public record GuidedDocumentTranscriptSegmentMinimal : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The channel associated with this phrase/utterance.
    /// </summary>
    [JsonPropertyName("channel")]
    public int? Channel { get; set; }

    /// <summary>
    /// The identifier of the participant.
    /// </summary>
    [JsonPropertyName("participant")]
    public int? Participant { get; set; }

    /// <summary>
    /// Id to tag an identified speaker.
    /// </summary>
    [JsonPropertyName("speakerId")]
    public int? SpeakerId { get; set; }

    /// <summary>
    /// The spoken phrase or utterance.
    /// </summary>
    [JsonPropertyName("text")]
    public required string Text { get; set; }

    /// <summary>
    /// Start time in milliseconds for phrase/utterance.
    /// </summary>
    [JsonPropertyName("start")]
    public int? Start { get; set; }

    /// <summary>
    /// End time in milliseconds for phrase/utterance.
    /// </summary>
    [JsonPropertyName("end")]
    public int? End { get; set; }

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
