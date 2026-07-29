using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// A single trace with its inlined OpenInference spans.
/// </summary>
[Serializable]
public record ContextsTraceItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The trace-level record.
    /// </summary>
    [JsonPropertyName("trace")]
    public required ContextsTraceItemTrace Trace { get; set; }

    /// <summary>
    /// Spans in this trace, ordered by start time.
    /// </summary>
    [JsonPropertyName("spans")]
    public IEnumerable<ContextsOpenInferenceSpan> Spans { get; set; } =
        new List<ContextsOpenInferenceSpan>();

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
