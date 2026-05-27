using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(StreamAudioEventDataEvent.StreamAudioEventDataEventSerializer))]
[Serializable]
public readonly record struct StreamAudioEventDataEvent : IStringEnum
{
    public static readonly StreamAudioEventDataEvent SpeechQualityIssueDetected = new(
        Values.SpeechQualityIssueDetected
    );

    public static readonly StreamAudioEventDataEvent SpeechQualityIssueRecovered = new(
        Values.SpeechQualityIssueRecovered
    );

    public static readonly StreamAudioEventDataEvent LongSilenceDetected = new(
        Values.LongSilenceDetected
    );

    public static readonly StreamAudioEventDataEvent LongSilenceRecovered = new(
        Values.LongSilenceRecovered
    );

    public StreamAudioEventDataEvent(string value)
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
    public static StreamAudioEventDataEvent FromCustom(string value)
    {
        return new StreamAudioEventDataEvent(value);
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

    public static bool operator ==(StreamAudioEventDataEvent value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StreamAudioEventDataEvent value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StreamAudioEventDataEvent value) => value.Value;

    public static explicit operator StreamAudioEventDataEvent(string value) => new(value);

    internal class StreamAudioEventDataEventSerializer : JsonConverter<StreamAudioEventDataEvent>
    {
        public override StreamAudioEventDataEvent Read(
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
            return new StreamAudioEventDataEvent(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            StreamAudioEventDataEvent value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override StreamAudioEventDataEvent ReadAsPropertyName(
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
            return new StreamAudioEventDataEvent(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            StreamAudioEventDataEvent value,
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
