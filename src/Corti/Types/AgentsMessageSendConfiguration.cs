using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record AgentsMessageSendConfiguration : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A list of output MIME types the client is prepared to accept in the response.
    /// </summary>
    [JsonPropertyName("acceptedOutputModes")]
    public IEnumerable<string>? AcceptedOutputModes { get; set; }

    /// <summary>
    /// The number of previous messages to include in the context for the agent when processing this message.
    /// </summary>
    [JsonPropertyName("historyLength")]
    public int? HistoryLength { get; set; }

    [JsonPropertyName("pushNotificationConfig")]
    public AgentsPushNotificationConfig? PushNotificationConfig { get; set; }

    /// <summary>
    /// If true, the client will wait for the task to complete. The server may reject this if the task is long-running.
    /// </summary>
    [JsonPropertyName("blocking")]
    public bool? Blocking { get; set; }

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
