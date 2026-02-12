using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record TemplatesItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The timestamp when the template was updated.
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Name of the template.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Description of the template.
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    /// <summary>
    /// Instructions or context for all template sections.
    /// </summary>
    [JsonPropertyName("additionalInstructions")]
    public string? AdditionalInstructions { get; set; }

    /// <summary>
    /// Unique key for the template.
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    /// <summary>
    /// Status of the template.
    /// </summary>
    [JsonPropertyName("status")]
    public required string Status { get; set; }

    [JsonPropertyName("documentationMode")]
    public TemplatesDocumentationModeEnum? DocumentationMode { get; set; }

    /// <summary>
    /// List of sections included in the template.
    /// </summary>
    [JsonPropertyName("templateSections")]
    public IEnumerable<TemplatesSectionSorted> TemplateSections { get; set; } =
        new List<TemplatesSectionSorted>();

    /// <summary>
    /// Available translations for the template.
    /// </summary>
    [JsonPropertyName("translations")]
    public IEnumerable<TemplatesTranslation> Translations { get; set; } =
        new List<TemplatesTranslation>();

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
