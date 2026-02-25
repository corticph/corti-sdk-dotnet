using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record TranscribeCommand : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// To identify the command when it gets detected and returned over the WebSocket
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The spoken phrases that should trigger the command
    /// </summary>
    [JsonPropertyName("phrases")]
    public IEnumerable<string> Phrases { get; set; } = new List<string>();

    /// <summary>
    /// Variables for the command
    /// </summary>
    [JsonPropertyName("variables")]
    public IEnumerable<TranscribeCommandVariable>? Variables { get; set; }

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
