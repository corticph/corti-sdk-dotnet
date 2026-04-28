using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record Section : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The UUID of the section.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Reference to the section to inherit generation configuration from. Inherits from published version by default.
    /// </summary>
    [JsonPropertyName("inheritedFromId")]
    public string? InheritedFromId { get; set; }

    /// <summary>
    /// The name of the section.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The intended language for outputs as BCP 47 tag.
    /// </summary>
    [JsonPropertyName("language")]
    public required string Language { get; set; }

    /// <summary>
    /// The description for the section.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The labels available to use as query param filter in the LIST /sections endpoint.
    /// </summary>
    [JsonPropertyName("labels")]
    public IEnumerable<string> Labels { get; set; } = new List<string>();

    /// <summary>
    /// Shows the currently published version of this section.
    /// </summary>
    [JsonPropertyName("publishedVersion")]
    public SectionVersion? PublishedVersion { get; set; }

    /// <summary>
    /// The original timestamp when the section was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The original timestamp when the section was last updated.
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public required DateTime UpdatedAt { get; set; }

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
