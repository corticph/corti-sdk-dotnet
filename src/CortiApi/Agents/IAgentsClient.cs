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

    /// <summary>
    /// This endpoint retrieves the agent card in JSON format, which provides metadata about the agent, including its name, description, and the experts it can call.
    /// </summary>
    WithRawResponseTask<AgentsAgentCard> GetCardAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint sends a message to the specified agent to start or continue a task. The agent processes the message and returns a response. If the message contains a task ID that matches an ongoing task, the agent will continue that task; otherwise, it will start a new task.
    /// </summary>
    WithRawResponseTask<AgentsMessageSendResponse> MessageSendAsync(
        string id,
        AgentsMessageSendParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint retrieves the status and details of a specific task associated with the given agent. It provides information about the task's current state, history, and any artifacts produced during its execution.
    /// </summary>
    WithRawResponseTask<AgentsTask> GetTaskAsync(
        string id,
        string taskId,
        AgentsGetTaskRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint retrieves all tasks and top-level messages associated with a specific context for the given agent.
    /// </summary>
    WithRawResponseTask<AgentsContext> GetContextAsync(
        string id,
        string contextId,
        AgentsGetContextRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint retrieves the experts registry, which contains information about all available experts that can be referenced when creating agents through the AgentsCreateExpertReference schema.
    /// </summary>
    WithRawResponseTask<AgentsRegistryExpertsResponse> GetRegistryExpertsAsync(
        AgentsGetRegistryExpertsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
