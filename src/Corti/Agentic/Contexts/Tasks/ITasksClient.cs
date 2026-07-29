using Corti;

namespace Corti.Agentic.Contexts;

public partial interface ITasksClient
{
    WithRawResponseTask<CommonTaskListResponse> ListAsync(
        string contextId,
        ListTasksRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<CommonTaskResponse> GetAsync(
        string contextId,
        string taskId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
