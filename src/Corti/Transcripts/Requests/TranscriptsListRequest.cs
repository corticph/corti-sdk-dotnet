using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti;

[Serializable]
public record TranscriptsListRequest
{
    /// <summary>
    /// Display full transcripts in listing
    /// </summary>
    [JsonIgnore]
    public bool? Full { get; set; }

    /// <summary>
    /// Identifies a distinct entity within Corti's multi-tenant system. Ensures correct routing and authentication of the request.
    /// </summary>
    [JsonIgnore]
    public required string TenantName { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
