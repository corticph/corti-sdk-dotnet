using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(TranscribeEndedMessageType.TranscribeEndedMessageTypeSerializer))]
[Serializable]
public readonly record struct TranscribeEndedMessageType : IStringEnum
{
    public static readonly TranscribeEndedMessageType Ended = new(Values.Ended);

    public TranscribeEndedMessageType(string value)
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
    public static TranscribeEndedMessageType FromCustom(string value)
    {
        return new TranscribeEndedMessageType(value);
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

    public static bool operator ==(TranscribeEndedMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranscribeEndedMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranscribeEndedMessageType value) => value.Value;

    public static explicit operator TranscribeEndedMessageType(string value) => new(value);

    internal class TranscribeEndedMessageTypeSerializer : JsonConverter<TranscribeEndedMessageType>
    {
        public override TranscribeEndedMessageType Read(
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
            return new TranscribeEndedMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TranscribeEndedMessageType value,
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
        public const string Ended = "ended";
    }
}
