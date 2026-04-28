using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(StreamConfigRetentionPolicy.StreamConfigRetentionPolicySerializer))]
[Serializable]
public readonly record struct StreamConfigRetentionPolicy : IStringEnum
{
    public static readonly StreamConfigRetentionPolicy Retain = new(Values.Retain);

    public static readonly StreamConfigRetentionPolicy None = new(Values.None);

    public StreamConfigRetentionPolicy(string value)
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
    public static StreamConfigRetentionPolicy FromCustom(string value)
    {
        return new StreamConfigRetentionPolicy(value);
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

    public static bool operator ==(StreamConfigRetentionPolicy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StreamConfigRetentionPolicy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StreamConfigRetentionPolicy value) => value.Value;

    public static explicit operator StreamConfigRetentionPolicy(string value) => new(value);

    internal class StreamConfigRetentionPolicySerializer
        : JsonConverter<StreamConfigRetentionPolicy>
    {
        public override StreamConfigRetentionPolicy Read(
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
            return new StreamConfigRetentionPolicy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            StreamConfigRetentionPolicy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override StreamConfigRetentionPolicy ReadAsPropertyName(
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
            return new StreamConfigRetentionPolicy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            StreamConfigRetentionPolicy value,
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
