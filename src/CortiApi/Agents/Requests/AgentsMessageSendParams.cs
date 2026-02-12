using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record AgentsMessageSendParams
{
    /// <summary>
    /// The identifier of the agent associated with the context.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

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
