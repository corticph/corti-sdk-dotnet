using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Templates whose generation output changes when this section changes.
/// </summary>
[Serializable]
public record GuidedSectionImpactTemplates : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// True when the group does not hold all the templates. The 50-entry display cap or the inheritance depth cap can cause this.
    /// </summary>
    [JsonPropertyName("truncated")]
    public required bool Truncated { get; set; }

    /// <summary>
    /// The templates that the change can affect. Holds at most 50 entries.
    /// </summary>
    [JsonPropertyName("items")]
    public IEnumerable<GuidedSectionImpactTemplateItem> Items { get; set; } =
        new List<GuidedSectionImpactTemplateItem>();

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
