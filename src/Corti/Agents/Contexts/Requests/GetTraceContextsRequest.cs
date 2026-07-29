using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti.Agents;

[Serializable]
public record GetTraceContextsRequest
{
    /// <summary>
    /// Maximum number of items per page.
    /// </summary>
    [JsonIgnore]
    public int? PageSize { get; set; }

    /// <summary>
    /// Opaque cursor from a prior response's `nextPageToken`. Omit on the first request.
    /// </summary>
    [JsonIgnore]
    public string? PageToken { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
