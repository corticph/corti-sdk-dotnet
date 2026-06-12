using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Creates a template that inherits from another template. Any fields omitted in `generation` are inherited from the referenced template's published version; any fields provided override the inherited values.
/// </summary>
[Serializable]
public record GuidedTemplatesCreateFromInheritanceRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Reference to the template to inherit instructions and sections from. Inherits from the published version of the referenced template.
    /// </summary>
    [JsonPropertyName("inheritFromId")]
    public required string InheritFromId { get; set; }

    /// <summary>
    /// Partial overrides applied on top of the inherited template. All inner fields are optional. Any field omitted is inherited from the referenced template.
    /// </summary>
    [JsonPropertyName("generation")]
    public GuidedTemplatesCreateFromInheritanceRequestGeneration? Generation { get; set; }

    /// <summary>
    /// The name of this template. Not passed to the LLM.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// A description for this template. Not passed to the LLM.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// BCP 47 language tags this template has been tweaked for (e.g. `["fr", "de", "en-GB"]`).
    /// </summary>
    [JsonPropertyName("languages")]
    public IEnumerable<string>? Languages { get; set; }

    /// <summary>
    /// ISO 3166-1 alpha-3 country codes this template has been tweaked for (e.g. `["BEL"]`).
    /// </summary>
    [JsonPropertyName("regions")]
    public IEnumerable<string>? Regions { get; set; }

    /// <summary>
    /// Clinical specialties this template has been tweaked for.
    /// </summary>
    [JsonPropertyName("specialties")]
    public IEnumerable<string>? Specialties { get; set; }

    /// <summary>
    /// Labels work as query param filter in the LIST /templates endpoint.
    /// </summary>
    [JsonPropertyName("labels")]
    public IEnumerable<GuidedLabel>? Labels { get; set; }

    /// <summary>
    /// Defaults to true when omitted. Set this to false if you do not want the template to automatically show up in LIST templates.
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
