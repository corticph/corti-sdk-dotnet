using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(StringEnumSerializer<TranscribeFormattingOrdinals>))]
[Serializable]
public readonly record struct TranscribeFormattingOrdinals : IStringEnum
{
    public static readonly TranscribeFormattingOrdinals NumeralsAboveNine = new(
        Values.NumeralsAboveNine
    );

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

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string NumeralsAboveNine = "numerals_above_nine";

        public const string AsDictated = "as_dictated";

        public const string Numerals = "numerals";
    }
}
