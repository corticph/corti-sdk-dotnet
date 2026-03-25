namespace Corti;

/// <summary>
/// Accepts either a <see cref="CortiClientEnvironment"/> or a region string (e.g. "eu", "us") interchangeably,
/// so callers don't need to call <see cref="CortiEnvironments.FromRegion"/> explicitly.
/// </summary>
public readonly struct CortiEnvironmentInput
{
    private readonly CortiClientEnvironment _env;

    private CortiEnvironmentInput(CortiClientEnvironment env) => _env = env;

    public static implicit operator CortiEnvironmentInput(CortiClientEnvironment env) => new(env);
    public static implicit operator CortiEnvironmentInput(string region) => new(CortiEnvironments.FromRegion(region));
    public static implicit operator CortiClientEnvironment(CortiEnvironmentInput input) => input._env;

    public string? Wss => _env.Wss;
}
