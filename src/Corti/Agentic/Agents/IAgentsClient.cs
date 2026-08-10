using Corti;
using Corti.Core;

namespace Corti.Agentic;

public partial interface IAgentsClient
{
    /// <summary>
    /// Lists agents visible to the caller. `private` agents are visible only to
    /// their creator/service principal; `unlisted` agents are omitted (fetch by
    /// ID instead); `public` agents are listed tenant-wide.
    /// The `visibility`, `lifecycle`, `label`, and `q` filter parameters are accepted but not yet honored by the server; the response is unfiltered.
    /// </summary>
    Task<Pager<AgenticAgentsResponse>> ListAsync(
        AgenticAgentsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new agent. The server assigns the UUIDv7 `id`.
    /// </summary>
    WithRawResponseTask<AgenticAgentsResponse> CreateAsync(
        AgenticAgentsCreateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<AgenticAgentsResponse> GetAsync(
        string agentId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a `persistent` agent. `ephemeral` agents are expired in place.
    /// Idempotent: deleting an already-deleted agent returns `204`.
    /// </summary>
    WithRawResponseTask DeleteAsync(
        string agentId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Partially updates an agent using JSON Merge Patch (RFC 7386).
    /// Omitted fields are unchanged; `null` clears a field; arrays replace.
    /// </summary>
    WithRawResponseTask<AgenticAgentsResponse> UpdateAsync(
        string agentId,
        AgenticAgentsPatchRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the A2A v1.0 agent card describing the agent's capabilities,
    /// skills, and supported protocol interfaces. Served at the standard
    /// `.well-known` location for agent discovery.
    /// </summary>
    WithRawResponseTask<AgenticAgentCardResponse> GetCardAsync(
        string agentId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns invocation metrics for the agent over the half-open `[from, to)`
    /// time range (UTC), bucketed at the requested `granularity`. The response
    /// echoes the resolved range and granularity, a `totals` summary across the
    /// whole range, and one `buckets` entry per period that had activity (the
    /// array is empty when there was none). When `from`/`to` are omitted, the
    /// range defaults to the last 30 days.
    /// </summary>
    WithRawResponseTask<AgentsUsageReportResponse> UsageAsync(
        string agentId,
        AgenticAgentsUsageRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
