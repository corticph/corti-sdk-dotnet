using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// Template version with raw authored values — no inheritance resolution applied.
/// Sections are returned as references (IDs), not fully resolved objects.
/// Use this to inspect what was explicitly set on this version versus inherited.
/// Returned by GET, LIST, and POST version endpoints.
/// </summary>
[Serializable]
public record ShallowTemplateVersionResponse : IJsonOnDeserialized
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
    public required ShallowTemplateGeneration Generation { get; set; }

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
