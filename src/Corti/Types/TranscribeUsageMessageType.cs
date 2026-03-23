using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(TranscribeUsageMessageType.TranscribeUsageMessageTypeSerializer))]
[Serializable]
public readonly record struct TranscribeUsageMessageType : IStringEnum
{
    public static readonly TranscribeUsageMessageType Usage = new(Values.Usage);

    public TranscribeUsageMessageType(string value)
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
    public static TranscribeUsageMessageType FromCustom(string value)
    {
        return new TranscribeUsageMessageType(value);
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

    public static bool operator ==(TranscribeUsageMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranscribeUsageMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranscribeUsageMessageType value) => value.Value;

    public static explicit operator TranscribeUsageMessageType(string value) => new(value);

    internal class TranscribeUsageMessageTypeSerializer : JsonConverter<TranscribeUsageMessageType>
    {
        public override TranscribeUsageMessageType Read(
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
            return new TranscribeUsageMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TranscribeUsageMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TranscribeUsageMessageType ReadAsPropertyName(
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
            return new TranscribeUsageMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TranscribeUsageMessageType value,
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
        public const string Usage = "usage";
    }
}
