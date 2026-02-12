using System.Text.Json.Serialization;
using CortiApi.Core;
using OneOf;

namespace CortiApi;

[Serializable]
public record CodesGeneralPredictRequest
{
    /// <summary>
    /// List of coding systems for prediction
    /// </summary>
    [JsonPropertyName("system")]
    public IEnumerable<CommonCodingSystemEnum> System { get; set; } =
        new List<CommonCodingSystemEnum>();

    /// <summary>
    /// Select either `text` or `documentId` as input context to the model for code prediction. Evidence indices in the response map to this array.
    /// </summary>
    [JsonPropertyName("context")]
    public IEnumerable<OneOf<CommonTextContext, CommonDocumentIdContext>> Context { get; set; } =
        new List<OneOf<CommonTextContext, CommonDocumentIdContext>>();

    /// <summary>
    /// Maximum number of code candidates to include in the response (per system).
    /// </summary>
    [JsonPropertyName("maxCandidates")]
    public int? MaxCandidates { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
