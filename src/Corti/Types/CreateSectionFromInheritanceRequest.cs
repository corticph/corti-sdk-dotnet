using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// Creates a section that inherits from another section. Any fields omitted in `generation` are inherited from the referenced section's published version; any fields provided override the inherited values.
/// </summary>
[Serializable]
public record CreateSectionFromInheritanceRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Reference to the section to inherit generation configuration from. Inherits from the published version of the referenced section.
    /// </summary>
    [JsonPropertyName("inheritFromId")]
    public required string InheritFromId { get; set; }

    [JsonPropertyName("generation")]
    public required SectionGenerationPartial Generation { get; set; }

    /// <summary>
    /// A human-readable identifier for this section. Not passed to the LLM.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The intended language for outputs as BCP 47 tag. Informational metadata only. The final output language is determined by outputLanguage in the POST /documents request.
    /// </summary>
    [JsonPropertyName("language")]
    public required string Language { get; set; }

    /// <summary>
    /// A description for this section. Not passed to the LLM.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Labels work as query param filter in the LIST /sections endpoint.
    /// </summary>
    [JsonPropertyName("labels")]
    public IEnumerable<string>? Labels { get; set; }

    /// <summary>
    /// Defaults to true when omitted. Set this to false if you do not want the section to automatically show up in LIST /sections.
    /// </summary>
    [JsonPropertyName("publish")]
    public bool? Publish { get; set; }

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
