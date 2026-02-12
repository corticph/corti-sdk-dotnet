using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(StringEnumSerializer<StreamConfigModeType>))]
[Serializable]
public readonly record struct StreamConfigModeType : IStringEnum
{
    public static readonly StreamConfigModeType Facts = new(Values.Facts);

    public static readonly StreamConfigModeType Transcription = new(Values.Transcription);

    public StreamConfigModeType(string value)
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
    public static StreamConfigModeType FromCustom(string value)
    {
        return new StreamConfigModeType(value);
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

    public static bool operator ==(StreamConfigModeType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StreamConfigModeType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StreamConfigModeType value) => value.Value;

    public static explicit operator StreamConfigModeType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Facts = "facts";

        public const string Transcription = "transcription";
    }
}
