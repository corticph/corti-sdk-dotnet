using System.Text.Json.Serialization;
using Corti;
using Corti.Core;

namespace Corti.Documents;

[Serializable]
public record GuidedTemplatesUpdateRequest
{
    /// <summary>
    /// The name of this template. Not passed to the LLM.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

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
    public IEnumerable<Label>? Labels { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
