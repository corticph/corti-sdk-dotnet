using System.Text.Json;
using System.Text.Json.Serialization;
using Corti;
using Corti.Core;

namespace Corti.Documents.Templates;

[Serializable]
public record CreateTemplateVersionRequestGeneration : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("instructions")]
    public required TemplateInstructions Instructions { get; set; }

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
