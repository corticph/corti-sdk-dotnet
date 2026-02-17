using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record AgentsGetTaskRequest
{
    /// <summary>
    /// The number of previous messages to include in the context for the agent when retrieving this task. Default is all messages.
    /// </summary>
    [JsonIgnore]
    public int? HistoryLength { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
