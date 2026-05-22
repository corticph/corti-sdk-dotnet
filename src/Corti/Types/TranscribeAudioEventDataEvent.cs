using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(TranscribeAudioEventDataEvent.TranscribeAudioEventDataEventSerializer))]
[Serializable]
public readonly record struct TranscribeAudioEventDataEvent : IStringEnum
{
    public static readonly TranscribeAudioEventDataEvent SpeechQualityIssueDetected = new(
        Values.SpeechQualityIssueDetected
    );

    public static readonly TranscribeAudioEventDataEvent SpeechQualityIssueRecovered = new(
        Values.SpeechQualityIssueRecovered
    );

    public static readonly TranscribeAudioEventDataEvent LongSilenceDetected = new(
        Values.LongSilenceDetected
    );

    public static readonly TranscribeAudioEventDataEvent LongSilenceRecovered = new(
        Values.LongSilenceRecovered
    );

    public TranscribeAudioEventDataEvent(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static TranscribeAudioEventDataEvent FromCustom(string value)
    {
        return new TranscribeAudioEventDataEvent(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(TranscribeAudioEventDataEvent value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranscribeAudioEventDataEvent value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranscribeAudioEventDataEvent value) => value.Value;

    public static explicit operator TranscribeAudioEventDataEvent(string value) => new(value);

    internal class TranscribeAudioEventDataEventSerializer
        : JsonConverter<TranscribeAudioEventDataEvent>
    {
        public override TranscribeAudioEventDataEvent Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new TranscribeAudioEventDataEvent(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TranscribeAudioEventDataEvent value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TranscribeAudioEventDataEvent ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new TranscribeAudioEventDataEvent(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TranscribeAudioEventDataEvent value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string SpeechQualityIssueDetected = "speechQualityIssueDetected";

        public const string SpeechQualityIssueRecovered = "speechQualityIssueRecovered";

        public const string LongSilenceDetected = "longSilenceDetected";

        public const string LongSilenceRecovered = "longSilenceRecovered";
    }
}
