using Corti;

namespace Corti.Agentic;

public partial interface IModelsClient
{
    /// <summary>
    /// Returns the list of LLM models available on the gateway. The list is
    /// cached at server startup and refreshed periodically; it may lag briefly
    /// behind the gateway's actual model catalog.
    /// </summary>
    WithRawResponseTask<ModelsListResponse> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
