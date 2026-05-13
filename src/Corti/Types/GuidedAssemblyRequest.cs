using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// Compose a template by referencing existing stored sections in declaration order.
/// </summary>
[Serializable]
public record GuidedAssemblyRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Name for the auto-generated template aggregate that will be persisted.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// BCP 47 language tag.
    /// </summary>
    [JsonPropertyName("language")]
    public required string Language { get; set; }

    /// <summary>
    /// Template-level instructions for the assembled template.
    /// </summary>
    [JsonPropertyName("instructions")]
    public TemplateInstructions? Instructions { get; set; }

    [JsonPropertyName("sectionRefs")]
    public IEnumerable<GuidedAssemblySectionRef> SectionRefs { get; set; } =
        new List<GuidedAssemblySectionRef>();

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
