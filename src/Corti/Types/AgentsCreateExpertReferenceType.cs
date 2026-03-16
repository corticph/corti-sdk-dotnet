using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(AgentsCreateExpertReferenceType.AgentsCreateExpertReferenceTypeSerializer))]
[Serializable]
public readonly record struct AgentsCreateExpertReferenceType : IStringEnum
{
    public static readonly AgentsCreateExpertReferenceType Reference = new(Values.Reference);

    public AgentsCreateExpertReferenceType(string value)
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
    public static AgentsCreateExpertReferenceType FromCustom(string value)
    {
        return new AgentsCreateExpertReferenceType(value);
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

    public static bool operator ==(AgentsCreateExpertReferenceType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentsCreateExpertReferenceType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentsCreateExpertReferenceType value) => value.Value;

    public static explicit operator AgentsCreateExpertReferenceType(string value) => new(value);

    internal class AgentsCreateExpertReferenceTypeSerializer
        : JsonConverter<AgentsCreateExpertReferenceType>
    {
        public override AgentsCreateExpertReferenceType Read(
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
            return new AgentsCreateExpertReferenceType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentsCreateExpertReferenceType value,
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
        public const string Reference = "reference";
    }
}
