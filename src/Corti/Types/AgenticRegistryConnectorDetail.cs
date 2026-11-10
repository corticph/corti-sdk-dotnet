using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// The full registry connector: the mutable connector record (identity, lifecycle, presentation metadata) plus the immutable per-version configuration records in `versions`, ordered newest first.
/// </summary>
[Serializable]
public record AgenticRegistryConnectorDetail : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Scoped slug `@namespace/name` uniquely identifying the registry connector.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Unscoped connector name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("type")]
    public required CommonConnectorType Type { get; set; }

    /// <summary>
    /// Latest published configuration version.
    /// </summary>
    [JsonPropertyName("latest")]
    public required string Latest { get; set; }

    [JsonPropertyName("status")]
    public required AgenticRegistryConnectorStatus Status { get; set; }

    /// <summary>
    /// Publishing namespace (e.g. `corti`).
    /// </summary>
    [JsonPropertyName("publisher")]
    public string? Publisher { get; set; }

    /// <summary>
    /// Human-readable display name.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// One-line summary for list views.
    /// </summary>
    [JsonPropertyName("summary")]
    public string? Summary { get; set; }

    /// <summary>
    /// Statement of what the connector does once attached to an agent.
    /// </summary>
    [JsonPropertyName("capabilityStatement")]
    public string? CapabilityStatement { get; set; }

    /// <summary>
    /// Full description in CommonMark (rendered by Console).
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Category for filtering (e.g. `literature`).
    /// </summary>
    [JsonPropertyName("category")]
    public string? Category { get; set; }

    /// <summary>
    /// Keywords for search and filtering.
    /// </summary>
    [JsonPropertyName("tags")]
    public IEnumerable<string>? Tags { get; set; }

    [JsonPropertyName("media")]
    public AgenticRegistryConnectorMedia? Media { get; set; }

    [JsonPropertyName("links")]
    public AgenticRegistryConnectorLinks? Links { get; set; }

    /// <summary>
    /// When the connector record was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// When the connector record was last updated.
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Immutable per-version configuration records, ordered newest first.
    /// </summary>
    [JsonPropertyName("versions")]
    public IEnumerable<AgenticRegistryConnectorVersion> Versions { get; set; } =
        new List<AgenticRegistryConnectorVersion>();

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
