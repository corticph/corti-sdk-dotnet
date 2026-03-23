using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(StreamFlushedMessageType.StreamFlushedMessageTypeSerializer))]
[Serializable]
public readonly record struct StreamFlushedMessageType : IStringEnum
{
    public static readonly StreamFlushedMessageType Flushed = new(Values.Flushed);

    public StreamFlushedMessageType(string value)
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
    public static StreamFlushedMessageType FromCustom(string value)
    {
        return new StreamFlushedMessageType(value);
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

    public static bool operator ==(StreamFlushedMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StreamFlushedMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StreamFlushedMessageType value) => value.Value;

    public static explicit operator StreamFlushedMessageType(string value) => new(value);

    internal class StreamFlushedMessageTypeSerializer : JsonConverter<StreamFlushedMessageType>
    {
        public override StreamFlushedMessageType Read(
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
            return new StreamFlushedMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            StreamFlushedMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override StreamFlushedMessageType ReadAsPropertyName(
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
            return new StreamFlushedMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            StreamFlushedMessageType value,
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
        public const string Flushed = "flushed";
    }
}
