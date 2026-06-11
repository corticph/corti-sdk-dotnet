using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// Define words, terms, and phrases to be recognized by Corti speech-to-text. Especially useful for proper nouns (e.g., surnames), but also supportive of words not being recognized consistently. Configuration is case sensitive and limited to 1,000 key terms per stream.
/// </summary>
[Serializable]
public record TranscribeConfigKeyterms : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Ordered list of words to be recognized.
    /// </summary>
    [JsonPropertyName("terms")]
    public IEnumerable<TranscribeConfigKeytermsTermsItem>? Terms { get; set; }

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
