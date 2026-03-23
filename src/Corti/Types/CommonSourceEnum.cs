using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(CommonSourceEnum.CommonSourceEnumSerializer))]
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

    internal class CommonSourceEnumSerializer : JsonConverter<CommonSourceEnum>
    {
        public override CommonSourceEnum Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new CommonSourceEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CommonSourceEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CommonSourceEnum ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new CommonSourceEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CommonSourceEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

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
