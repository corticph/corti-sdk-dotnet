using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(AgentsMessageRole.AgentsMessageRoleSerializer))]
[Serializable]
public readonly record struct AgentsMessageRole : IStringEnum
{
    public static readonly AgentsMessageRole User = new(Values.User);

    public static readonly AgentsMessageRole Agent = new(Values.Agent);

    public AgentsMessageRole(string value)
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
    public static AgentsMessageRole FromCustom(string value)
    {
        return new AgentsMessageRole(value);
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

    public static bool operator ==(AgentsMessageRole value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentsMessageRole value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentsMessageRole value) => value.Value;

    public static explicit operator AgentsMessageRole(string value) => new(value);

    internal class AgentsMessageRoleSerializer : JsonConverter<AgentsMessageRole>
    {
        public override AgentsMessageRole Read(
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
            return new AgentsMessageRole(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentsMessageRole value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentsMessageRole ReadAsPropertyName(
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
            return new AgentsMessageRole(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentsMessageRole value,
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
        public const string User = "user";

        public const string Agent = "agent";
    }
}
