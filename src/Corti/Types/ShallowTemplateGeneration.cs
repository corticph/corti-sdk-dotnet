using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// Template generation with section references (not fully resolved). Use the resolved TemplateGeneration for hydrated section data.
/// </summary>
[Serializable]
public record ShallowTemplateGeneration : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("instructions")]
    public required TemplateInstructions Instructions { get; set; }

    /// <summary>
    /// Section references linked to this version (not fully resolved).
    /// </summary>
    [JsonPropertyName("sections")]
    public IEnumerable<TemplateVersionSectionRef> Sections { get; set; } =
        new List<TemplateVersionSectionRef>();

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
