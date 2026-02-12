using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;
using OneOf;

namespace CortiApi;

[Serializable]
public record AgentsFilePart : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The kind of the part, always "file".
    /// </summary>
    [JsonPropertyName("kind")]
    public required AgentsFilePartKind Kind { get; set; }

    [JsonPropertyName("file")]
    public OneOf<AgentsFileWithUri, AgentsFileWithBytes>? File { get; set; }

    /// <summary>
    /// Additional metadata for the file part.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, object?>? Metadata { get; set; }

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
