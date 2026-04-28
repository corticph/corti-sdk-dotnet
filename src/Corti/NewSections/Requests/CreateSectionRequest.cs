using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record CreateSectionRequest
{
    /// <summary>
    /// A human-readable identifier for this section. Not passed to the LLM.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The intended language for outputs as BCP 47 tag. Does not strictly have to match outputLanguage in POST /documents request.
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
    /// Reference to the section to inherit instructions and outputSchema from. Inherits from published version unless fields are changed or overridden in the POST /documents request.
    /// </summary>
    [JsonPropertyName("inheritFromId")]
    public string? InheritFromId { get; set; }

    [JsonPropertyName("generation")]
    public required CreateSectionVersionRequest Generation { get; set; }

    /// <summary>
    /// Defaults to true when omitted. Set this to false if you do not want the section to automatically show up in LIST /sections.
    /// </summary>
    [JsonPropertyName("publish")]
    public bool? Publish { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
