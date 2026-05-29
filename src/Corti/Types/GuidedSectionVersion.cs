using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// A section version. When embedded inside a Section resource (e.g. GET /sections/:id),
/// inheritance is fully resolved. When returned directly from version endpoints
/// (GET/LIST/POST .../versions/...), contains raw authored values without inheritance.
/// </summary>
[Serializable]
public record GuidedSectionVersion : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The UUID of the section version.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Starts at 0 and auto-increments.
    /// </summary>
    [JsonPropertyName("versionNumber")]
    public required int VersionNumber { get; set; }

    /// <summary>
    /// Present when the section version has been deleted.
    /// </summary>
    [JsonPropertyName("deletedAt")]
    public DateTime? DeletedAt { get; set; }

    [JsonPropertyName("generation")]
    public required GuidedSectionGeneration Generation { get; set; }

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
