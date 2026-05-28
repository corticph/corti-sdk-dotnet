using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(SectionSource.SectionSourceSerializer))]
[Serializable]
public readonly record struct SectionSource : IStringEnum
{
    public static readonly SectionSource User = new(Values.User);

    public static readonly SectionSource Corti = new(Values.Corti);

    public SectionSource(string value)
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
    public static SectionSource FromCustom(string value)
    {
        return new SectionSource(value);
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

    public static bool operator ==(SectionSource value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SectionSource value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SectionSource value) => value.Value;

    public static explicit operator SectionSource(string value) => new(value);

    internal class SectionSourceSerializer : JsonConverter<SectionSource>
    {
        public override SectionSource Read(
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
            return new SectionSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SectionSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SectionSource ReadAsPropertyName(
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
            return new SectionSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SectionSource value,
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
        public const string User = "user";

        public const string Corti = "corti";
    }
}
