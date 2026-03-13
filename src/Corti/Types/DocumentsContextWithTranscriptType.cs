using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(
    typeof(DocumentsContextWithTranscriptType.DocumentsContextWithTranscriptTypeSerializer)
)]
[Serializable]
public readonly record struct DocumentsContextWithTranscriptType : IStringEnum
{
    public static readonly DocumentsContextWithTranscriptType Transcript = new(Values.Transcript);

    public DocumentsContextWithTranscriptType(string value)
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
    public static DocumentsContextWithTranscriptType FromCustom(string value)
    {
        return new DocumentsContextWithTranscriptType(value);
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

    public static bool operator ==(DocumentsContextWithTranscriptType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DocumentsContextWithTranscriptType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DocumentsContextWithTranscriptType value) => value.Value;

    public static explicit operator DocumentsContextWithTranscriptType(string value) => new(value);

    internal class DocumentsContextWithTranscriptTypeSerializer
        : JsonConverter<DocumentsContextWithTranscriptType>
    {
        public override DocumentsContextWithTranscriptType Read(
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
            return new DocumentsContextWithTranscriptType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DocumentsContextWithTranscriptType value,
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
        public const string Transcript = "transcript";
    }
}
