using Corti;
using Corti.Agentic.Contexts.Tasks;
using Corti.Core;

namespace Corti.Agentic.Contexts;

public partial interface ITasksClient
{
    public IArtifactsClient Artifacts { get; }
    public IFeedbackClient Feedback { get; }
    Task<Pager<CommonTaskResponse>> ListAsync(
        string contextId,
        AgenticContextsTasksListRequest request,
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
