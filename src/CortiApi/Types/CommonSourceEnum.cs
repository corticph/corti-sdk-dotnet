using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(StringEnumSerializer<CommonSourceEnum>))]
[Serializable]
public readonly record struct CommonSourceEnum : IStringEnum
{
    public static readonly CommonSourceEnum Core = new(Values.Core);

    public static readonly CommonSourceEnum System = new(Values.System);

    public static readonly CommonSourceEnum User = new(Values.User);

    public CommonSourceEnum(string value)
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
    public static CommonSourceEnum FromCustom(string value)
    {
        return new CommonSourceEnum(value);
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

    public static bool operator ==(CommonSourceEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CommonSourceEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CommonSourceEnum value) => value.Value;

    public static explicit operator CommonSourceEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Core = "core";

        public const string System = "system";

        public const string User = "user";
    }
}
