using Corti;

namespace Corti.Agentic;

public partial interface IRegistryClient
{
    WithRawResponseTask<RegistryConnectorListResponse> ListAsync(
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
