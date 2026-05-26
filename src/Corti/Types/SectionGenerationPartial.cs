using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// Partial form of SectionGeneration used when inheriting from another section. Any field omitted is inherited from the referenced section.
/// </summary>
[Serializable]
public record SectionGenerationPartial : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Override the inherited section title. Passed to the LLM.
    /// </summary>
    [JsonPropertyName("heading")]
    public string? Heading { get; set; }

    /// <summary>
    /// Override the inherited prompt instructions for this section. Any field omitted is inherited.
    /// </summary>
    [JsonPropertyName("instructions")]
    public SectionInstructionsPartial? Instructions { get; set; }

    /// <summary>
    /// Override the inherited output schema.
    /// </summary>
    [JsonPropertyName("outputSchema")]
    public OutputSchema? OutputSchema { get; set; }

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
