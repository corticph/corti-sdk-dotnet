using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(StreamErrorMessageType.StreamErrorMessageTypeSerializer))]
[Serializable]
public readonly record struct StreamErrorMessageType : IStringEnum
{
    public static readonly StreamErrorMessageType Error = new(Values.Error);

    public StreamErrorMessageType(string value)
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
    public static StreamErrorMessageType FromCustom(string value)
    {
        return new StreamErrorMessageType(value);
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

    public static bool operator ==(StreamErrorMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StreamErrorMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StreamErrorMessageType value) => value.Value;

    public static explicit operator StreamErrorMessageType(string value) => new(value);

    internal class StreamErrorMessageTypeSerializer : JsonConverter<StreamErrorMessageType>
    {
        public override StreamErrorMessageType Read(
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
            return new StreamErrorMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            StreamErrorMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override StreamErrorMessageType ReadAsPropertyName(
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
            return new StreamErrorMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            StreamErrorMessageType value,
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
        public const string Error = "error";
    }
}
