using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(CommonSortingDirectionEnum.CommonSortingDirectionEnumSerializer))]
[Serializable]
public readonly record struct CommonSortingDirectionEnum : IStringEnum
{
    public static readonly CommonSortingDirectionEnum Asc = new(Values.Asc);

    public static readonly CommonSortingDirectionEnum Desc = new(Values.Desc);

    public CommonSortingDirectionEnum(string value)
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
    public static CommonSortingDirectionEnum FromCustom(string value)
    {
        return new CommonSortingDirectionEnum(value);
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

    public static bool operator ==(CommonSortingDirectionEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CommonSortingDirectionEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CommonSortingDirectionEnum value) => value.Value;

    public static explicit operator CommonSortingDirectionEnum(string value) => new(value);

    internal class CommonSortingDirectionEnumSerializer : JsonConverter<CommonSortingDirectionEnum>
    {
        public override CommonSortingDirectionEnum Read(
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
            return new CommonSortingDirectionEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CommonSortingDirectionEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Asc = "asc";

        public const string Desc = "desc";
    }
}
