using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// Creates a template from scratch. `generation.instructions` is required and the template fully specifies its own instructions and sections.
/// </summary>
[Serializable]
public record CreateTemplateFromScratchRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("generation")]
    public required CreateTemplateFromScratchRequestGeneration Generation { get; set; }

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
    /// The intended language for outputs as BCP 47 tag. Informational metadata only. The final output language is determined by outputLanguage in the POST /documents request.
    /// </summary>
    [JsonPropertyName("language")]
    public required string Language { get; set; }

    /// <summary>
    /// Labels work as query param filter in the LIST /templates endpoint.
    /// </summary>
    [JsonPropertyName("labels")]
    public IEnumerable<string>? Labels { get; set; }

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
