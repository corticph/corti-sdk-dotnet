using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Usage metrics for a single time bucket.
/// </summary>
[Serializable]
public record AgentsUsageBucket : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Inclusive start of the bucket (UTC).
    /// </summary>
    [JsonPropertyName("periodStart")]
    public required DateTime PeriodStart { get; set; }

    /// <summary>
    /// Exclusive end of the bucket (UTC).
    /// </summary>
    [JsonPropertyName("periodEnd")]
    public required DateTime PeriodEnd { get; set; }

    /// <summary>
    /// Number of agent invocations in the period.
    /// </summary>
    [JsonPropertyName("invocations")]
    public required long Invocations { get; set; }

    /// <summary>
    /// Number of distinct contexts invoked in the period.
    /// </summary>
    [JsonPropertyName("uniqueContexts")]
    public required long UniqueContexts { get; set; }

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
