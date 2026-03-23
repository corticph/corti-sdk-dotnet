using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(CommonTextContextType.CommonTextContextTypeSerializer))]
[Serializable]
public readonly record struct CommonTextContextType : IStringEnum
{
    public static readonly CommonTextContextType Text = new(Values.Text);

    public CommonTextContextType(string value)
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
    public static CommonTextContextType FromCustom(string value)
    {
        return new CommonTextContextType(value);
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

    public static bool operator ==(CommonTextContextType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CommonTextContextType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CommonTextContextType value) => value.Value;

    public static explicit operator CommonTextContextType(string value) => new(value);

    internal class CommonTextContextTypeSerializer : JsonConverter<CommonTextContextType>
    {
        public override CommonTextContextType Read(
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
            return new CommonTextContextType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CommonTextContextType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CommonTextContextType ReadAsPropertyName(
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
            return new CommonTextContextType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CommonTextContextType value,
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
        public const string Text = "text";
    }
}
