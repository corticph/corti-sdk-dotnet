using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(
    typeof(StreamConfigModeFactGenerationInterval.StreamConfigModeFactGenerationIntervalSerializer)
)]
[Serializable]
public readonly record struct StreamConfigModeFactGenerationInterval : IStringEnum
{
    public static readonly StreamConfigModeFactGenerationInterval Fixed = new(Values.Fixed);

    public static readonly StreamConfigModeFactGenerationInterval FastInit = new(Values.FastInit);

    public StreamConfigModeFactGenerationInterval(string value)
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
    public static StreamConfigModeFactGenerationInterval FromCustom(string value)
    {
        return new StreamConfigModeFactGenerationInterval(value);
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

    public static bool operator ==(StreamConfigModeFactGenerationInterval value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StreamConfigModeFactGenerationInterval value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StreamConfigModeFactGenerationInterval value) =>
        value.Value;

    public static explicit operator StreamConfigModeFactGenerationInterval(string value) =>
        new(value);

    internal class StreamConfigModeFactGenerationIntervalSerializer
        : JsonConverter<StreamConfigModeFactGenerationInterval>
    {
        public override StreamConfigModeFactGenerationInterval Read(
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
            return new StreamConfigModeFactGenerationInterval(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            StreamConfigModeFactGenerationInterval value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override StreamConfigModeFactGenerationInterval ReadAsPropertyName(
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
            return new StreamConfigModeFactGenerationInterval(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            StreamConfigModeFactGenerationInterval value,
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
        public const string Fixed = "fixed";

        public const string FastInit = "fast_init";
    }
}
