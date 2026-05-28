using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// Optional transcript-level metadata. All fields optional.
/// </summary>
[Serializable]
public record GuidedDocumentTranscriptMetadataMinimal : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("participantsRoles")]
    public IEnumerable<TranscriptsParticipant>? ParticipantsRoles { get; set; }

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
