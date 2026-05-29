using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti.Documents;

[JsonConverter(typeof(ListTemplatesRequestSource.ListTemplatesRequestSourceSerializer))]
[Serializable]
public readonly record struct ListTemplatesRequestSource : IStringEnum
{
    public static readonly ListTemplatesRequestSource User = new(Values.User);

    public static readonly ListTemplatesRequestSource Corti = new(Values.Corti);

    public ListTemplatesRequestSource(string value)
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
    public static ListTemplatesRequestSource FromCustom(string value)
    {
        return new ListTemplatesRequestSource(value);
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

    public static bool operator ==(ListTemplatesRequestSource value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListTemplatesRequestSource value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListTemplatesRequestSource value) => value.Value;

    public static explicit operator ListTemplatesRequestSource(string value) => new(value);

    internal class ListTemplatesRequestSourceSerializer : JsonConverter<ListTemplatesRequestSource>
    {
        public override ListTemplatesRequestSource Read(
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
            return new ListTemplatesRequestSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListTemplatesRequestSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListTemplatesRequestSource ReadAsPropertyName(
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
            return new ListTemplatesRequestSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListTemplatesRequestSource value,
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
