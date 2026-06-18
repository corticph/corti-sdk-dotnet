using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Define words, terms, and phrases to be recognized by Corti speech-to-text. Especially useful for proper nouns (e.g., surnames), but also supportive of words not being recognized consistently. Configuration is case sensitive and limited to 1,000 key terms per stream.
/// </summary>
[Serializable]
public record TranscriptsCreateRequestKeyterms : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Ordered list of words to be recognized.
    /// </summary>
    [JsonPropertyName("terms")]
    public IEnumerable<TranscriptsCreateRequestKeytermsTermsItem>? Terms { get; set; }

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
