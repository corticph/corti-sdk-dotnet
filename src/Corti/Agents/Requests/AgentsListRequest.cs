using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record AgentsListRequest
{
    /// <summary>
    /// The maximum number of agents to return. If not specified, all agents will be returned.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// The number of agents to skip before starting to collect the result set. Default is 0.
    /// </summary>
    [JsonIgnore]
    public int? Offset { get; set; }

    /// <summary>
    /// If set to true, ephemeral agents will be included in the response. Default is false.
    /// </summary>
    [JsonIgnore]
    public bool? Ephemeral { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
