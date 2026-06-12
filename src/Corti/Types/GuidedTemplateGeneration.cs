using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Fully resolved template generation. Sections are expanded with their own inheritance applied.
/// </summary>
[Serializable]
public record GuidedTemplateGeneration : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("instructions")]
    public required GuidedTemplateInstructions Instructions { get; set; }

    /// <summary>
    /// Fully resolved sections with inheritance applied.
    /// </summary>
    [JsonPropertyName("sections")]
    public IEnumerable<GuidedSection>? Sections { get; set; }

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
