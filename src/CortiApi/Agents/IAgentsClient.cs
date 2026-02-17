namespace CortiApi;

public partial interface IAgentsClient
{
    /// <summary>
    /// This endpoint retrieves a list of all agents that can be called by the Corti Agent Framework.
    /// </summary>
    WithRawResponseTask<IEnumerable<AgentsAgentResponse>> ListAsync(
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

    /// <summary>
    /// This endpoint retrieves an agent by its identifier. The agent contains information about its capabilities and the experts it can call.
    /// </summary>
    WithRawResponseTask<AgentsAgentResponse> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint deletes an agent by its identifier. Once deleted, the agent can no longer be used in threads.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint updates an existing agent. Only the fields provided in the request body will be updated; other fields will remain unchanged.
    /// </summary>
    WithRawResponseTask<AgentsAgent> UpdateAsync(
        string id,
        AgentsAgent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
