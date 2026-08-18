using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Request body for sending a message to an agent.
/// </summary>
[Serializable]
public record AgenticAgentsSendMessageRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("message")]
    public required CommonMessage Message { get; set; }

    [JsonPropertyName("configuration")]
    public AgenticAgentsSendMessageConfiguration? Configuration { get; set; }

    /// <summary>
    /// Free-form request metadata.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, object?>? Metadata { get; set; }

    /// <summary>
    /// Optional. Opaque routing identifier. Must match the `tenant` value from the selected `AgentInterface` in the Agent Card when that field is set.
    /// </summary>
    [JsonPropertyName("tenant")]
    public string? Tenant { get; set; }

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
