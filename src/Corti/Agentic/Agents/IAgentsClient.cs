using Corti;
using Corti.Core;

namespace Corti.Agentic;

public partial interface IAgentsClient
{
    /// <summary>
    /// Lists agents visible to the caller. `private` agents are visible only to
    /// their creator/service principal; `unlisted` agents are omitted (fetch by
    /// ID instead); `public` agents are listed tenant-wide.
    /// The `visibility`, `lifecycle`, `label`, and `q` filter parameters are accepted but not yet honored by the server; the response is unfiltered.
    /// </summary>
    Task<Pager<AgenticAgentsResponse>> ListAsync(
        AgenticAgentsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
