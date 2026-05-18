using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(
    typeof(GenerateDocumentsRequestXCortiRetentionPolicy.GenerateDocumentsRequestXCortiRetentionPolicySerializer)
)]
[Serializable]
public readonly record struct GenerateDocumentsRequestXCortiRetentionPolicy : IStringEnum
{
    public static readonly GenerateDocumentsRequestXCortiRetentionPolicy None = new(Values.None);

    public GenerateDocumentsRequestXCortiRetentionPolicy(string value)
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
    public static GenerateDocumentsRequestXCortiRetentionPolicy FromCustom(string value)
    {
        return new GenerateDocumentsRequestXCortiRetentionPolicy(value);
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

    public static bool operator ==(
        GenerateDocumentsRequestXCortiRetentionPolicy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GenerateDocumentsRequestXCortiRetentionPolicy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(GenerateDocumentsRequestXCortiRetentionPolicy value) =>
        value.Value;

    public static explicit operator GenerateDocumentsRequestXCortiRetentionPolicy(string value) =>
        new(value);

    internal class GenerateDocumentsRequestXCortiRetentionPolicySerializer
        : JsonConverter<GenerateDocumentsRequestXCortiRetentionPolicy>
    {
        public override GenerateDocumentsRequestXCortiRetentionPolicy Read(
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
            return new GenerateDocumentsRequestXCortiRetentionPolicy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GenerateDocumentsRequestXCortiRetentionPolicy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GenerateDocumentsRequestXCortiRetentionPolicy ReadAsPropertyName(
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
            return new GenerateDocumentsRequestXCortiRetentionPolicy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GenerateDocumentsRequestXCortiRetentionPolicy value,
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
        public const string None = "none";
    }
}
