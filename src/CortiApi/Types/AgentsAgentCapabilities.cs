using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record AgentsAgentCapabilities : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Indicates whether the agent supports streaming responses.
    /// </summary>
    [JsonPropertyName("streaming")]
    public bool? Streaming { get; set; }

    /// <summary>
    /// Indicates whether the agent supports push notifications for task status updates.
    /// </summary>
    [JsonPropertyName("pushNotifications")]
    public bool? PushNotifications { get; set; }

    /// <summary>
    /// Indicates whether the agent maintains a history of state transitions for tasks.
    /// </summary>
    [JsonPropertyName("stateTransitionHistory")]
    public bool? StateTransitionHistory { get; set; }

    /// <summary>
    /// A list of protocol extensions supported by the agent.
    /// </summary>
    [JsonPropertyName("extensions")]
    public IEnumerable<AgentsAgentExtension>? Extensions { get; set; }

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
