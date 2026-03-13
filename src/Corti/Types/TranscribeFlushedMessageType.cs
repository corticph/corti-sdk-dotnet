using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(TranscribeFlushedMessageType.TranscribeFlushedMessageTypeSerializer))]
[Serializable]
public readonly record struct TranscribeFlushedMessageType : IStringEnum
{
    public static readonly TranscribeFlushedMessageType Flushed = new(Values.Flushed);

    public TranscribeFlushedMessageType(string value)
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
    public static TranscribeFlushedMessageType FromCustom(string value)
    {
        return new TranscribeFlushedMessageType(value);
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

    public static bool operator ==(TranscribeFlushedMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranscribeFlushedMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranscribeFlushedMessageType value) => value.Value;

    public static explicit operator TranscribeFlushedMessageType(string value) => new(value);

    internal class TranscribeFlushedMessageTypeSerializer
        : JsonConverter<TranscribeFlushedMessageType>
    {
        public override TranscribeFlushedMessageType Read(
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
            return new TranscribeFlushedMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TranscribeFlushedMessageType value,
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
        public const string Flushed = "flushed";
    }
}
