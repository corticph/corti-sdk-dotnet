using Corti;
using Corti.Core;

namespace Corti.Agentic.Registry;

public partial interface IConnectorsClient
{
    /// <summary>
    /// Lists registry connector records (identity, lifecycle, and presentation metadata) with cursor pagination. Per-version configuration records are returned only by the detail endpoint.
    /// </summary>
    Task<Pager<AgenticRegistryConnector>> ListAsync(
        AgenticRegistryConnectorsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the full connector record — identity, lifecycle, and presentation metadata — plus the immutable per-version configuration records in `versions`, ordered newest first. Each version carries its own `configSchema` and `payload` (including `systemPrompt` and bundled MCP server definitions). The latest version is also addressable via the `latest` field.
    /// </summary>
    WithRawResponseTask<AgenticRegistryConnectorDetail> GetAsync(
        string connectorId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
