using Corti;

namespace Corti.Agentic;

public partial interface IConnectorsClient
{
    WithRawResponseTask<ConnectorsListResponse> ListAsync(
        string agentId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<CommonConnectorResponse> AttachAsync(
        string agentId,
        CommonConnectorCreateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<CommonConnectorResponse> GetAsync(
        string agentId,
        string agentConnectorId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask RemoveAsync(
        string agentId,
        string agentConnectorId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Partially updates an agent-scoped connector using JSON Merge Patch
    /// (RFC 7386). `type` is immutable.
    /// **Future scope**:  not yet implemented; the server returns `501`.
    /// </summary>
    WithRawResponseTask<CommonConnectorResponse> UpdateAsync(
        string agentId,
        string agentConnectorId,
        ConnectorsPatchRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
