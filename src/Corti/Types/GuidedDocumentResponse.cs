using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record GuidedDocumentResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The template ID used for generation. For Path 1 (plain `templateRef` with no overrides), this is the referenced template. For other paths, it is the newly saved, auto-generated template aggregate.
    /// </summary>
    [JsonPropertyName("templateId")]
    public required string TemplateId { get; set; }

    /// <summary>
    /// The specific template version that was used for generation.
    /// </summary>
    [JsonPropertyName("templateVersionId")]
    public required string TemplateVersionId { get; set; }

    [JsonPropertyName("result")]
    public required GuidedGenerationResult Result { get; set; }

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
