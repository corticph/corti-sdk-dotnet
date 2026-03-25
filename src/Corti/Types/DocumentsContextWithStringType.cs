using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(DocumentsContextWithStringType.DocumentsContextWithStringTypeSerializer))]
[Serializable]
public readonly record struct DocumentsContextWithStringType : IStringEnum
{
    public static readonly DocumentsContextWithStringType String = new(Values.String);

    public DocumentsContextWithStringType(string value)
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
    public static DocumentsContextWithStringType FromCustom(string value)
    {
        return new DocumentsContextWithStringType(value);
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

    public static bool operator ==(DocumentsContextWithStringType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DocumentsContextWithStringType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DocumentsContextWithStringType value) => value.Value;

    public static explicit operator DocumentsContextWithStringType(string value) => new(value);

    internal class DocumentsContextWithStringTypeSerializer
        : JsonConverter<DocumentsContextWithStringType>
    {
        public override DocumentsContextWithStringType Read(
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
            return new DocumentsContextWithStringType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DocumentsContextWithStringType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DocumentsContextWithStringType ReadAsPropertyName(
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
            return new DocumentsContextWithStringType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DocumentsContextWithStringType value,
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
        public const string String = "string";
    }
}
