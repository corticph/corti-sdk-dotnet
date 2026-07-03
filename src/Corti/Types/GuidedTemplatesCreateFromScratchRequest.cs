using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Creates a template from scratch. The template fully specifies its own sections and optional template-level instructions.
/// </summary>
[Serializable]
public record GuidedTemplatesCreateFromScratchRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("generation")]
    public required GuidedTemplatesCreateFromScratchRequestGeneration Generation { get; set; }

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
