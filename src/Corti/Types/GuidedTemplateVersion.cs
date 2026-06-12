using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Template version with fully resolved (inherited) values. Template-level and section-level
/// inheritance chains are walked. Used in Template.publishedVersion
/// on resource-level endpoints (GET/POST template).
/// </summary>
[Serializable]
public record GuidedTemplateVersion : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The UUID of the version.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Starts at 0 and auto-increments.
    /// </summary>
    [JsonPropertyName("versionNumber")]
    public required int VersionNumber { get; set; }

    /// <summary>
    /// Present when the template version has been deleted.
    /// </summary>
    [JsonPropertyName("deletedAt")]
    public DateTime? DeletedAt { get; set; }

    [JsonPropertyName("generation")]
    public required GuidedTemplateGeneration Generation { get; set; }

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
