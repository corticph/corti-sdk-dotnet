using Corti;
using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti.Documents;

[Serializable]
public record GuidedSectionsUpdateRequest
{
    /// <summary>
    /// A human-readable identifier for this section. Not passed to the LLM.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
