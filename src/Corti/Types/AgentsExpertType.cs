using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(AgentsExpertType.AgentsExpertTypeSerializer))]
[Serializable]
public readonly record struct AgentsExpertType : IStringEnum
{
    public static readonly AgentsExpertType Expert = new(Values.Expert);

    public AgentsExpertType(string value)
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
    public static AgentsExpertType FromCustom(string value)
    {
        return new AgentsExpertType(value);
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

    public static bool operator ==(AgentsExpertType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentsExpertType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentsExpertType value) => value.Value;

    public static explicit operator AgentsExpertType(string value) => new(value);

    internal class AgentsExpertTypeSerializer : JsonConverter<AgentsExpertType>
    {
        public override AgentsExpertType Read(
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
            return new AgentsExpertType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentsExpertType value,
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
        public const string Expert = "expert";
    }
}
