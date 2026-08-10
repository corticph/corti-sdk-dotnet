using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// A single span in an OpenInference trace.
/// </summary>
[Serializable]
public record AgenticContextsOpenInferenceSpan : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Human-readable span name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Unique span identifier.
    /// </summary>
    [JsonPropertyName("span_id")]
    public required string SpanId { get; set; }

    /// <summary>
    /// Parent span id, omitted for the root span.
    /// </summary>
    [JsonPropertyName("parent_span_id")]
    public string? ParentSpanId { get; set; }

    /// <summary>
    /// When the span started.
    /// </summary>
    [JsonPropertyName("start_time")]
    public required DateTime StartTime { get; set; }

    /// <summary>
    /// When the span ended; `null` if still in progress.
    /// </summary>
    [JsonPropertyName("end_time")]
    public DateTime? EndTime { get; set; }

    /// <summary>
    /// OpenInference span attributes. Key names and structure follow the OpenInference semantic conventions.
    /// </summary>
    [JsonPropertyName("attributes")]
    public Dictionary<string, object?>? Attributes { get; set; }

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
