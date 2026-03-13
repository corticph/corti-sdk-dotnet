using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record FactsExtractResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// List of extracted facts based on the provided input context.
    /// </summary>
    [JsonPropertyName("facts")]
    public IEnumerable<FactsExtractResponseFactsItem> Facts { get; set; } =
        new List<FactsExtractResponseFactsItem>();

    /// <summary>
    /// The language locale of the output.
    /// </summary>
    [JsonPropertyName("outputLanguage")]
    public required string OutputLanguage { get; set; }

    [JsonPropertyName("usageInfo")]
    public required CommonUsageInfo UsageInfo { get; set; }

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
