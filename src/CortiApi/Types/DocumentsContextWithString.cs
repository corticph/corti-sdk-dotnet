using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record DocumentsContextWithString : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The type of context data that will be used in the request: `Facts`, `Transcript`, or `String`.
    /// </summary>
    [JsonPropertyName("type")]
    public required DocumentsContextWithStringType Type { get; set; }

    /// <summary>
    /// String data can include any text to be reasoned over for document generation: Transcript text, facts, or other narrative information.
    /// </summary>
    [JsonPropertyName("data")]
    public required string Data { get; set; }

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
