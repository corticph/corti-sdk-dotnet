using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(StringEnumSerializer<TranscribeFormattingNumericRanges>))]
[Serializable]
public readonly record struct TranscribeFormattingNumericRanges : IStringEnum
{
    public static readonly TranscribeFormattingNumericRanges AsDictated = new(Values.AsDictated);

    public static readonly TranscribeFormattingNumericRanges Numerals = new(Values.Numerals);

    public TranscribeFormattingNumericRanges(string value)
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
    public static TranscribeFormattingNumericRanges FromCustom(string value)
    {
        return new TranscribeFormattingNumericRanges(value);
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

    public static bool operator ==(TranscribeFormattingNumericRanges value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranscribeFormattingNumericRanges value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranscribeFormattingNumericRanges value) => value.Value;

    public static explicit operator TranscribeFormattingNumericRanges(string value) => new(value);

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
