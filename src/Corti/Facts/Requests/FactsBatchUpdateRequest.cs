using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti;

[Serializable]
public record FactsBatchUpdateRequest
{
    /// <summary>
    /// Identifies a distinct entity within Corti's multi-tenant system. Ensures correct routing and authentication of the request.
    /// </summary>
    [JsonIgnore]
    public required string TenantName { get; set; }

    /// <summary>
    /// A list of facts to be updated.
    /// </summary>
    [JsonPropertyName("facts")]
    public IEnumerable<FactsBatchUpdateInput> Facts { get; set; } =
        new List<FactsBatchUpdateInput>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
