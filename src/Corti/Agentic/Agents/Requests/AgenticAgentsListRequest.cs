using Corti;
using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti.Agentic;

[Serializable]
public record AgenticAgentsListRequest
{
    /// <summary>
    /// Maximum number of items per page.
    /// </summary>
    [JsonIgnore]
    public int? PageSize { get; set; }

    /// <summary>
    /// Opaque cursor from a prior response's `nextPageToken`. Omit on the first request.
    /// </summary>
    [JsonIgnore]
    public string? PageToken { get; set; }

    /// <summary>
    /// Filter by one or more visibility levels.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<AgentsVisibility> Visibility { get; set; } = new List<AgentsVisibility>();

    /// <summary>
    /// Filter by lifecycle.
    /// </summary>
    [JsonIgnore]
    public AgentsLifecycle? Lifecycle { get; set; }

    /// <summary>
    /// Filter by label equality, repeated `key=value` pairs (AND-combined).
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Label { get; set; } = new List<string>();

    /// <summary>
    /// Free-text search over `name` and `description`.
    /// </summary>
    [JsonIgnore]
    public string? Q { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
