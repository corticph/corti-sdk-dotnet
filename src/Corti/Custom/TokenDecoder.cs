using System.Text.Json;
using System.Text.RegularExpressions;

namespace Corti;

internal static class TokenDecoder
{
    internal record DecodedToken(string Environment, string TenantName, string AccessToken, long? ExpiresAt);

    internal static DecodedToken? Decode(string? token)
    {
        var parts = token?.Split('.');
        if (parts?.Length < 2) return null;

        var base64 = parts![1].Replace('-', '+').Replace('_', '/');
        base64 = base64.PadRight(base64.Length + (4 - base64.Length % 4) % 4, '=');

        byte[] bytes;
        try { bytes = Convert.FromBase64String(base64); }
        catch { return null; }

        using var doc = JsonDocument.Parse(bytes);
        var root = doc.RootElement;

        if (!root.TryGetProperty("iss", out var iss)) return null;
        var issStr = iss.GetString();
        if (string.IsNullOrEmpty(issStr)) return null;

        var match = Regex.Match(issStr, @"^https://(keycloak|auth)\.([^.]+)\.corti\.app/realms/([^/]+)");
        if (!match.Success) return null;

        long? expiresAt = null;
        if (root.TryGetProperty("exp", out var exp) && exp.ValueKind == JsonValueKind.Number)
            expiresAt = exp.GetInt64();

        return new DecodedToken(match.Groups[2].Value, match.Groups[3].Value, token!, expiresAt);
    }
}
