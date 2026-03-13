using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(StringEnumSerializer<TranscribeErrorMessageType>))]
[Serializable]
public readonly record struct TranscribeErrorMessageType : IStringEnum
{
    public static readonly TranscribeErrorMessageType Error = new(Values.Error);

    public TranscribeErrorMessageType(string value)
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
    public static TranscribeErrorMessageType FromCustom(string value)
    {
        return new TranscribeErrorMessageType(value);
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

    public static bool operator ==(TranscribeErrorMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranscribeErrorMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranscribeErrorMessageType value) => value.Value;

    public static explicit operator TranscribeErrorMessageType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Error = "error";
    }
}
