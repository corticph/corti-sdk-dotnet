using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

[Serializable]
public record StreamFormatting : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Formatting for dates.
    /// </summary>
    [JsonPropertyName("dates")]
    public StreamFormattingDates? Dates { get; set; }

    /// <summary>
    /// Formatting for times.
    /// </summary>
    [JsonPropertyName("times")]
    public StreamFormattingTimes? Times { get; set; }

    /// <summary>
    /// Formatting for numbers.
    /// </summary>
    [JsonPropertyName("numbers")]
    public StreamFormattingNumbers? Numbers { get; set; }

    /// <summary>
    /// Formatting for measurements.
    /// </summary>
    [JsonPropertyName("measurements")]
    public StreamFormattingMeasurements? Measurements { get; set; }

    /// <summary>
    /// Formatting for numeric ranges.
    /// </summary>
    [JsonPropertyName("numericRanges")]
    public StreamFormattingNumericRanges? NumericRanges { get; set; }

    /// <summary>
    /// Formatting for ordinals.
    /// </summary>
    [JsonPropertyName("ordinals")]
    public StreamFormattingOrdinals? Ordinals { get; set; }

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
