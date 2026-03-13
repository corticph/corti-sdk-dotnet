using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(StringEnumSerializer<StreamEndedMessageType>))]
[Serializable]
public readonly record struct StreamEndedMessageType : IStringEnum
{
    public static readonly StreamEndedMessageType Ended = new(Values.Ended);

    public StreamEndedMessageType(string value)
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
    public static StreamEndedMessageType FromCustom(string value)
    {
        return new StreamEndedMessageType(value);
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

    public static bool operator ==(StreamEndedMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StreamEndedMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StreamEndedMessageType value) => value.Value;

    public static explicit operator StreamEndedMessageType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Ended = "ENDED";
    }
}
