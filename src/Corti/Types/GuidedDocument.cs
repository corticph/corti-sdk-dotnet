using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// A generated document saved to the database.
/// </summary>
[Serializable]
public record GuidedDocument : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The template ID used for generation. For a plain `templateRef` with no overrides this is the referenced template. For other paths it is the newly saved auto-generated template aggregate.
    /// </summary>
    [JsonPropertyName("templateId")]
    public required string TemplateId { get; set; }

    /// <summary>
    /// The specific template version that was used for generation.
    /// </summary>
    [JsonPropertyName("templateVersionId")]
    public required string TemplateVersionId { get; set; }

    /// <summary>
    /// The BCP 47 language tag of the generated output.
    /// </summary>
    [JsonPropertyName("outputLanguage")]
    public required string OutputLanguage { get; set; }

    /// <summary>
    /// The interaction whose context was used to generate this document, if supplied.
    /// </summary>
    [JsonPropertyName("interactionId")]
    public string? InteractionId { get; set; }

    /// <summary>
    /// The generated document as a map of section ID to rendered string output. The `sections` array lists every section ID and its heading.
    /// </summary>
    [JsonPropertyName("stringDocument")]
    public Dictionary<string, string> StringDocument { get; set; } =
        new Dictionary<string, string>();

    /// <summary>
    /// The generated document as a structured object keyed by section ID. The `sections` array lists every section ID and its heading.
    /// </summary>
    [JsonPropertyName("structuredDocument")]
    public Dictionary<string, object?>? StructuredDocument { get; set; }

    /// <summary>
    /// Every section in the template version, in template order, including sections the model left empty. Use `sectionId` as the key into `stringDocument` and `structuredDocument`. The `heading` and `labels` let you render the section without a GET request per section.
    /// </summary>
    [JsonPropertyName("sections")]
    public IEnumerable<GuidedDocumentSection>? Sections { get; set; }

    /// <summary>
    /// Key/value labels attached to this document.
    /// </summary>
    [JsonPropertyName("labels")]
    public IEnumerable<GuidedLabel> Labels { get; set; } = new List<GuidedLabel>();

    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    [JsonPropertyName("updatedAt")]
    public required DateTime UpdatedAt { get; set; }

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
