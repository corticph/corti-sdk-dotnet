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

    [JsonPropertyName("generation")]
    public SectionOverrides? Generation { get; set; }

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
