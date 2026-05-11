using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record SectionGeneration : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The heading of this section. Passed to the LLM.
    /// </summary>
    [JsonPropertyName("heading")]
    public required string Heading { get; set; }

    /// <summary>
    /// The prompt instructions for this section.
    /// </summary>
    [JsonPropertyName("instructions")]
    public required SectionInstructions Instructions { get; set; }

    [JsonPropertyName("outputSchema")]
    public required OutputSchema OutputSchema { get; set; }

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
