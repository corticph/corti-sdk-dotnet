using Corti.Agents;
using Corti.Core;

namespace Corti;

public partial interface IAgentsClient
{
    public IA2AClient A2A { get; }
    public IUsageClient Usage { get; }
    public IConnectorsClient Connectors { get; }
    public IContextsClient Contexts { get; }
    public IArtifactsClient Artifacts { get; }
    public IRegistryClient Registry { get; }
    public IFeedbackClient Feedback { get; }

    /// <summary>
    /// Lists agents visible to the caller. `private` agents are visible only to
    /// their creator/service principal; `unlisted` agents are omitted (fetch by
    /// ID instead); `public` agents are listed tenant-wide.
    /// The `visibility`, `lifecycle`, `label`, and `q` filter parameters are accepted but not yet honored by the server; the response is unfiltered.
    /// </summary>
    Task<Pager<AgentsResponse>> ListAsync(
        ListAgentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new agent. The server assigns the UUIDv7 `id`.
    /// </summary>
    WithRawResponseTask<AgentsResponse> CreateAsync(
        AgentsCreateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<AgentsResponse> GetAsync(
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
    WithRawResponseTask<AgentsResponse> UpdateAsync(
        string agentId,
        AgentsPatchRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the A2A v1.0 agent card describing the agent's capabilities,
    /// skills, and supported protocol interfaces. Served at the standard
    /// `.well-known` location for agent discovery.
    /// </summary>
    WithRawResponseTask<AgentCardResponse> GetCardAsync(
        string agentId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
