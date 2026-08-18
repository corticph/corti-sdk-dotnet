using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// An icon resource, following the MCP `Icon` shape.
/// </summary>
[Serializable]
public record AgenticRegistryIcon : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Icon source URL.
    /// </summary>
    [JsonPropertyName("src")]
    public required string Src { get; set; }

    /// <summary>
    /// MIME type of the icon resource.
    /// </summary>
    [JsonPropertyName("mimeType")]
    public string? MimeType { get; set; }

    /// <summary>
    /// `WxH` size hints (e.g. `48x48`), or `any` for scalable icons.
    /// </summary>
    [JsonPropertyName("sizes")]
    public IEnumerable<string>? Sizes { get; set; }

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
