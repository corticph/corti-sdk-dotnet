using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti;

[Serializable]
public record FactsBatchUpdateRequest
{
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
