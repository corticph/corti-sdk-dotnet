using Corti;
using Corti.Core;

namespace Corti.Agentic.Agents.A2A;

public partial interface ITasksClient
{
    Task<Pager<CommonTaskResponse>> ListAsync(
        string agentId,
        AgenticAgentsA2ATasksListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<CommonTaskResponse> GetAsync(
        string agentId,
        string taskId,
        AgenticAgentsA2ATasksGetRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<CommonTaskResponse> CancelAsync(
        string agentId,
        string taskId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Resubscribe to an in-flight task's event stream over SSE.
    /// </summary>
    WithRawResponseStream<A2AStreamEventResponse> SubscribeAsync(
        string agentId,
        string taskId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
