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
    /// Define the variable used in command phrases.
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    /// <summary>
    /// Variable type. Use `enum` to define a fixed list of values that can be recognized for the variable. Use `wildcard` to recognize any undefined, open-ended free-text utterance. When using `wildcard`, the phrase must include a literal trigger word before the wildcard variable (a phrase may not begin with a wildcard variable), and multiple wildcard variables in a single phrase must be separated by a non-empty literal string (e.g. `select {text1} end select {text2}` is valid; `{text1} {text2}` is not).
    /// </summary>
    [JsonPropertyName("type")]
    public required TranscribeCommandVariableType Type { get; set; }

    /// <summary>
    /// List of values that should be recognized for the defined variable. Required when `type` is `enum`. Not used (and ignored) when `type` is `wildcard`.
    /// </summary>
    [JsonPropertyName("enum")]
    public IEnumerable<string>? Enum { get; set; }

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
