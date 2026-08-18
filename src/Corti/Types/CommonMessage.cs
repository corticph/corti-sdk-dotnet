using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// An A2A message — an ordered list of content parts with a role.
/// </summary>
[Serializable]
public record CommonMessage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("messageId")]
    public string? MessageId { get; set; }

    [JsonPropertyName("contextId")]
    public string? ContextId { get; set; }

    [JsonPropertyName("taskId")]
    public string? TaskId { get; set; }

    [JsonPropertyName("role")]
    public required CommonRole Role { get; set; }

    /// <summary>
    /// Ordered content parts of the message.
    /// </summary>
    [JsonPropertyName("parts")]
    public IEnumerable<CommonPart> Parts { get; set; } = new List<CommonPart>();

    /// <summary>
    /// Task ids this message references (A2A v1.0 `Message.referenceTaskIds`).
    /// </summary>
    [JsonPropertyName("referenceTaskIds")]
    public IEnumerable<string>? ReferenceTaskIds { get; set; }

    /// <summary>
    /// URIs of A2A extensions that contributed to this message (A2A v1.0 `Message.extensions`).
    /// </summary>
    [JsonPropertyName("extensions")]
    public IEnumerable<string>? Extensions { get; set; }

    /// <summary>
    /// Free-form A2A metadata. Corti's own first-party keys are prefixed
    /// with `$` (à la Mixpanel) to set them apart from caller-supplied keys.
    /// A2A defines no message-level timestamp, so Corti carries one as
    /// `$timestamp` (RFC 3339 / ISO 8601) — useful for timing *user*
    /// messages, which `TaskStatus.timestamp` cannot.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, object?>? Metadata { get; set; }

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
