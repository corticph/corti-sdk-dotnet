using Corti;

namespace Corti.Agents;

public partial interface IUsageClient
{
    /// <summary>
    /// Returns invocation metrics for the agent over the half-open `[from, to)`
    /// time range (UTC), bucketed at the requested `granularity`. The response
    /// echoes the resolved range and granularity, a `totals` summary across the
    /// whole range, and one `buckets` entry per period that had activity (the
    /// array is empty when there was none). When `from`/`to` are omitted, the
    /// range defaults to the last 30 days.
    /// </summary>
    WithRawResponseTask<UsageReportResponse> GetAsync(
        string agentId,
        GetUsageRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
