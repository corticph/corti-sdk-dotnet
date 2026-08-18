using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Structured context, merged from every `PublicError` in the chain
/// (outer values win). Omitted on the generic fallback response.
/// </summary>
[Serializable]
public record CommonErrorResponseErrorDetails : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Present when `code` is `VALIDATION_FAILED`.
    /// </summary>
    [JsonPropertyName("validationErrors")]
    public IEnumerable<CommonErrorResponseErrorDetailsValidationErrorsItem>? ValidationErrors { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
