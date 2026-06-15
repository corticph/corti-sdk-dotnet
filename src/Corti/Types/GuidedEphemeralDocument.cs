using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// A generated document that was not saved to the database.
/// </summary>
[Serializable]
public record GuidedEphemeralDocument : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("templateId")]
    public required string TemplateId { get; set; }

    [JsonPropertyName("templateVersionId")]
    public required string TemplateVersionId { get; set; }

    /// <summary>
    /// The BCP 47 language tag of the generated output.
    /// </summary>
    [JsonPropertyName("language")]
    public required string Language { get; set; }

    /// <summary>
    /// The interaction whose context was used to generate this document, if supplied.
    /// </summary>
    [JsonPropertyName("interactionId")]
    public string? InteractionId { get; set; }

    [JsonPropertyName("stringDocument")]
    public Dictionary<string, string> StringDocument { get; set; } =
        new Dictionary<string, string>();

    [JsonPropertyName("structuredDocument")]
    public Dictionary<string, object?>? StructuredDocument { get; set; }

    /// <summary>
    /// Key/value labels attached to this document.
    /// </summary>
    [JsonPropertyName("labels")]
    public IEnumerable<GuidedLabel> Labels { get; set; } = new List<GuidedLabel>();

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
