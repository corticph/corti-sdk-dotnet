using Corti;
using Corti.Core;

namespace Corti.Agents;

public partial interface IContextsClient
{
    public Corti.Agents.Contexts.ITasksClient Tasks { get; }

    /// <summary>
    /// Returns the context's metadata together with its `tasks`, oldest first.
    /// Each task carries its full message `history`; the user's prompt for a
    /// task is the `ROLE_USER` message within that task's history (there is no
    /// separate top-level message list).
    /// </summary>
    WithRawResponseTask<ContextsDetailResponse> GetAsync(
        string contextId,
        GetContextsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask DeleteAsync(
        string contextId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the execution traces for the context — LLM calls, tool
    /// executions, and token usage — in OpenInference format. Traces are
    /// ordered newest-first and paginated; each page returns up to `pageSize`
    /// traces with their spans inlined.
    /// </summary>
    Task<Pager<ContextsTraceItem>> GetTraceAsync(
        string contextId,
        GetTraceContextsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
