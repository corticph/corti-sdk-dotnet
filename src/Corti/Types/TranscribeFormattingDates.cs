using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(TranscribeFormattingDates.TranscribeFormattingDatesSerializer))]
[Serializable]
public readonly record struct TranscribeFormattingDates : IStringEnum
{
    public static readonly TranscribeFormattingDates LocaleLong = new(Values.LocaleLong);

    public static readonly TranscribeFormattingDates LocaleMedium = new(Values.LocaleMedium);

    public static readonly TranscribeFormattingDates LocaleShort = new(Values.LocaleShort);

    public static readonly TranscribeFormattingDates AsDictated = new(Values.AsDictated);

    public static readonly TranscribeFormattingDates Iso = new(Values.Iso);

    public TranscribeFormattingDates(string value)
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
    public static TranscribeFormattingDates FromCustom(string value)
    {
        return new TranscribeFormattingDates(value);
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

    public static bool operator ==(TranscribeFormattingDates value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranscribeFormattingDates value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranscribeFormattingDates value) => value.Value;

    public static explicit operator TranscribeFormattingDates(string value) => new(value);

    internal class TranscribeFormattingDatesSerializer : JsonConverter<TranscribeFormattingDates>
    {
        public override TranscribeFormattingDates Read(
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
            return new TranscribeFormattingDates(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TranscribeFormattingDates value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TranscribeFormattingDates ReadAsPropertyName(
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
            return new TranscribeFormattingDates(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TranscribeFormattingDates value,
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
        public const string LocaleLong = "locale:long";

        public const string LocaleMedium = "locale:medium";

        public const string LocaleShort = "locale:short";

        public const string AsDictated = "as_dictated";

        public const string Iso = "iso";
    }
}
