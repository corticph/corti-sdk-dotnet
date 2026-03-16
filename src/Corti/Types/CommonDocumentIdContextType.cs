using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(CommonDocumentIdContextType.CommonDocumentIdContextTypeSerializer))]
[Serializable]
public readonly record struct CommonDocumentIdContextType : IStringEnum
{
    public static readonly CommonDocumentIdContextType DocumentId = new(Values.DocumentId);

    public CommonDocumentIdContextType(string value)
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
    public static CommonDocumentIdContextType FromCustom(string value)
    {
        return new CommonDocumentIdContextType(value);
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

    public static bool operator ==(CommonDocumentIdContextType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CommonDocumentIdContextType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CommonDocumentIdContextType value) => value.Value;

    public static explicit operator CommonDocumentIdContextType(string value) => new(value);

    internal class CommonDocumentIdContextTypeSerializer
        : JsonConverter<CommonDocumentIdContextType>
    {
        public override CommonDocumentIdContextType Read(
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
            return new CommonDocumentIdContextType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CommonDocumentIdContextType value,
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
        public const string DocumentId = "documentId";
    }
}
