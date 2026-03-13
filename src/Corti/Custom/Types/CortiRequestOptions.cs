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
}
