using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

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
    public IEnumerable<CommonAiContext> Context { get; set; } = new List<CommonAiContext>();

    /// <summary>
    /// Optional filter to restrict predicted codes.
    /// </summary>
    [JsonPropertyName("filter")]
    public CodesFilter? Filter { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
