using Corti;

namespace Corti.Agentic.Agents;

public partial interface IA2AClient
{
    public Corti.Agentic.Agents.A2A.ITasksClient Tasks { get; }

    /// <summary>
    /// The `JSONRPC` protocol binding for A2A v1.0. Accepts a single JSON-RPC 2.0
    /// request whose `method` is one of `SendMessage`, `SendStreamingMessage`,
    /// `GetTask`, `ListTasks`, `CancelTask`, or `SubscribeToTask`.
    ///
    /// Streaming methods (`SendStreamingMessage`, `SubscribeToTask`) respond with
    /// `text/event-stream`; all others respond with a single JSON-RPC response.
    /// </summary>
    WithRawResponseTask<A2AjsonrpcResponse> JsonRpcAsync(
        string agentId,
        A2AjsonrpcRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The `HTTP+JSON` binding of A2A `SendMessage`.
    /// </summary>
    WithRawResponseTask<A2ASendMessageResponse> SendMessageAsync(
        string agentId,
        A2ASendMessageRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The `HTTP+JSON` binding of A2A `SendStreamingMessage`. Responds with a
    /// `text/event-stream` of `Task`, `statusUpdate`, and `artifactUpdate` events.
    /// </summary>
    WithRawResponseStream<A2AStreamEventResponse> StreamMessageAsync(
        string agentId,
        A2ASendMessageRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
