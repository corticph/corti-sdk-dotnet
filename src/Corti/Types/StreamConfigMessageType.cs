using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(StreamConfigMessageType.StreamConfigMessageTypeSerializer))]
[Serializable]
public readonly record struct StreamConfigMessageType : IStringEnum
{
    public static readonly StreamConfigMessageType Config = new(Values.Config);

    public StreamConfigMessageType(string value)
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
    public static StreamConfigMessageType FromCustom(string value)
    {
        return new StreamConfigMessageType(value);
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

    public static bool operator ==(StreamConfigMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StreamConfigMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StreamConfigMessageType value) => value.Value;

    public static explicit operator StreamConfigMessageType(string value) => new(value);

    internal class StreamConfigMessageTypeSerializer : JsonConverter<StreamConfigMessageType>
    {
        public override StreamConfigMessageType Read(
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
            return new StreamConfigMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            StreamConfigMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override StreamConfigMessageType ReadAsPropertyName(
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
            return new StreamConfigMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            StreamConfigMessageType value,
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
        public const string Config = "config";
    }
}
