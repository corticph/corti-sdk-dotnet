using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Per-request usage accounting emitted by the agent service under
/// `metadata.corti.usage`. `creditsConsumed` is always populated;
/// `inputTokens` and `outputTokens` may appear in the future.
/// </summary>
[Serializable]
public record CommonCortiUsage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Corti billing credits charged for the task.
    /// </summary>
    [JsonPropertyName("creditsConsumed")]
    public required double CreditsConsumed { get; set; }

    /// <summary>
    /// Prompt tokens consumed.
    /// </summary>
    [JsonPropertyName("inputTokens")]
    public long? InputTokens { get; set; }

    /// <summary>
    /// Completion tokens produced.
    /// </summary>
    [JsonPropertyName("outputTokens")]
    public long? OutputTokens { get; set; }

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
