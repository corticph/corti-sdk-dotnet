using Corti;

namespace Corti.Agentic.Contexts.Tasks;

public partial interface IFeedbackClient
{
    /// <summary>
    /// Returns all feedback resources submitted for the task by the authenticated user, newest-first. The task must exist, belong to the supplied context, and belong to the authenticated customer. Feedback is scoped to the calling user via row-level security, so the response contains only that user's feedback.
    /// </summary>
    WithRawResponseTask<AgenticFeedbackListResponse> ListAsync(
        string contextId,
        string taskId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Submits feedback about a task as a whole or about a specific user-visible
    /// message within the task. The task must exist, belong to the supplied
    /// context, and belong to the authenticated customer. Multiple feedback
    /// resources may be submitted for the same task or message.
    /// </summary>
    WithRawResponseTask<AgenticFeedbackResponse> CreateAsync(
        string contextId,
        string taskId,
        AgenticFeedbackCreateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Soft-deletes a single feedback resource the authenticated user submitted for the task. The task must exist, belong to the supplied context, and belong to the authenticated customer. Idempotent: deleting a feedback resource that does not exist (or has already been deleted) returns `204`.
    /// </summary>
    WithRawResponseTask DeleteAsync(
        string contextId,
        string taskId,
        string feedbackId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
