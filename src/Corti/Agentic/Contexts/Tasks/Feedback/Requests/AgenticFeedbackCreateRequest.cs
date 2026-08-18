using Corti;
using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti.Agentic.Contexts.Tasks;

[Serializable]
public record AgenticFeedbackCreateRequest
{
    [JsonPropertyName("rating")]
    public required AgenticFeedbackRating Rating { get; set; }

    /// <summary>
    /// Structured observations about the result. Defaults to an empty array.
    /// Positive and negative labels may be combined. Duplicate labels are
    /// rejected. A maximum of five labels may be submitted.
    /// </summary>
    [JsonPropertyName("labels")]
    public IEnumerable<AgenticFeedbackLabel>? Labels { get; set; }

    /// <summary>
    /// The user's explanation of the rating or labels. Required when `labels`
    /// contains `other`.
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    [JsonPropertyName("target")]
    public AgenticFeedbackTarget? Target { get; set; }

    [JsonPropertyName("metadata")]
    public AgenticFeedbackMetadata? Metadata { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
