using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti;

[Serializable]
public record TemplatesListRequest
{
    /// <summary>
    /// Filter templates by organization.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Org { get; set; } = new List<string>();

    /// <summary>
    /// Filter templates by language.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Lang { get; set; } = new List<string>();

    /// <summary>
    /// Filter templates by their status.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Status { get; set; } = new List<string>();

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
