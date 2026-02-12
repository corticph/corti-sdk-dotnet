using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record AgentsGetTaskRequest
{
    /// <summary>
    /// The identifier of the agent associated with the context.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <summary>
    /// The identifier of the task to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string TaskId { get; set; }

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
