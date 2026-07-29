using Corti;
using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti.Documents;

[Serializable]
public record CreateSectionsRequest
{
    /// <summary>
    /// Identifies a distinct entity within Corti's multi-tenant system. Ensures correct routing and authentication of the request.
    /// </summary>
    [JsonIgnore]
    public required string TenantName { get; set; }

    [JsonIgnore]
    public required GuidedSectionsCreateRequest Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
