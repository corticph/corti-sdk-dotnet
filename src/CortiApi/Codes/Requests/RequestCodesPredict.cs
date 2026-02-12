using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record RequestCodesPredict
{
    /// <summary>
    /// The unique identifier of the interaction. Must be a valid UUID.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <summary>
    /// The model name used for code predictions
    /// </summary>
    [JsonPropertyName("modelName")]
    public required string ModelName { get; set; }

    /// <summary>
    /// Context object containing type and data
    /// </summary>
    [JsonPropertyName("context")]
    public required CodesContext Context { get; set; }

    /// <summary>
    /// List of pre-selected codes before interaction
    /// </summary>
    [JsonPropertyName("existingCodes")]
    public IEnumerable<string>? ExistingCodes { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
