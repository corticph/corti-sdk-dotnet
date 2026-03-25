using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(
    typeof(AgentsCreateMcpServerAuthorizationType.AgentsCreateMcpServerAuthorizationTypeSerializer)
)]
[Serializable]
public readonly record struct AgentsCreateMcpServerAuthorizationType : IStringEnum
{
    public static readonly AgentsCreateMcpServerAuthorizationType None = new(Values.None);

    public static readonly AgentsCreateMcpServerAuthorizationType Bearer = new(Values.Bearer);

    public static readonly AgentsCreateMcpServerAuthorizationType Inherit = new(Values.Inherit);

    public static readonly AgentsCreateMcpServerAuthorizationType Oauth20 = new(Values.Oauth20);

    public AgentsCreateMcpServerAuthorizationType(string value)
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
    public static AgentsCreateMcpServerAuthorizationType FromCustom(string value)
    {
        return new AgentsCreateMcpServerAuthorizationType(value);
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

    public static bool operator ==(AgentsCreateMcpServerAuthorizationType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentsCreateMcpServerAuthorizationType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentsCreateMcpServerAuthorizationType value) =>
        value.Value;

    public static explicit operator AgentsCreateMcpServerAuthorizationType(string value) =>
        new(value);

    internal class AgentsCreateMcpServerAuthorizationTypeSerializer
        : JsonConverter<AgentsCreateMcpServerAuthorizationType>
    {
        public override AgentsCreateMcpServerAuthorizationType Read(
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
            return new AgentsCreateMcpServerAuthorizationType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentsCreateMcpServerAuthorizationType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentsCreateMcpServerAuthorizationType ReadAsPropertyName(
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
            return new AgentsCreateMcpServerAuthorizationType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentsCreateMcpServerAuthorizationType value,
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

        public const string Bearer = "bearer";

        public const string Inherit = "inherit";

        public const string Oauth20 = "oauth2.0";
    }
}
