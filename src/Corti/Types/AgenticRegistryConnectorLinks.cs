using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Outbound links for a registry connector.
/// </summary>
[Serializable]
public record AgenticRegistryConnectorLinks : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Documentation URL.
    /// </summary>
    [JsonPropertyName("documentation")]
    public string? Documentation { get; set; }

    /// <summary>
    /// Website URL.
    /// </summary>
    [JsonPropertyName("website")]
    public string? Website { get; set; }

    /// <summary>
    /// Introduction or demo video URL.
    /// </summary>
    [JsonPropertyName("video")]
    public string? Video { get; set; }

    /// <summary>
    /// License URL.
    /// </summary>
    [JsonPropertyName("license")]
    public string? License { get; set; }

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
