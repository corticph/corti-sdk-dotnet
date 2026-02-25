using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record TranscribeConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The locale of the primary spoken language.
    /// </summary>
    [JsonPropertyName("primaryLanguage")]
    public required string PrimaryLanguage { get; set; }

    /// <summary>
    /// When true, returns interim results for reduced latency
    /// </summary>
    [JsonPropertyName("interimResults")]
    public bool? InterimResults { get; set; }

    /// <summary>
    /// When true, converts spoken punctuation such as 'period' or 'slash' into '.' or '/'
    /// </summary>
    [JsonPropertyName("spokenPunctuation")]
    public bool? SpokenPunctuation { get; set; }

    /// <summary>
    /// When true, automatically punctuates and capitalizes in the final transcript
    /// </summary>
    [JsonPropertyName("automaticPunctuation")]
    public bool? AutomaticPunctuation { get; set; }

    /// <summary>
    /// Commands that should be registered and detected
    /// </summary>
    [JsonPropertyName("commands")]
    public IEnumerable<TranscribeCommand>? Commands { get; set; }

    [JsonPropertyName("formatting")]
    public TranscribeFormatting? Formatting { get; set; }

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
