using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record GuidedTemplateOverrides : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Replaces the template-level instructions for this call.
    /// </summary>
    [JsonPropertyName("instructions")]
    public TemplateInstructions? Instructions { get; set; }

    /// <summary>
    /// Per-section override patches. Each entry must reference a section already linked to the base template version.
    /// </summary>
    [JsonPropertyName("sections")]
    public IEnumerable<GuidedSectionOverride>? Sections { get; set; }

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
