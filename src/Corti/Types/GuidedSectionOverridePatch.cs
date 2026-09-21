using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Per-section override patch. `generation` is the canonical shape. The flat `heading`, `instructions`, and `outputSchema` fields are deprecated and remain for backward compatibility. Use `generation` instead. If a request sets both `generation` and a flat field for one section, the server rejects it with a 400. Override semantics are per-field for `instructions` and wholesale for `outputSchema`.
/// </summary>
[Serializable]
public record GuidedSectionOverridePatch : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The canonical override patch for this section.
    /// </summary>
    [JsonPropertyName("generation")]
    public GuidedSectionOverrides? Generation { get; set; }

    /// <summary>
    /// **Deprecated** — use `generation.heading`. Replaces the section's heading for this call.
    /// </summary>
    [JsonPropertyName("heading")]
    public string? Heading { get; set; }

    /// <summary>
    /// **Deprecated** — use `generation.instructions`.
    /// </summary>
    [JsonPropertyName("instructions")]
    public GuidedSectionInstructionsOverride? Instructions { get; set; }

    /// <summary>
    /// **Deprecated** — use `generation.outputSchema`.
    /// </summary>
    [JsonPropertyName("outputSchema")]
    public GuidedOutputSchema? OutputSchema { get; set; }

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
