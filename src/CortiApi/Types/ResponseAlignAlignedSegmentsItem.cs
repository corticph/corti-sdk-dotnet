using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record ResponseAlignAlignedSegmentsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("targetSegment")]
    public TargetSegment? TargetSegment { get; set; }

    [JsonPropertyName("sourceReference")]
    public IEnumerable<ResponseAlignAlignedSegmentsItemSourceReferenceItem>? SourceReference { get; set; }

    /// <summary>
    /// Alignment percentage between the target and source segment.
    /// </summary>
    [JsonPropertyName("alignmentPercentage")]
    public double? AlignmentPercentage { get; set; }

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
