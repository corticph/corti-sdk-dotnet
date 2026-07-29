using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// All feedback resources for a task, newest-first. Feedback is scoped to the authenticated user via row-level security.
/// </summary>
[Serializable]
public record FeedbackListResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Feedback resources for the task.
    /// </summary>
    [JsonPropertyName("feedbacks")]
    public IEnumerable<FeedbackResponse> Feedbacks { get; set; } = new List<FeedbackResponse>();

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
