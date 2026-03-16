using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(TranscribeEndMessageType.TranscribeEndMessageTypeSerializer))]
[Serializable]
public readonly record struct TranscribeEndMessageType : IStringEnum
{
    public static readonly TranscribeEndMessageType End = new(Values.End);

    public TranscribeEndMessageType(string value)
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
    public static TranscribeEndMessageType FromCustom(string value)
    {
        return new TranscribeEndMessageType(value);
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

    public static bool operator ==(TranscribeEndMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranscribeEndMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranscribeEndMessageType value) => value.Value;

    public static explicit operator TranscribeEndMessageType(string value) => new(value);

    internal class TranscribeEndMessageTypeSerializer : JsonConverter<TranscribeEndMessageType>
    {
        public override TranscribeEndMessageType Read(
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
            return new TranscribeEndMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TranscribeEndMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string End = "end";
    }
}
