using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// Predicted or candidate code record.
/// </summary>
[Serializable]
public record CodesGeneralReadResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The coding system used
    /// </summary>
    [JsonPropertyName("system")]
    public required CommonCodingSystemEnum System { get; set; }

    /// <summary>
    /// The medical code
    /// </summary>
    [JsonPropertyName("code")]
    public required string Code { get; set; }

    /// <summary>
    /// Description of the medical code
    /// </summary>
    [JsonPropertyName("display")]
    public required string Display { get; set; }

    /// <summary>
    /// The evidence for the prediction
    /// </summary>
    [JsonPropertyName("evidences")]
    public IEnumerable<CodesGeneralReadResponseEvidencesItem>? Evidences { get; set; }

    /// <summary>
    /// Codes the model also considered for this prediction.
    /// </summary>
    [JsonPropertyName("alternatives")]
    public IEnumerable<CodesGeneralReadResponseAlternativesItem>? Alternatives { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
