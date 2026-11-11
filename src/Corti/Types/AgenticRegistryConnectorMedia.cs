using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Presentation media for a registry connector. URLs point at assets hosted in the external CMS.
/// </summary>
[Serializable]
public record AgenticRegistryConnectorMedia : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Icon URL (external CMS).
    /// </summary>
    [JsonPropertyName("icon")]
    public string? Icon { get; set; }

    /// <summary>
    /// Cover image URL (external CMS).
    /// </summary>
    [JsonPropertyName("cover")]
    public string? Cover { get; set; }

    /// <summary>
    /// Animation URL (external CMS).
    /// </summary>
    [JsonPropertyName("animation")]
    public string? Animation { get; set; }

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
