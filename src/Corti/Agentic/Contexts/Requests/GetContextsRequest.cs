using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti.Agentic;

[Serializable]
public record GetContextsRequest
{
    /// <summary>
    /// Cap the number of history messages returned per task.
    /// </summary>
    [JsonIgnore]
    public int? HistoryLength { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
