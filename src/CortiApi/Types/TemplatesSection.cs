using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record TemplatesSection : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The timestamp when the section was updated.
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Name of the section.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Alternate name for the section. Not used by LLM response.
    /// </summary>
    [JsonPropertyName("alternateName")]
    public string? AlternateName { get; set; }

    /// <summary>
    /// Unique key for the section.
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    /// <summary>
    /// Description of the section.
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    /// <summary>
    /// Default writing style for the section.
    /// </summary>
    [JsonPropertyName("defaultWritingStyle")]
    public required TemplatesWritingStyle DefaultWritingStyle { get; set; }

    /// <summary>
    /// Default format rule for the section.
    /// </summary>
    [JsonPropertyName("defaultFormatRule")]
    public TemplatesFormatRule? DefaultFormatRule { get; set; }

    /// <summary>
    /// Additional instructions or context for the section.
    /// </summary>
    [JsonPropertyName("additionalInstructions")]
    public string? AdditionalInstructions { get; set; }

    /// <summary>
    /// Used to guide input assignment in documentationMode: routed_parallel, and for section generation.
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [JsonPropertyName("documentationMode")]
    public TemplatesDocumentationModeEnum? DocumentationMode { get; set; }

    /// <summary>
    /// Type of section.
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    /// <summary>
    /// Available translations for the section.
    /// </summary>
    [JsonPropertyName("translations")]
    public IEnumerable<TemplatesSectionTranslation> Translations { get; set; } =
        new List<TemplatesSectionTranslation>();

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
