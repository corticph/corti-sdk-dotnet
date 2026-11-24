using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Descendant sections that inherit from this section.
/// </summary>
[Serializable]
public record GuidedSectionImpactSections : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// True when the group does not hold all the descendant sections. The 50-entry display cap or the inheritance depth cap can cause this.
    /// </summary>
    [JsonPropertyName("truncated")]
    public required bool Truncated { get; set; }

    /// <summary>
    /// The descendant sections. Holds at most 50 entries.
    /// </summary>
    [JsonPropertyName("items")]
    public IEnumerable<GuidedSectionImpactSectionItem> Items { get; set; } =
        new List<GuidedSectionImpactSectionItem>();

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
