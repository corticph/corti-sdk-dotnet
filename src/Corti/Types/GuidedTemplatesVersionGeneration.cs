using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// When the template inherits from another template, all inner fields are optional. Any field omitted is inherited from the parent's published version.
/// </summary>
[Serializable]
public record GuidedTemplatesVersionGeneration : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("instructions")]
    public GuidedTemplateInstructionsPartial? Instructions { get; set; }

    [JsonPropertyName("sections")]
    public IEnumerable<GuidedTemplatesVersionSectionRequest>? Sections { get; set; }

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
