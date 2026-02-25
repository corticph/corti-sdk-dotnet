using System.Text.Json.Serialization;
using Corti.Core;

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
