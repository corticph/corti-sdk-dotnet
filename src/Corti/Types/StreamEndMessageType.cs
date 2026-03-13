using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(StringEnumSerializer<StreamEndMessageType>))]
[Serializable]
public readonly record struct StreamEndMessageType : IStringEnum
{
    public static readonly StreamEndMessageType End = new(Values.End);

    public StreamEndMessageType(string value)
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
    public static StreamEndMessageType FromCustom(string value)
    {
        return new StreamEndMessageType(value);
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

    public static bool operator ==(StreamEndMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StreamEndMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StreamEndMessageType value) => value.Value;

    public static explicit operator StreamEndMessageType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string End = "end";
    }
}
