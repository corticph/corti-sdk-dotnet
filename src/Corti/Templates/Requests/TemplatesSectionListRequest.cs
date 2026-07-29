using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti;

[Serializable]
public record TemplatesSectionListRequest
{
    /// <summary>
    /// Filter template sections by organization.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Org { get; set; } = new List<string>();

    /// <summary>
    /// Filter template sections by language.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Lang { get; set; } = new List<string>();

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
