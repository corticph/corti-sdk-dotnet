using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(StringEnumSerializer<TranscribeConfigMessageType>))]
[Serializable]
public readonly record struct TranscribeConfigMessageType : IStringEnum
{
    public static readonly TranscribeConfigMessageType Config = new(Values.Config);

    public TranscribeConfigMessageType(string value)
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
    public static TranscribeConfigMessageType FromCustom(string value)
    {
        return new TranscribeConfigMessageType(value);
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

    public static bool operator ==(TranscribeConfigMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranscribeConfigMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranscribeConfigMessageType value) => value.Value;

    public static explicit operator TranscribeConfigMessageType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Config = "config";
    }
}
