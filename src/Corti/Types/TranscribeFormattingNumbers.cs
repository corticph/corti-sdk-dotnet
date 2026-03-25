using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(TranscribeFormattingNumbers.TranscribeFormattingNumbersSerializer))]
[Serializable]
public readonly record struct TranscribeFormattingNumbers : IStringEnum
{
    public static readonly TranscribeFormattingNumbers NumeralsAboveNine = new(
        Values.NumeralsAboveNine
    );

    public static readonly TranscribeFormattingNumbers Numerals = new(Values.Numerals);

    public static readonly TranscribeFormattingNumbers AsDictated = new(Values.AsDictated);

    public TranscribeFormattingNumbers(string value)
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
    public static TranscribeFormattingNumbers FromCustom(string value)
    {
        return new TranscribeFormattingNumbers(value);
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

    public static bool operator ==(TranscribeFormattingNumbers value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranscribeFormattingNumbers value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranscribeFormattingNumbers value) => value.Value;

    public static explicit operator TranscribeFormattingNumbers(string value) => new(value);

    internal class TranscribeFormattingNumbersSerializer
        : JsonConverter<TranscribeFormattingNumbers>
    {
        public override TranscribeFormattingNumbers Read(
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
            return new TranscribeFormattingNumbers(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TranscribeFormattingNumbers value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TranscribeFormattingNumbers ReadAsPropertyName(
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
            return new TranscribeFormattingNumbers(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TranscribeFormattingNumbers value,
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
        public const string NumeralsAboveNine = "numerals_above_nine";

        public const string Numerals = "numerals";

        public const string AsDictated = "as_dictated";
    }
}
