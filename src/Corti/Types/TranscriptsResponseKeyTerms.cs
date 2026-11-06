using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Key terms echoed from the create request. Not persisted; may be omitted on subsequent GETs.
/// </summary>
[Serializable]
public record TranscriptsResponseKeyTerms : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("terms")]
    public IEnumerable<TranscriptsResponseKeyTermsTermsItem> Terms { get; set; } =
        new List<TranscriptsResponseKeyTermsTermsItem>();

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
