using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// Minimal transcript shape accepted as guided-document input context. Decoupled from the transcript resource: only `transcripts` is required, and within each segment only `text` is required.
/// </summary>
[Serializable]
public record GuidedDocumentTranscriptMinimal : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("metadata")]
    public GuidedDocumentTranscriptMetadataMinimal? Metadata { get; set; }

    [JsonPropertyName("transcripts")]
    public IEnumerable<GuidedDocumentTranscriptSegmentMinimal> Transcripts { get; set; } =
        new List<GuidedDocumentTranscriptSegmentMinimal>();

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
