using Corti;

namespace Corti.Agentic.Contexts.Tasks;

public partial interface IArtifactsClient
{
    /// <summary>
    /// Returns an artifact produced by a task within a context. File parts may
    /// carry inline `bytes` or a `uri` to fetch the content out of band.
    /// </summary>
    WithRawResponseTask<CommonArtifactResponse> GetAsync(
        string contextId,
        string taskId,
        string artifactId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
