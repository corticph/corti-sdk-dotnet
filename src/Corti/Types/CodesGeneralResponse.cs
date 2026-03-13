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
    /// Highest confidence bundle of codes, preselected by the code prediction model
    /// </summary>
    [JsonPropertyName("codes")]
    public IEnumerable<CodesGeneralReadResponse> Codes { get; set; } =
        new List<CodesGeneralReadResponse>();

    /// <summary>
    /// Full list of candidate codes as predicted by the model, rank sorted by model confidence
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
