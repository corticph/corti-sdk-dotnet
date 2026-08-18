using Corti;

namespace Corti.Agentic.Agents;

public partial interface IConnectorsClient
{
    WithRawResponseTask<AgenticConnectorsListResponse> ListAsync(
        string agentId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<CommonConnectorResponse> CreateAsync(
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

    WithRawResponseTask DeleteAsync(
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
        AgenticConnectorsPatchRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
