using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(StringEnumSerializer<TranscribeFormattingMeasurements>))]
[Serializable]
public readonly record struct TranscribeFormattingMeasurements : IStringEnum
{
    public static readonly TranscribeFormattingMeasurements Abbreviated = new(Values.Abbreviated);

    public static readonly TranscribeFormattingMeasurements AsDictated = new(Values.AsDictated);

    public TranscribeFormattingMeasurements(string value)
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
    public static TranscribeFormattingMeasurements FromCustom(string value)
    {
        return new TranscribeFormattingMeasurements(value);
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

    public static bool operator ==(TranscribeFormattingMeasurements value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranscribeFormattingMeasurements value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranscribeFormattingMeasurements value) => value.Value;

    public static explicit operator TranscribeFormattingMeasurements(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Abbreviated = "abbreviated";

        public const string AsDictated = "as_dictated";
    }
}
