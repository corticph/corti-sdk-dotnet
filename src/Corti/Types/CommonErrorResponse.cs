using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Corti management-plane error envelope, used by all non-A2A endpoints.
///
/// - **Standard** — when the error chain contains at least one `PublicError`,
///   `code` and `message` come from the outermost `PublicError` and `details`
///   is merged across the whole chain (outer values take precedence).
/// - **Fallback** — when the chain contains no `PublicError`, the response is
///   a generic `500` carrying a `requestId` for support reference.
/// - **Validation** — a single `PublicError` whose `details.validationErrors`
///   lists the offending fields.
///
/// Field names use camelCase on the wire (e.g. `requestId`, `howToFix`).
/// The free-form `details` object may carry arbitrary caller-defined keys.
///
/// Rate limiting (HTTP 429) is not yet implemented; the server does not emit a 429 response.
/// </summary>
[Serializable]
public record CommonErrorResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The error object with code, message, and optional details.
    /// </summary>
    [JsonPropertyName("error")]
    public required CommonErrorResponseError Error { get; set; }

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
