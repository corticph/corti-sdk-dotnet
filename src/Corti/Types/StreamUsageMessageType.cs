using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(StringEnumSerializer<StreamUsageMessageType>))]
[Serializable]
public readonly record struct StreamUsageMessageType : IStringEnum
{
    public static readonly StreamUsageMessageType Usage = new(Values.Usage);

    public StreamUsageMessageType(string value)
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
    public static StreamUsageMessageType FromCustom(string value)
    {
        return new StreamUsageMessageType(value);
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

    public static bool operator ==(StreamUsageMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StreamUsageMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StreamUsageMessageType value) => value.Value;

    public static explicit operator StreamUsageMessageType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Usage = "usage";
    }
}
