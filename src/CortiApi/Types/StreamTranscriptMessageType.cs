using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(StringEnumSerializer<StreamTranscriptMessageType>))]
[Serializable]
public readonly record struct StreamTranscriptMessageType : IStringEnum
{
    public static readonly StreamTranscriptMessageType Transcript = new(Values.Transcript);

    public StreamTranscriptMessageType(string value)
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
    public static StreamTranscriptMessageType FromCustom(string value)
    {
        return new StreamTranscriptMessageType(value);
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

    public static bool operator ==(StreamTranscriptMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StreamTranscriptMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StreamTranscriptMessageType value) => value.Value;

    public static explicit operator StreamTranscriptMessageType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Transcript = "transcript";
    }
}
