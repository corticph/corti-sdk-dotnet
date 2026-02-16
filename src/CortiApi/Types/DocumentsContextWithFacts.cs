using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record DocumentsContextWithFacts : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The type of context data that will be used in the request: `Facts`, `Transcript`, or `String`.
    /// </summary>
    [JsonPropertyName("type")]
    public required DocumentsContextWithFactsType Type { get; set; }

    /// <summary>
    /// An array of facts. See [guide](/textgen/documents-standard##generate-document-from-facts-as-input).
    /// </summary>
    [JsonPropertyName("data")]
    public IEnumerable<FactsContext> Data { get; set; } = new List<FactsContext>();

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
