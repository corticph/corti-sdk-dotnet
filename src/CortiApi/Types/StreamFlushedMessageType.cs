using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(StringEnumSerializer<StreamFlushedMessageType>))]
[Serializable]
public readonly record struct StreamFlushedMessageType : IStringEnum
{
    public static readonly StreamFlushedMessageType Flushed = new(Values.Flushed);

    public StreamFlushedMessageType(string value)
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
    public static StreamFlushedMessageType FromCustom(string value)
    {
        return new StreamFlushedMessageType(value);
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

    public static bool operator ==(StreamFlushedMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StreamFlushedMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StreamFlushedMessageType value) => value.Value;

    public static explicit operator StreamFlushedMessageType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Flushed = "flushed";
    }
}
