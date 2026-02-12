using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(StringEnumSerializer<TranscribeFlushedMessageType>))]
[Serializable]
public readonly record struct TranscribeFlushedMessageType : IStringEnum
{
    public static readonly TranscribeFlushedMessageType Flushed = new(Values.Flushed);

    public TranscribeFlushedMessageType(string value)
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
    public static TranscribeFlushedMessageType FromCustom(string value)
    {
        return new TranscribeFlushedMessageType(value);
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

    public static bool operator ==(TranscribeFlushedMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranscribeFlushedMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranscribeFlushedMessageType value) => value.Value;

    public static explicit operator TranscribeFlushedMessageType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Flushed = "flushed";
    }
}
