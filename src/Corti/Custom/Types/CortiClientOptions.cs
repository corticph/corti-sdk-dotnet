namespace Corti;

/// <summary>Internal bridge type used by CortiClient constructors. Not part of the public API.</summary>
internal class CortiClientOptions
{
    public string? TenantName { get; init; }
    public CortiClientEnvironment Environment { get; init; } = null!;
    public CortiClientAuth? Auth { get; init; }
    public CortiRequestOptions? RequestOptions { get; init; }
}
