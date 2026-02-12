using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record TranscribeFormatting : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Formatting for dates.
    /// </summary>
    [JsonPropertyName("dates")]
    public TranscribeFormattingDates? Dates { get; set; }

    /// <summary>
    /// Formatting for times.
    /// </summary>
    [JsonPropertyName("times")]
    public TranscribeFormattingTimes? Times { get; set; }

    /// <summary>
    /// Formatting for numbers.
    /// </summary>
    [JsonPropertyName("numbers")]
    public TranscribeFormattingNumbers? Numbers { get; set; }

    /// <summary>
    /// Formatting for measurements.
    /// </summary>
    [JsonPropertyName("measurements")]
    public TranscribeFormattingMeasurements? Measurements { get; set; }

    /// <summary>
    /// Formatting for numeric ranges.
    /// </summary>
    [JsonPropertyName("numericRanges")]
    public TranscribeFormattingNumericRanges? NumericRanges { get; set; }

    /// <summary>
    /// Formatting for ordinals.
    /// </summary>
    [JsonPropertyName("ordinals")]
    public TranscribeFormattingOrdinals? Ordinals { get; set; }

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
