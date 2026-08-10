using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Token and credit accounting for a task, following the conventions used by
/// major LLM providers. `inputTokens`/`outputTokens` count the prompt and
/// completion respectively; `cachedInputTokens` is the subset of
/// `inputTokens` served from the provider's prompt cache (a discount, not an
/// addition), and `cacheCreationInputTokens` is the surcharge paid to
/// *write* the cache. `totalTokens` is the all-in count. `credits` is the
/// Corti billing unit charged for the task.
/// </summary>
[Serializable]
public record CommonUsage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The model identifier that served the request.
    /// </summary>
    [JsonPropertyName("model")]
    public string? Model { get; set; }

    /// <summary>
    /// Prompt tokens consumed.
    /// </summary>
    [JsonPropertyName("inputTokens")]
    public required long InputTokens { get; set; }

    /// <summary>
    /// Completion tokens produced.
    /// </summary>
    [JsonPropertyName("outputTokens")]
    public required long OutputTokens { get; set; }

    /// <summary>
    /// Subset of `inputTokens` served from the prompt cache (cache read).
    /// </summary>
    [JsonPropertyName("cachedInputTokens")]
    public long? CachedInputTokens { get; set; }

    /// <summary>
    /// Input tokens written to the prompt cache (cache-write surcharge).
    /// </summary>
    [JsonPropertyName("cacheCreationInputTokens")]
    public long? CacheCreationInputTokens { get; set; }

    /// <summary>
    /// Total tokens billed (`inputTokens` + `outputTokens`).
    /// </summary>
    [JsonPropertyName("totalTokens")]
    public required long TotalTokens { get; set; }

    /// <summary>
    /// Corti billing credits charged for the task.
    /// </summary>
    [JsonPropertyName("credits")]
    public double? Credits { get; set; }

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
