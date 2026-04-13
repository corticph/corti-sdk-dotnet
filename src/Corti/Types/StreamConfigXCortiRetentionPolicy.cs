using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(
    typeof(StreamConfigXCortiRetentionPolicy.StreamConfigXCortiRetentionPolicySerializer)
)]
[Serializable]
public readonly record struct StreamConfigXCortiRetentionPolicy : IStringEnum
{
    public static readonly StreamConfigXCortiRetentionPolicy Retain = new(Values.Retain);

    public static readonly StreamConfigXCortiRetentionPolicy None = new(Values.None);

    public StreamConfigXCortiRetentionPolicy(string value)
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
    public static StreamConfigXCortiRetentionPolicy FromCustom(string value)
    {
        return new StreamConfigXCortiRetentionPolicy(value);
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

    public static bool operator ==(StreamConfigXCortiRetentionPolicy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StreamConfigXCortiRetentionPolicy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StreamConfigXCortiRetentionPolicy value) => value.Value;

    public static explicit operator StreamConfigXCortiRetentionPolicy(string value) => new(value);

    internal class StreamConfigXCortiRetentionPolicySerializer
        : JsonConverter<StreamConfigXCortiRetentionPolicy>
    {
        public override StreamConfigXCortiRetentionPolicy Read(
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
            return new StreamConfigXCortiRetentionPolicy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            StreamConfigXCortiRetentionPolicy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override StreamConfigXCortiRetentionPolicy ReadAsPropertyName(
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
            return new StreamConfigXCortiRetentionPolicy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            StreamConfigXCortiRetentionPolicy value,
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
        public const string Retain = "retain";

        public const string None = "none";
    }
}
