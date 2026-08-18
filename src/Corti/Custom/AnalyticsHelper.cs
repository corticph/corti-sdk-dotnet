using global::System.Text.Encodings.Web;
using global::System.Text.Json;

namespace Corti;

/// <summary>
/// Helpers for parsing and serialising <c>x-corti-analytics</c> payloads.
/// <c>sdk_version</c> and <c>sdk_type</c> are reserved and always set by the SDK.
/// </summary>
internal static class AnalyticsHelper
{
    public const string XCortiAnalytics = "x-corti-analytics";

    private static readonly JsonSerializerOptions AnalyticsJsonOptions = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        WriteIndented = false,
    };

    public static Dictionary<string, object>? ParseAnalytics(object? value)
    {
        var parsed = value;

        if (parsed is string json)
        {
            try
            {
                parsed = JsonSerializer.Deserialize<Dictionary<string, object>>(
                    json,
                    AnalyticsJsonOptions
                );
            }
            catch
            {
                return null;
            }
        }
        else if (parsed is JsonElement element)
        {
            if (element.ValueKind != JsonValueKind.Object)
            {
                return null;
            }

            try
            {
                parsed = JsonSerializer.Deserialize<Dictionary<string, object>>(
                    element.GetRawText(),
                    AnalyticsJsonOptions
                );
            }
            catch
            {
                return null;
            }
        }

        if (parsed is Dictionary<string, object> objectDict)
        {
            return new Dictionary<string, object>(objectDict, StringComparer.Ordinal);
        }

        return null;
    }

    public static Dictionary<string, string> WithAnalytics(
        IReadOnlyDictionary<string, string>? analytics,
        IEnumerable<KeyValuePair<string, string>>? record = null
    )
    {
        Dictionary<string, string>? extra = null;
        if (record is not null)
        {
            extra = new Dictionary<string, string>(StringComparer.Ordinal);
            foreach (var kvp in record)
            {
                extra[kvp.Key] = kvp.Value;
            }
        }

        Dictionary<string, object>? overlay = null;
        if (extra is not null)
        {
            foreach (var kvp in extra)
            {
                if (kvp.Key.Equals(XCortiAnalytics, StringComparison.OrdinalIgnoreCase))
                {
                    overlay = ParseAnalytics(kvp.Value);
                    break;
                }
            }
        }

        var payload = new Dictionary<string, object>(StringComparer.Ordinal);
        if (analytics is not null)
        {
            foreach (var kvp in analytics)
            {
                payload[kvp.Key] = kvp.Value;
            }
        }
        if (overlay is not null)
        {
            foreach (var kvp in overlay)
            {
                payload[kvp.Key] = kvp.Value;
            }
        }
        payload["sdk_version"] = Version.Current;
        payload["sdk_type"] = "corti-sdk-dotnet";

        var result = new Dictionary<string, string>(StringComparer.Ordinal);
        if (extra is not null)
        {
            foreach (var kvp in extra)
            {
                if (kvp.Key.Equals(XCortiAnalytics, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                result[kvp.Key] = kvp.Value;
            }
        }
        result[XCortiAnalytics] = JsonSerializer.Serialize(payload, AnalyticsJsonOptions);
        return result;
    }
}
