using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(StringEnumSerializer<TranscribeFormattingNumbers>))]
[Serializable]
public readonly record struct TranscribeFormattingNumbers : IStringEnum
{
    public static readonly TranscribeFormattingNumbers AsDictated = new(Values.AsDictated);

    public static readonly TranscribeFormattingNumbers Numerals = new(Values.Numerals);

    public static readonly TranscribeFormattingNumbers NumeralsAboveNine = new(
        Values.NumeralsAboveNine
    );

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

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string AsDictated = "as_dictated";

        public const string Numerals = "numerals";

        public const string NumeralsAboveNine = "numerals_above_nine";
    }
}
