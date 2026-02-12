using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record RequestCodesUpdate
{
    /// <summary>
    /// The unique identifier of the interaction. Must be a valid UUID.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <summary>
    /// List of final codes
    /// </summary>
    [JsonPropertyName("finalCodes")]
    public IEnumerable<RequestCodesUpdateFinalCodesItem>? FinalCodes { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
