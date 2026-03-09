using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record TranscribeCommandVariable : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Variable key identifier
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    /// <summary>
    /// Variable type
    /// </summary>
    [JsonPropertyName("type")]
    public string Type
    {
        get => "enum";
        set => value.Assert(value == "enum", string.Format("'Type' must be {0}", "enum"));
    }

    /// <summary>
    /// Enum values for the variable
    /// </summary>
    [JsonPropertyName("enum")]
    public IEnumerable<string> Enum { get; set; } = new List<string>();

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
