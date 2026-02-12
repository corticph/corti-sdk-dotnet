using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record RequestAlign : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The content of the source document.
    /// </summary>
    [JsonPropertyName("sourceDocument")]
    public required string SourceDocument { get; set; }

    /// <summary>
    /// The content of the target document.
    /// </summary>
    [JsonPropertyName("targetDocument")]
    public required string TargetDocument { get; set; }

    /// <summary>
    /// Indicates if segments from the source should be compared with the target.
    /// </summary>
    [JsonPropertyName("compareSegments")]
    public bool? CompareSegments { get; set; }

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
