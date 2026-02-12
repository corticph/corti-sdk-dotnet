using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record FactsBatchUpdateRequest
{
    /// <summary>
    /// The unique identifier of the interaction. Must be a valid UUID.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

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
