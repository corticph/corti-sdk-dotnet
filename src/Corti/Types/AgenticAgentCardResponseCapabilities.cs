using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Agent capability flags (streaming, push notifications).
/// </summary>
[Serializable]
public record AgenticAgentCardResponseCapabilities : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Whether the agent supports streaming responses.
    /// </summary>
    [JsonPropertyName("streaming")]
    public bool? Streaming { get; set; }

    /// <summary>
    /// Whether the agent can push task updates to a client-supplied webhook.
    /// **Future scope**: the `tasks/pushNotificationConfig/*` management endpoints are not yet implemented. Expect this to be `false` until they ship.
    /// </summary>
    [JsonPropertyName("pushNotifications")]
    public bool? PushNotifications { get; set; }

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
