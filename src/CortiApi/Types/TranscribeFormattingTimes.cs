using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(StringEnumSerializer<TranscribeFormattingTimes>))]
[Serializable]
public readonly record struct TranscribeFormattingTimes : IStringEnum
{
    public static readonly TranscribeFormattingTimes AsDictated = new(Values.AsDictated);

    public static readonly TranscribeFormattingTimes H12 = new(Values.H12);

    public static readonly TranscribeFormattingTimes H24 = new(Values.H24);

    public TranscribeFormattingTimes(string value)
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
    public static TranscribeFormattingTimes FromCustom(string value)
    {
        return new TranscribeFormattingTimes(value);
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

    public static bool operator ==(TranscribeFormattingTimes value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranscribeFormattingTimes value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranscribeFormattingTimes value) => value.Value;

    public static explicit operator TranscribeFormattingTimes(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string AsDictated = "as_dictated";

        public const string H12 = "h12";

        public const string H24 = "h24";
    }
}
