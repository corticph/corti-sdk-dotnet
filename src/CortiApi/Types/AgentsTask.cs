using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record AgentsTask : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier for the task.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Identifier for the context (thread) in which the task is created.
    /// </summary>
    [JsonPropertyName("contextId")]
    public required string ContextId { get; set; }

    [JsonPropertyName("status")]
    public required AgentsTaskStatus Status { get; set; }

    /// <summary>
    /// The history of messages associated with the task.
    /// </summary>
    [JsonPropertyName("history")]
    public IEnumerable<AgentsMessage>? History { get; set; }

    /// <summary>
    /// The artifacts associated with the task.
    /// </summary>
    [JsonPropertyName("artifacts")]
    public IEnumerable<AgentsArtifact>? Artifacts { get; set; }

    /// <summary>
    /// Additional metadata for the task.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, object?>? Metadata { get; set; }

    /// <summary>
    /// The kind of the object, always "task".
    /// </summary>
    [JsonPropertyName("kind")]
    public required AgentsTaskKind Kind { get; set; }

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
