using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// The trace-level record.
/// </summary>
[Serializable]
public record ContextsTraceItemTrace : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Trace identifier (OTel trace ID — 32-char hex).
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Human-readable trace name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// When the trace started.
    /// </summary>
    [JsonPropertyName("start_time")]
    public required DateTime StartTime { get; set; }

    /// <summary>
    /// When the trace ended; `null` if still in progress.
    /// </summary>
    [JsonPropertyName("end_time")]
    public DateTime? EndTime { get; set; }

    /// <summary>
    /// Trace-level input payload.
    /// </summary>
    [JsonPropertyName("input")]
    public Dictionary<string, object?>? Input { get; set; }

    /// <summary>
    /// Trace-level output payload.
    /// </summary>
    [JsonPropertyName("output")]
    public Dictionary<string, object?>? Output { get; set; }

    /// <summary>
    /// Free-form trace metadata.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, object?>? Metadata { get; set; }

    /// <summary>
    /// Trace tags.
    /// </summary>
    [JsonPropertyName("tags")]
    public IEnumerable<string>? Tags { get; set; }

    /// <summary>
    /// Thread/context identifier.
    /// </summary>
    [JsonPropertyName("thread_id")]
    public required string ThreadId { get; set; }

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
