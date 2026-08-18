namespace Corti;

/// <summary>
/// Optional request overrides for CortiClient (no environment — that is set on CortiClientOptions).
/// Used to build ClientOptions internally.
/// </summary>
public class CortiRequestOptions
{
    /// <summary>HttpClient to use. If null, a default is used.</summary>
    public HttpClient? HttpClient { get; init; }

    /// <summary>Max number of retries. If null, default (2) is used.</summary>
    public int? MaxRetries { get; init; }

    /// <summary>Request timeout. If null, default (30s) is used.</summary>
    public TimeSpan? Timeout { get; init; }

    /// <summary>Additional headers. If null, none.</summary>
    public IEnumerable<KeyValuePair<string, string?>>? AdditionalHeaders { get; init; }

    /// <summary>
    /// Additional call-site metadata merged into the <c>x-corti-analytics</c> payload on every
    /// request. <c>sdk_version</c> and <c>sdk_type</c> are reserved and always set by the SDK.
    /// </summary>
    public Dictionary<string, string>? Analytics { get; init; }
}
