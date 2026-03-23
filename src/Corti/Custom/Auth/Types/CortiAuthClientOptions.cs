namespace Corti;

/// <summary>
/// Options for creating a CustomAuthClient (tenant + environment only; no auth — credentials are passed to GetTokenAsync).
/// Same shape as CortiClientOptions but without Auth.
/// </summary>
public class CortiAuthClientOptions
{
    /// <summary>Tenant name (used for Tenant-Name header and token endpoint).</summary>
    public required string TenantName { get; init; }

    /// <summary>Environment (us/eu) — determines base URLs.</summary>
    public required CortiClientEnvironment Environment { get; init; }

    /// <summary>Optional. Request overrides (timeout, retries, HttpClient, etc.). If null, defaults are used.</summary>
    public CortiRequestOptions? RequestOptions { get; init; }
}
