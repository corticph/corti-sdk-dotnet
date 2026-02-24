using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(StringEnumSerializer<StreamConfigStatusMessageType>))]
[Serializable]
public readonly record struct StreamConfigStatusMessageType : IStringEnum
{
    public static readonly StreamConfigStatusMessageType ConfigAccepted = new(
        Values.ConfigAccepted
    );

    public static readonly StreamConfigStatusMessageType ConfigDenied = new(Values.ConfigDenied);

    public static readonly StreamConfigStatusMessageType ConfigMissing = new(Values.ConfigMissing);

    public static readonly StreamConfigStatusMessageType ConfigNotProvided = new(
        Values.ConfigNotProvided
    );

    public static readonly StreamConfigStatusMessageType ConfigAlreadyReceived = new(
        Values.ConfigAlreadyReceived
    );

    public static readonly StreamConfigStatusMessageType ConfigTimeout = new(Values.ConfigTimeout);

    public StreamConfigStatusMessageType(string value)
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
    public static StreamConfigStatusMessageType FromCustom(string value)
    {
        return new StreamConfigStatusMessageType(value);
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

    public static bool operator ==(StreamConfigStatusMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StreamConfigStatusMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StreamConfigStatusMessageType value) => value.Value;

    public static explicit operator StreamConfigStatusMessageType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string ConfigAccepted = "CONFIG_ACCEPTED";

        public const string ConfigDenied = "CONFIG_DENIED";

        public const string ConfigMissing = "CONFIG_MISSING";

        public const string ConfigNotProvided = "CONFIG_NOT_PROVIDED";

        public const string ConfigAlreadyReceived = "CONFIG_ALREADY_RECEIVED";

        public const string ConfigTimeout = "CONFIG_TIMEOUT";
    }
}
