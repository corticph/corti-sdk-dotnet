using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti.Agents.A2A;

[Serializable]
public record GetTasksRequest
{
    /// <summary>
    /// Cap the number of history messages returned.
    /// </summary>
    [JsonIgnore]
    public int? HistoryLength { get; set; }

    /// <summary>
    /// A2A protocol version in `Major.Minor` form (A2A §3.6). Optional; defaults to `1.0` when absent. This surface implements `1.0` only. Patch versions MUST NOT be sent and are not considered during negotiation.
    /// </summary>
    [JsonIgnore]
    public string A2AVersion { get; set; } = "1.0";

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
