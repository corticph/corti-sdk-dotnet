using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

[Serializable]
public record GuidedSectionGeneration : IJsonOnDeserialized
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
    public required GuidedSectionInstructions Instructions { get; set; }

    [JsonPropertyName("outputSchema")]
    public required GuidedOutputSchema OutputSchema { get; set; }

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
