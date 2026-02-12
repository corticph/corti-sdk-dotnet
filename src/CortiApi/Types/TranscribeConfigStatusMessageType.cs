using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(StringEnumSerializer<TranscribeConfigStatusMessageType>))]
[Serializable]
public readonly record struct TranscribeConfigStatusMessageType : IStringEnum
{
    public static readonly TranscribeConfigStatusMessageType ConfigAccepted = new(
        Values.ConfigAccepted
    );

    public static readonly TranscribeConfigStatusMessageType ConfigDenied = new(
        Values.ConfigDenied
    );

    public static readonly TranscribeConfigStatusMessageType ConfigTimeout = new(
        Values.ConfigTimeout
    );

    public TranscribeConfigStatusMessageType(string value)
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
    public static TranscribeConfigStatusMessageType FromCustom(string value)
    {
        return new TranscribeConfigStatusMessageType(value);
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

    public static bool operator ==(TranscribeConfigStatusMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranscribeConfigStatusMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranscribeConfigStatusMessageType value) => value.Value;

    public static explicit operator TranscribeConfigStatusMessageType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string ConfigAccepted = "CONFIG_ACCEPTED";

        public const string ConfigDenied = "CONFIG_DENIED";

        public const string ConfigTimeout = "CONFIG_TIMEOUT";
    }
}
