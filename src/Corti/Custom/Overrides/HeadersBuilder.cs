using Corti;
using global::System.Text.Json;

namespace Corti.Core;

/// <summary>
/// Patch: x-corti-analytics is deep-merged across Add() layers instead of last-write-wins;
/// reserved sdk_version / sdk_type keys are applied in BuildAsync.
/// </summary>
internal static partial class HeadersBuilder
{
    /// <summary>
    /// Fluent builder for constructing HTTP headers.
    /// </summary>
    public sealed class Builder
    {
        private readonly Dictionary<string, HeaderValue> _headers;
        private Dictionary<string, object>? _analytics;

        /// <summary>
        /// Initializes a new instance with default capacity.
        /// Uses case-insensitive header name comparison.
        /// </summary>
        public Builder()
        {
            _headers = new Dictionary<string, HeaderValue>(StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Initializes a new instance with the specified initial capacity.
        /// Uses case-insensitive header name comparison.
        /// </summary>
        public Builder(int capacity)
        {
            _headers = new Dictionary<string, HeaderValue>(
                capacity,
                StringComparer.OrdinalIgnoreCase
            );
        }

        /// <summary>
        /// Adds a header with the specified key and value.
        /// If a header with the same key already exists, it will be overwritten.
        /// Null values are ignored.
        /// </summary>
        /// <param name="key">The header name.</param>
        /// <param name="value">The header value. Null values are ignored.</param>
        /// <returns>This builder instance for method chaining.</returns>
        public Builder Add(string key, string? value)
        {
            if (value is not null && !TryConsumeAnalytics(key, value))
            {
                _headers[key] = (value);
            }
            return this;
        }

        /// <summary>
        /// Adds a header with the specified key and object value.
        /// The value will be converted to string using ValueConvert for consistent serialization.
        /// If a header with the same key already exists, it will be overwritten.
        /// Null values are ignored.
        /// </summary>
        /// <param name="key">The header name.</param>
        /// <param name="value">The header value. Null values are ignored.</param>
        /// <returns>This builder instance for method chaining.</returns>
        public Builder Add(string key, object? value)
        {
            if (value is null)
            {
                return this;
            }

            if (TryConsumeAnalytics(key, value))
            {
                return this;
            }

            // Use ValueConvert for consistent serialization across headers, query params, and path params
            var stringValue = ValueConvert.ToString(value);
            if (stringValue is not null)
            {
                _headers[key] = (stringValue);
            }
            return this;
        }

        /// <summary>
        /// Adds multiple headers from a Headers dictionary.
        /// HeaderValue instances are stored and will be resolved when BuildAsync() is called.
        /// Overwrites any existing headers with the same key.
        /// Null entries are ignored.
        /// </summary>
        /// <param name="headers">The headers to add. Null is treated as empty.</param>
        /// <returns>This builder instance for method chaining.</returns>
        public Builder Add(Headers? headers)
        {
            if (headers is null)
            {
                return this;
            }

            foreach (var header in headers)
            {
                if (!TryConsumeAnalytics(header.Key, header.Value))
                {
                    _headers[header.Key] = header.Value;
                }
            }

            return this;
        }

        /// <summary>
        /// Adds multiple headers from a Headers dictionary, excluding the Authorization header.
        /// This is useful for endpoints that don't require authentication, to avoid triggering
        /// lazy auth token resolution.
        /// HeaderValue instances are stored and will be resolved when BuildAsync() is called.
        /// Overwrites any existing headers with the same key.
        /// Null entries are ignored.
        /// </summary>
        /// <param name="headers">The headers to add. Null is treated as empty.</param>
        /// <returns>This builder instance for method chaining.</returns>
        public Builder AddWithoutAuth(Headers? headers)
        {
            if (headers is null)
            {
                return this;
            }

            foreach (var header in headers)
            {
                if (header.Key.Equals("Authorization", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                if (!TryConsumeAnalytics(header.Key, header.Value))
                {
                    _headers[header.Key] = header.Value;
                }
            }

            return this;
        }

        /// <summary>
        /// Adds multiple headers from a key-value pair collection.
        /// Overwrites any existing headers with the same key.
        /// Null values are ignored.
        /// </summary>
        /// <param name="headers">The headers to add. Null is treated as empty.</param>
        /// <returns>This builder instance for method chaining.</returns>
        public Builder Add(IEnumerable<KeyValuePair<string, string?>>? headers)
        {
            if (headers is null)
            {
                return this;
            }

            foreach (var header in headers)
            {
                if (header.Value is not null && !TryConsumeAnalytics(header.Key, header.Value))
                {
                    _headers[header.Key] = (header.Value);
                }
            }

            return this;
        }

        /// <summary>
        /// Adds multiple headers from a dictionary.
        /// Overwrites any existing headers with the same key.
        /// </summary>
        /// <param name="headers">The headers to add. Null is treated as empty.</param>
        /// <returns>This builder instance for method chaining.</returns>
        public Builder Add(Dictionary<string, string>? headers)
        {
            if (headers is null)
            {
                return this;
            }

            foreach (var header in headers)
            {
                if (!TryConsumeAnalytics(header.Key, header.Value))
                {
                    _headers[header.Key] = (header.Value);
                }
            }

            return this;
        }

        /// <summary>
        /// Asynchronously builds the final headers dictionary containing all merged headers.
        /// Resolves all HeaderValue instances that may contain async operations.
        /// Returns a case-insensitive dictionary.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, containing a case-insensitive dictionary of headers.</returns>
        public async global::System.Threading.Tasks.Task<Dictionary<string, string>> BuildAsync()
        {
            var headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var kvp in _headers)
            {
                var value = await kvp.Value.ResolveAsync().ConfigureAwait(false);
                if (value is null)
                {
                    continue;
                }

                if (TryConsumeAnalytics(kvp.Key, value))
                {
                    continue;
                }

                headers[kvp.Key] = value;
            }

            if (_analytics is not null)
            {
                var withAnalytics = AnalyticsHelper.WithAnalytics(ToStringDictionary(_analytics));
                headers[AnalyticsHelper.XCortiAnalytics] = withAnalytics[
                    AnalyticsHelper.XCortiAnalytics
                ];
            }

            return headers;
        }

        private bool TryConsumeAnalytics(string key, HeaderValue value)
        {
            if (!IsAnalyticsKey(key))
            {
                return false;
            }

            var resolved = value.ResolveAsync();
            if (!resolved.IsCompleted)
            {
                return false;
            }

            MergeAnalytics(AnalyticsHelper.ParseAnalytics(resolved.GetAwaiter().GetResult()));
            return true;
        }

        private bool TryConsumeAnalytics(string key, object? value)
        {
            if (!IsAnalyticsKey(key))
            {
                return false;
            }

            MergeAnalytics(AnalyticsHelper.ParseAnalytics(value));
            return true;
        }

        private void MergeAnalytics(Dictionary<string, object>? parsed)
        {
            if (parsed is null)
            {
                return;
            }

            _analytics ??= new Dictionary<string, object>(StringComparer.Ordinal);
            foreach (var kvp in parsed)
            {
                _analytics[kvp.Key] = kvp.Value;
            }
        }

        private static bool IsAnalyticsKey(string key) =>
            key.Equals(AnalyticsHelper.XCortiAnalytics, StringComparison.OrdinalIgnoreCase);

        private static Dictionary<string, string>? ToStringDictionary(
            Dictionary<string, object>? analytics
        )
        {
            if (analytics is null)
            {
                return null;
            }

            var result = new Dictionary<string, string>(analytics.Count, StringComparer.Ordinal);
            foreach (var kvp in analytics)
            {
                result[kvp.Key] = kvp.Value switch
                {
                    string s => s,
                    JsonElement element => element.ToString(),
                    _ => kvp.Value?.ToString() ?? string.Empty,
                };
            }
            return result;
        }
    }
}
