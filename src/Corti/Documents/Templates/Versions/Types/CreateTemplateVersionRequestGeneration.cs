using System.Text.Json;
using System.Text.Json.Serialization;
using Corti;
using Corti.Core;

namespace Corti.Documents.Templates;

/// <summary>
/// When the template inherits from another template, all inner fields are optional. Any field omitted is inherited from the parent's published version.
/// </summary>
[Serializable]
public record CreateTemplateVersionRequestGeneration : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("instructions")]
    public TemplateInstructionsPartial? Instructions { get; set; }

    [JsonPropertyName("sections")]
    public IEnumerable<TemplateVersionSectionRequest>? Sections { get; set; }

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
