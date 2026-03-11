namespace Corti;

public partial class CortiClientEnvironment
{
    /// <summary>
    /// Create a <see cref="CortiClientEnvironment"/> from a region string (e.g. <c>"eu"</c>, <c>"us"</c>).
    /// Equivalent to passing <see cref="CortiClientEnvironment.Eu"/> or <see cref="CortiClientEnvironment.Us"/> directly.
    /// </summary>
    public static CortiClientEnvironment FromRegion(string region) => new()
    {
        Base = $"https://api.{region}.corti.app/v2",
        Wss = $"wss://api.{region}.corti.app/audio-bridge/v2",
        Login = $"https://auth.{region}.corti.app/realms",
        Agents = $"https://api.{region}.corti.app",
    };

    public static implicit operator CortiClientEnvironment(string region) => FromRegion(region);
}
