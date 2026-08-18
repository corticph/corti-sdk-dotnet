using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// The error object with code, message, and optional details.
/// </summary>
[Serializable]
public record CommonErrorResponseError : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Stable, machine-readable, SCREAMING_SNAKE_CASE error code.
    /// </summary>
    [JsonPropertyName("code")]
    public required string Code { get; set; }

    /// <summary>
    /// Human-readable explanation.
    /// </summary>
    [JsonPropertyName("message")]
    public required string Message { get; set; }

    /// <summary>
    /// Optional guidance for the caller to resolve the error.
    /// </summary>
    [JsonPropertyName("howToFix")]
    public string? HowToFix { get; set; }

    /// <summary>
    /// Structured context, merged from every `PublicError` in the chain
    /// (outer values win). Omitted on the generic fallback response.
    /// </summary>
    [JsonPropertyName("details")]
    public CommonErrorResponseErrorDetails? Details { get; set; }

    /// <summary>
    /// Correlation ID from request middleware. Included only on the
    /// generic `500` fallback so consumers can quote it in support requests.
    /// </summary>
    [JsonPropertyName("requestId")]
    public string? RequestId { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
