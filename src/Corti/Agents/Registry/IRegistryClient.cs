using Corti;
using Corti.Core;

namespace Corti.Agents;

public partial interface IRegistryClient
{
    Task<Pager<RegistryConnectorResponse>> ListAsync(
        ListRegistryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<RegistryConnectorResponse> GetAsync(
        string connectorId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
