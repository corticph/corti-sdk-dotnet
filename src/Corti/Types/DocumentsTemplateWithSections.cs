using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record DocumentsTemplateWithSections : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("sections")]
    public IEnumerable<DocumentsSectionOverride> Sections { get; set; } =
        new List<DocumentsSectionOverride>();

    /// <summary>
    /// A brief description of the document that can help give the LLM some context.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Overrides and sets template-level additional instructions.
    /// </summary>
    [JsonPropertyName("additionalInstructionsOverride")]
    public string? AdditionalInstructionsOverride { get; set; }

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
