using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// A page of registry connector records (list view, without per-version records).
/// </summary>
[Serializable]
public record AgenticRegistryConnectorsListResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Registry connector records on the current page.
    /// </summary>
    [JsonPropertyName("connectors")]
    public IEnumerable<AgenticRegistryConnector> Connectors { get; set; } =
        new List<AgenticRegistryConnector>();

    [JsonPropertyName("nextPageToken")]
    public string? NextPageToken { get; set; }

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
