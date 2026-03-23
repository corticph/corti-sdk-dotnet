using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(AgentsExpertReferenceType.AgentsExpertReferenceTypeSerializer))]
[Serializable]
public readonly record struct AgentsExpertReferenceType : IStringEnum
{
    public static readonly AgentsExpertReferenceType Reference = new(Values.Reference);

    public AgentsExpertReferenceType(string value)
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
    public static AgentsExpertReferenceType FromCustom(string value)
    {
        return new AgentsExpertReferenceType(value);
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

    public static bool operator ==(AgentsExpertReferenceType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentsExpertReferenceType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentsExpertReferenceType value) => value.Value;

    public static explicit operator AgentsExpertReferenceType(string value) => new(value);

    internal class AgentsExpertReferenceTypeSerializer : JsonConverter<AgentsExpertReferenceType>
    {
        public override AgentsExpertReferenceType Read(
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
            return new AgentsExpertReferenceType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentsExpertReferenceType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentsExpertReferenceType ReadAsPropertyName(
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
            return new AgentsExpertReferenceType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentsExpertReferenceType value,
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
        public const string Reference = "reference";
    }
}
