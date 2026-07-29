using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// A stored feedback resource.
/// </summary>
[Serializable]
public record FeedbackResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("taskId")]
    public required string TaskId { get; set; }

    [JsonPropertyName("rating")]
    public required FeedbackRating Rating { get; set; }

    /// <summary>
    /// Corti-derived internal score between 0 and 1. The original scale and
    /// value are always retained alongside this score.
    /// </summary>
    [JsonPropertyName("normalizedScore")]
    public required double NormalizedScore { get; set; }

    /// <summary>
    /// Structured observations about the result.
    /// </summary>
    [JsonPropertyName("labels")]
    public IEnumerable<FeedbackLabel> Labels { get; set; } = new List<FeedbackLabel>();

    /// <summary>
    /// Free-text explanation of the rating or labels.
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    [JsonPropertyName("target")]
    public FeedbackTarget? Target { get; set; }

    [JsonPropertyName("metadata")]
    public FeedbackMetadata? Metadata { get; set; }

    /// <summary>
    /// When the feedback was created.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

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
