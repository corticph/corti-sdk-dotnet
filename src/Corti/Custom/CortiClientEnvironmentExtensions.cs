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

    /// <summary>
    /// Create a <see cref="CortiClientEnvironment"/> where all endpoints point to a single base URL.
    /// Useful for proxy or custom-host scenarios. The WebSocket URL is derived automatically by
    /// replacing the <c>https</c>/<c>http</c> scheme with <c>wss</c>/<c>ws</c>.
    /// </summary>
    public static CortiClientEnvironment FromBaseUrl(string baseUrl) => new()
    {
        Base   = baseUrl,
        Wss    = System.Text.RegularExpressions.Regex.Replace(
                     baseUrl,
                     @"^https?",
                     m => m.Value == "https" ? "wss" : "ws"),
        Login  = baseUrl,
        Agents = baseUrl,
    };
}
