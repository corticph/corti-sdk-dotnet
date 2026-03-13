using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record FactsCreateRequest
{
    /// <summary>
    /// A list of facts to be created.
    /// </summary>
    [JsonPropertyName("facts")]
    public IEnumerable<FactsCreateInput> Facts { get; set; } = new List<FactsCreateInput>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
