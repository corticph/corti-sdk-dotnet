using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record TemplateVersionSectionRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("sectionId")]
    public required string SectionId { get; set; }

    /// <summary>
    /// Can be used to pin the version of a section, else the latest published version is used in the resource.
    /// </summary>
    [JsonPropertyName("pinnedVersionId")]
    public string? PinnedVersionId { get; set; }

    /// <summary>
    /// Sets the order of this section within this template. Starts a 0.
    /// </summary>
    [JsonPropertyName("orderIndex")]
    public int? OrderIndex { get; set; }

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
