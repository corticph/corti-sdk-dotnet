using Corti;
using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti.Agentic.Registry;

[Serializable]
public record AgenticRegistryConnectorsListRequest
{
    /// <summary>
    /// Free-text search over `name`, `title`, `summary`, `description`, and `tags`.
    /// </summary>
    [JsonIgnore]
    public string? Q { get; set; }

    /// <summary>
    /// Filter by connector type.
    /// </summary>
    [JsonIgnore]
    public CommonConnectorType? Type { get; set; }

    /// <summary>
    /// Filter by the publishing namespace (e.g. `corti`).
    /// </summary>
    [JsonIgnore]
    public string? Publisher { get; set; }

    /// <summary>
    /// Filter by category (e.g. `literature`).
    /// </summary>
    [JsonIgnore]
    public string? Category { get; set; }

    /// <summary>
    /// Filter by tags. Comma-separated; a connector matches when it carries any of the listed tags.
    /// </summary>
    [JsonIgnore]
    public string? Tags { get; set; }

    /// <summary>
    /// Filter by lifecycle status.
    /// </summary>
    [JsonIgnore]
    public AgenticRegistryConnectorStatus? Status { get; set; }

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
