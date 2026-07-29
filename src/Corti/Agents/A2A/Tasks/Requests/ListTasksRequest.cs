using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti.Agents.A2A;

[Serializable]
public record ListTasksRequest
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
    /// Restrict to tasks within this context.
    /// </summary>
    [JsonIgnore]
    public string? ContextId { get; set; }

    /// <summary>
    /// A2A protocol version in `Major.Minor` form (A2A §3.6). Optional; defaults to `1.0` when absent. This surface implements `1.0` only. Patch versions MUST NOT be sent and are not considered during negotiation.
    /// </summary>
    [JsonIgnore]
    public string A2AVersion { get; set; } = "1.0";

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
