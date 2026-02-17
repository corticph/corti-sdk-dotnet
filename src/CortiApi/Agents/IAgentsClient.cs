using OneOf;

namespace CortiApi;

public partial interface IAgentsClient
{
    /// <summary>
    /// This endpoint retrieves a list of all agents that can be called by the Corti Agent Framework.
    /// </summary>
    WithRawResponseTask<IEnumerable<OneOf<AgentsAgent, AgentsAgentReference>>> ListAsync(
        AgentsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint allows the creation of a new agent that can be utilized in the `POST /agents/{id}/v1/message:send` endpoint.
    /// </summary>
    WithRawResponseTask<AgentsAgent> CreateAsync(
        AgentsCreateAgent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
