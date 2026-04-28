using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record TemplateVersion : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("versionNumber")]
    public required int VersionNumber { get; set; }

    [JsonPropertyName("instructions")]
    public required TemplateInstructions Instructions { get; set; }

    /// <summary>
    /// Populated only on GET /new/templates/{id}/versions/{versionID}
    /// </summary>
    [JsonPropertyName("sections")]
    public IEnumerable<Section>? Sections { get; set; }

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
