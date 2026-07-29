using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Lightweight context metadata, as returned in list responses. Contexts are not first-class CRUD resources: there is no explicit create or update endpoint — a context is created implicitly on the first message send (or reused by client-supplied contextId), and list is not yet implemented.
/// </summary>
[Serializable]
public record Contexts : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("agentId")]
    public string? AgentId { get; set; }

    /// <summary>
    /// Total number of tasks in the context.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("taskCount")]
    public int? TaskCount { get; set; }

    /// <summary>
    /// When the context was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// When the context was last updated.
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// When the context expires; `null` means it does not expire. Not yet implemented — the server always returns `null` and performs no TTL-based cleanup.
    /// </summary>
    [JsonPropertyName("expiresAt")]
    public DateTime? ExpiresAt { get; set; }

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
