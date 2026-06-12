using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(GuidedSourceFilter.GuidedSourceFilterSerializer))]
[Serializable]
public readonly record struct GuidedSourceFilter : IStringEnum
{
    public static readonly GuidedSourceFilter User = new(Values.User);

    public static readonly GuidedSourceFilter Corti = new(Values.Corti);

    public GuidedSourceFilter(string value)
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
    public static GuidedSourceFilter FromCustom(string value)
    {
        return new GuidedSourceFilter(value);
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

    public static bool operator ==(GuidedSourceFilter value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GuidedSourceFilter value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GuidedSourceFilter value) => value.Value;

    public static explicit operator GuidedSourceFilter(string value) => new(value);

    internal class GuidedSourceFilterSerializer : JsonConverter<GuidedSourceFilter>
    {
        public override GuidedSourceFilter Read(
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
            return new GuidedSourceFilter(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GuidedSourceFilter value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GuidedSourceFilter ReadAsPropertyName(
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
            return new GuidedSourceFilter(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GuidedSourceFilter value,
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
