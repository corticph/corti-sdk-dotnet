using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// A context together with its tasks. Returned by `GET /contexts/{id}`.
/// Tasks are ordered oldest first and each carries its full message
/// `history` — the user's prompt for a task is the `ROLE_USER` message
/// within that task's history.
/// </summary>
[Serializable]
public record AgenticContextsDetailResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The context's tasks, oldest first, each with full message history.
    /// </summary>
    [JsonPropertyName("tasks")]
    public IEnumerable<CommonTaskResponse> Tasks { get; set; } = new List<CommonTaskResponse>();

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
