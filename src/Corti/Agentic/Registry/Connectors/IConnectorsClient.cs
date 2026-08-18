using Corti;
using Corti.Core;

namespace Corti.Agentic.Registry;

public partial interface IConnectorsClient
{
    Task<Pager<AgenticRegistryConnector>> ListAsync(
        AgenticRegistryConnectorsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<AgenticRegistryConnector> GetAsync(
        string connectorId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
