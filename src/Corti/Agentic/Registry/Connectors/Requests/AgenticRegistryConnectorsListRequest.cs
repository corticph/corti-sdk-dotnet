using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti.Agentic.Registry;

[Serializable]
public record AgenticRegistryConnectorsListRequest
{
    /// <summary>
    /// Free-text search over name and description.
    /// **Future scope**: not yet implemented; the server ignores this parameter and returns the unfiltered page.
    /// </summary>
    [JsonIgnore]
    public string? Q { get; set; }

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
