using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record AgentsGetContextRequest
{
    /// <summary>
    /// The identifier of the agent associated with the context.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <summary>
    /// The identifier of the context (thread) to retrieve tasks for.
    /// </summary>
    [JsonIgnore]
    public required string ContextId { get; set; }

    /// <summary>
    /// The maximum number of tasks and messages to return. If not specified all history is returned.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// The number of tasks and messages to skip before starting to collect the result set. Default is 0.
    /// </summary>
    [JsonIgnore]
    public int? Offset { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
