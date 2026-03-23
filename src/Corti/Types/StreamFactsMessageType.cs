using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(StreamFactsMessageType.StreamFactsMessageTypeSerializer))]
[Serializable]
public readonly record struct StreamFactsMessageType : IStringEnum
{
    public static readonly StreamFactsMessageType Facts = new(Values.Facts);

    public StreamFactsMessageType(string value)
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
    public static StreamFactsMessageType FromCustom(string value)
    {
        return new StreamFactsMessageType(value);
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

    public static bool operator ==(StreamFactsMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StreamFactsMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StreamFactsMessageType value) => value.Value;

    public static explicit operator StreamFactsMessageType(string value) => new(value);

    internal class StreamFactsMessageTypeSerializer : JsonConverter<StreamFactsMessageType>
    {
        public override StreamFactsMessageType Read(
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
            return new StreamFactsMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            StreamFactsMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override StreamFactsMessageType ReadAsPropertyName(
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
            return new StreamFactsMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            StreamFactsMessageType value,
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
        public const string Facts = "facts";
    }
}
