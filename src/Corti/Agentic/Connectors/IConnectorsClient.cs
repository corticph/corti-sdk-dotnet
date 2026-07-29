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
}
