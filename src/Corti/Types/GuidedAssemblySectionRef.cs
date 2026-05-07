using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// Per-section reference for the assembly path.
/// </summary>
[Serializable]
public record GuidedAssemblySectionRef : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("sectionId")]
    public required string SectionId { get; set; }

    /// <summary>
    /// Optional explicit section version. Defaults to the section's published version when omitted.
    /// </summary>
    [JsonPropertyName("sectionVersionId")]
    public string? SectionVersionId { get; set; }

    [JsonPropertyName("overrides")]
    public SectionOverrides? Overrides { get; set; }

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
