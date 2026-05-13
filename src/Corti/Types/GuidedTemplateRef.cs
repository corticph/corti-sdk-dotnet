using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record GuidedTemplateRef : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The UUID of a stored template.
    /// </summary>
    [JsonPropertyName("templateId")]
    public required string TemplateId { get; set; }

    /// <summary>
    /// Optional explicit template version. Defaults to the template's published version when omitted.
    /// </summary>
    [JsonPropertyName("templateVersionId")]
    public string? TemplateVersionId { get; set; }

    /// <summary>
    /// Runtime overrides applied on top of the resolved template. When present, a new auto-generated template is persisted with `inheritedFromId` pointing at the base template.
    /// </summary>
    [JsonPropertyName("overrides")]
    public GuidedTemplateOverrides? Overrides { get; set; }

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
