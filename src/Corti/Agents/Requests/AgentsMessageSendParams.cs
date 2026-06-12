using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti;

[Serializable]
public record AgentsMessageSendParams
{
    [JsonPropertyName("message")]
    public required AgentsMessage Message { get; set; }

    [JsonPropertyName("configuration")]
    public AgentsMessageSendConfiguration? Configuration { get; set; }

    /// <summary>
    /// Optional metadata that will be associated with the message.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, object?>? Metadata { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
