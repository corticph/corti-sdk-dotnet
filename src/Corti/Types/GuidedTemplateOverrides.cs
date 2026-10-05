using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Template-level override patch. `generation` is the canonical shape. The flat `instructions` and `sections` fields are deprecated and remain for backward compatibility. Use `generation` instead. If a request sets both `generation` and a flat field, the server rejects it with a 400.
/// </summary>
[Serializable]
public record GuidedTemplateOverrides : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The canonical override wrapper for this template.
    /// </summary>
    [JsonPropertyName("generation")]
    public GuidedTemplateOverridesGeneration? Generation { get; set; }

    /// <summary>
    /// **Deprecated** — use `generation.instructions`. Replaces the template-level instructions for this call.
    /// </summary>
    [JsonPropertyName("instructions")]
    public GuidedTemplateInstructions? Instructions { get; set; }

    /// <summary>
    /// **Deprecated** — use `generation.sections`. Per-section override patches. Each entry must reference a section already linked to the base template version.
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
