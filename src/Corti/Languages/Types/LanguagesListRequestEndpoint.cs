using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(LanguagesListRequestEndpoint.LanguagesListRequestEndpointSerializer))]
[Serializable]
public readonly record struct LanguagesListRequestEndpoint : IStringEnum
{
    public static readonly LanguagesListRequestEndpoint Streams = new(Values.Streams);

    public static readonly LanguagesListRequestEndpoint Transcribe = new(Values.Transcribe);

    public static readonly LanguagesListRequestEndpoint Transcripts = new(Values.Transcripts);

    public LanguagesListRequestEndpoint(string value)
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
    public static LanguagesListRequestEndpoint FromCustom(string value)
    {
        return new LanguagesListRequestEndpoint(value);
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

    public static bool operator ==(LanguagesListRequestEndpoint value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LanguagesListRequestEndpoint value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LanguagesListRequestEndpoint value) => value.Value;

    public static explicit operator LanguagesListRequestEndpoint(string value) => new(value);

    internal class LanguagesListRequestEndpointSerializer
        : JsonConverter<LanguagesListRequestEndpoint>
    {
        public override LanguagesListRequestEndpoint Read(
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
            return new LanguagesListRequestEndpoint(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LanguagesListRequestEndpoint value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override LanguagesListRequestEndpoint ReadAsPropertyName(
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
            return new LanguagesListRequestEndpoint(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LanguagesListRequestEndpoint value,
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
        public const string Streams = "streams";

        public const string Transcribe = "transcribe";

        public const string Transcripts = "transcripts";
    }
}
