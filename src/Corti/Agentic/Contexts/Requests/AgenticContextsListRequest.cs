using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti.Agentic;

[Serializable]
public record AgenticContextsListRequest
{
    /// <summary>
    /// Restrict to contexts owned by this agent.
    /// </summary>
    [JsonIgnore]
    public string? AgentId { get; set; }

    /// <summary>
    /// Inclusive lower bound on `createdAt` (RFC 3339).
    /// </summary>
    [JsonIgnore]
    public DateTime? From { get; set; }

    /// <summary>
    /// Exclusive upper bound on `createdAt` (RFC 3339).
    /// </summary>
    [JsonIgnore]
    public DateTime? To { get; set; }

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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
