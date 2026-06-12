using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Creates a section from scratch with an explicit generation configuration. All required fields on `generation` apply.
/// </summary>
[Serializable]
public record GuidedSectionsCreateFromScratchRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("generation")]
    public required GuidedSectionGeneration Generation { get; set; }

    /// <summary>
    /// A human-readable identifier for this section. Not passed to the LLM.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// A description for this section. Not passed to the LLM.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// BCP 47 language tags this section has been tweaked for.
    /// </summary>
    [JsonPropertyName("languages")]
    public IEnumerable<string>? Languages { get; set; }

    /// <summary>
    /// ISO 3166-1 alpha-3 country codes this section has been tweaked for.
    /// </summary>
    [JsonPropertyName("regions")]
    public IEnumerable<string>? Regions { get; set; }

    /// <summary>
    /// Clinical specialties this section has been tweaked for.
    /// </summary>
    [JsonPropertyName("specialties")]
    public IEnumerable<string>? Specialties { get; set; }

    /// <summary>
    /// Labels work as query param filter in the LIST /sections endpoint.
    /// </summary>
    [JsonPropertyName("labels")]
    public IEnumerable<GuidedLabel>? Labels { get; set; }

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
