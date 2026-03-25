using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record CodesGeneralResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Codes predicted by the model.
    /// </summary>
    [JsonPropertyName("codes")]
    public IEnumerable<CodesGeneralReadResponse> Codes { get; set; } =
        new List<CodesGeneralReadResponse>();

    /// <summary>
    /// Lower-confidence codes the model considered potentially relevant but excluded from the predicted set.
    /// </summary>
    [JsonPropertyName("candidates")]
    public IEnumerable<CodesGeneralReadResponse> Candidates { get; set; } =
        new List<CodesGeneralReadResponse>();

    [JsonPropertyName("usageInfo")]
    public CommonUsageInfo? UsageInfo { get; set; }

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
