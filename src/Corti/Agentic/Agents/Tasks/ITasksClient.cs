using Corti;
using Corti.Core;

namespace Corti.Agentic.Agents;

public partial interface ITasksClient
{
    Task<Pager<CommonTaskResponse>> ListAsync(
        string agentId,
        AgenticAgentsTasksListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<CommonTaskResponse> GetAsync(
        string agentId,
        string taskId,
        AgenticAgentsTasksGetRequest request,
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
    WithRawResponseStream<AgenticAgentsStreamEventResponse> SubscribeAsync(
        string agentId,
        string taskId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
