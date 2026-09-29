using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

[Serializable]
public record TranscriptsFormatting : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Formatting for dates.
    /// </summary>
    [JsonPropertyName("dates")]
    public TranscriptsFormattingDates? Dates { get; set; }

    /// <summary>
    /// Formatting for times.
    /// </summary>
    [JsonPropertyName("times")]
    public TranscriptsFormattingTimes? Times { get; set; }

    /// <summary>
    /// Formatting for numbers.
    /// </summary>
    [JsonPropertyName("numbers")]
    public TranscriptsFormattingNumbers? Numbers { get; set; }

    /// <summary>
    /// Formatting for measurements.
    /// </summary>
    [JsonPropertyName("measurements")]
    public TranscriptsFormattingMeasurements? Measurements { get; set; }

    /// <summary>
    /// Formatting for numeric ranges.
    /// </summary>
    [JsonPropertyName("numericRanges")]
    public TranscriptsFormattingNumericRanges? NumericRanges { get; set; }

    /// <summary>
    /// Formatting for ordinals.
    /// </summary>
    [JsonPropertyName("ordinals")]
    public TranscriptsFormattingOrdinals? Ordinals { get; set; }

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
