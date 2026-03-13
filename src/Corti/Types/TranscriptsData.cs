using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record TranscriptsData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Additional information about the participants involved in the transcript.
    /// </summary>
    [JsonPropertyName("metadata")]
    public required TranscriptsMetadata Metadata { get; set; }

    /// <summary>
    /// An array of transcripts.
    /// </summary>
    [JsonPropertyName("transcripts")]
    public IEnumerable<CommonTranscriptResponse> Transcripts { get; set; } =
        new List<CommonTranscriptResponse>();

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
