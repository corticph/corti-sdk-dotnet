using Corti.Core;

namespace Corti;

public partial interface IAgenticClient
{
    /// <summary>
    /// Lists agents visible to the caller. `private` agents are visible only to
    /// their creator/service principal; `unlisted` agents are omitted (fetch by
    /// ID instead); `public` agents are listed tenant-wide.
    /// The `visibility`, `lifecycle`, `label`, and `q` filter parameters are accepted but not yet honored by the server; the response is unfiltered.
    /// </summary>
    Task<Pager<AgentsResponse>> ListAsync(
        ListAgenticRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
