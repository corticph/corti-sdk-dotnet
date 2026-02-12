using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(StringEnumSerializer<TranscribeFormattingDates>))]
[Serializable]
public readonly record struct TranscribeFormattingDates : IStringEnum
{
    public static readonly TranscribeFormattingDates AsDictated = new(Values.AsDictated);

    public static readonly TranscribeFormattingDates EuSlash = new(Values.EuSlash);

    public static readonly TranscribeFormattingDates IsoCompact = new(Values.IsoCompact);

    public static readonly TranscribeFormattingDates LongText = new(Values.LongText);

    public static readonly TranscribeFormattingDates UsSlash = new(Values.UsSlash);

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

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string AsDictated = "as_dictated";

        public const string EuSlash = "eu_slash";

        public const string IsoCompact = "iso_compact";

        public const string LongText = "long_text";

        public const string UsSlash = "us_slash";
    }
}
