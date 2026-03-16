using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(TranscribeFormattingOrdinals.TranscribeFormattingOrdinalsSerializer))]
[Serializable]
public readonly record struct TranscribeFormattingOrdinals : IStringEnum
{
    public static readonly TranscribeFormattingOrdinals AsDictated = new(Values.AsDictated);

    public static readonly TranscribeFormattingOrdinals Numerals = new(Values.Numerals);

    public TranscribeFormattingOrdinals(string value)
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
    public static TranscribeFormattingOrdinals FromCustom(string value)
    {
        return new TranscribeFormattingOrdinals(value);
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

    public static bool operator ==(TranscribeFormattingOrdinals value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranscribeFormattingOrdinals value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranscribeFormattingOrdinals value) => value.Value;

    public static explicit operator TranscribeFormattingOrdinals(string value) => new(value);

    internal class TranscribeFormattingOrdinalsSerializer
        : JsonConverter<TranscribeFormattingOrdinals>
    {
        public override TranscribeFormattingOrdinals Read(
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
            return new TranscribeFormattingOrdinals(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TranscribeFormattingOrdinals value,
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
        public const string AsDictated = "as_dictated";

        public const string Numerals = "numerals";
    }
}
