using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(StringEnumSerializer<TranscribeFlushMessageType>))]
[Serializable]
public readonly record struct TranscribeFlushMessageType : IStringEnum
{
    public static readonly TranscribeFlushMessageType Flush = new(Values.Flush);

    public TranscribeFlushMessageType(string value)
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
    public static TranscribeFlushMessageType FromCustom(string value)
    {
        return new TranscribeFlushMessageType(value);
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

    public static bool operator ==(TranscribeFlushMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranscribeFlushMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranscribeFlushMessageType value) => value.Value;

    public static explicit operator TranscribeFlushMessageType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Flush = "flush";
    }
}
