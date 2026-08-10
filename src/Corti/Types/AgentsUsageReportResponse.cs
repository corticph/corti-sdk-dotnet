using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// An agent's bucketed usage over a date range, with range-wide totals.
/// </summary>
[Serializable]
public record AgentsUsageReportResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("granularity")]
    public required AgentsUsageGranularity Granularity { get; set; }

    /// <summary>
    /// Resolved inclusive start of the range (UTC).
    /// </summary>
    [JsonPropertyName("from")]
    public required DateTime From { get; set; }

    /// <summary>
    /// Resolved exclusive end of the range (UTC).
    /// </summary>
    [JsonPropertyName("to")]
    public required DateTime To { get; set; }

    /// <summary>
    /// Aggregate metrics across the whole range.
    /// </summary>
    [JsonPropertyName("totals")]
    public required AgentsUsageMetrics Totals { get; set; }

    /// <summary>
    /// One entry per period with activity, ordered oldest first.
    /// </summary>
    [JsonPropertyName("buckets")]
    public IEnumerable<AgentsUsageBucket> Buckets { get; set; } = new List<AgentsUsageBucket>();

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
