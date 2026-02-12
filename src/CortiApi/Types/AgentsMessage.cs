using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;
using OneOf;

namespace CortiApi;

[Serializable]
public record AgentsMessage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The role of the message sender.
    /// </summary>
    [JsonPropertyName("role")]
    public required AgentsMessageRole Role { get; set; }

    /// <summary>
    /// The content of the message.
    /// </summary>
    [JsonPropertyName("parts")]
    public IEnumerable<OneOf<AgentsTextPart, AgentsFilePart, AgentsDataPart>> Parts { get; set; } =
        new List<OneOf<AgentsTextPart, AgentsFilePart, AgentsDataPart>>();

    /// <summary>
    /// Additional metadata for the message.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, object?>? Metadata { get; set; }

    /// <summary>
    /// Extensions for the message.
    /// </summary>
    [JsonPropertyName("extensions")]
    public IEnumerable<string>? Extensions { get; set; }

    /// <summary>
    /// Task IDs that this message references for additional context.
    /// </summary>
    [JsonPropertyName("referenceTaskIds")]
    public IEnumerable<string>? ReferenceTaskIds { get; set; }

    /// <summary>
    /// Unique identifier for the message.
    /// </summary>
    [JsonPropertyName("messageId")]
    public required string MessageId { get; set; }

    /// <summary>
    /// Unique identifier for the task associated with the message.
    /// </summary>
    [JsonPropertyName("taskId")]
    public string? TaskId { get; set; }

    /// <summary>
    /// Identifier for the context (thread) in which the message is sent.
    /// </summary>
    [JsonPropertyName("contextId")]
    public string? ContextId { get; set; }

    /// <summary>
    /// The kind of the object, always "message".
    /// </summary>
    [JsonPropertyName("kind")]
    public required AgentsMessageKind Kind { get; set; }

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
