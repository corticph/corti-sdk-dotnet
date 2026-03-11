namespace Corti;

public class CortiClientOptions
{
    /// <summary>Tenant name (used for Tenant-Name header and token endpoint).</summary>
    public string TenantName { get; init; } = null!;

    /// <summary>Environment (us/eu) — determines base URLs.</summary>
    public CortiClientEnvironment Environment { get; init; } = null!;

    /// <summary>Auth: client credentials.</summary>
    public CortiClientAuth Auth { get; init; } = null!;

    /// <summary>Optional. Request overrides (timeout, retries, HttpClient, etc.). If null, defaults are used. No environment — that is set above.</summary>
    public CortiRequestOptions? RequestOptions { get; init; }
}
