using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Template generation with section references (not fully resolved). Use the resolved GuidedTemplateGeneration for hydrated section data.
/// </summary>
[Serializable]
public record GuidedShallowTemplateGeneration : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("instructions")]
    public required GuidedTemplateInstructions Instructions { get; set; }

    /// <summary>
    /// Section references linked to this version (not fully resolved).
    /// </summary>
    [JsonPropertyName("sections")]
    public IEnumerable<GuidedTemplateVersionSectionRef> Sections { get; set; } =
        new List<GuidedTemplateVersionSectionRef>();

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
