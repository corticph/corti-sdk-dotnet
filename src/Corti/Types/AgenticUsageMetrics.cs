using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Invocation metrics for a single period.
/// </summary>
[Serializable]
public record AgenticUsageMetrics : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
