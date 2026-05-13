using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// Override patch applied to a section linked to the base template version. Override semantics are per-field for `instructions` (any field you omit is inherited from the parent's published version) and wholesale for `outputSchema` (whatever you submit fully replaces the parent schema — partial schemas are not merged). The same rule applies when a section is forked via `inheritFromId`.
/// </summary>
[Serializable]
public record GuidedSectionOverride : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The UUID of a section linked to the base template version.
    /// </summary>
    [JsonPropertyName("sectionId")]
    public required string SectionId { get; set; }

    /// <summary>
    /// When provided, replaces the section's title for this call.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("instructions")]
    public SectionInstructionsOverride? Instructions { get; set; }

    /// <summary>
    /// When provided, fully replaces the parent's output schema. Not a partial merge — any submitted value replaces the parent's schema in its entirety.
    /// </summary>
    [JsonPropertyName("outputSchema")]
    public OutputSchema? OutputSchema { get; set; }

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
