using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// An A2A task — a unit of agent work with status, history, and artifacts.
/// </summary>
[Serializable]
public record CommonTaskResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("contextId")]
    public required string ContextId { get; set; }

    [JsonPropertyName("status")]
    public required CommonTaskStatus Status { get; set; }

    /// <summary>
    /// Messages exchanged during the task, oldest first.
    /// </summary>
    [JsonPropertyName("history")]
    public IEnumerable<CommonMessage>? History { get; set; }

    /// <summary>
    /// Artifacts produced by the task.
    /// </summary>
    [JsonPropertyName("artifacts")]
    public IEnumerable<CommonArtifactResponse>? Artifacts { get; set; }

    /// <summary>
    /// Task metadata, including `$usage` token/credit accounting. Not yet exposed through the REST binding (deferred); only the JSON-RPC binding populates this field.
    /// </summary>
    [JsonPropertyName("metadata")]
    public CommonTaskMetadata? Metadata { get; set; }

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
