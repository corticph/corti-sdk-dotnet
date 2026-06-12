using Corti.Core;
using global::System.Text.Json.Serialization;

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
