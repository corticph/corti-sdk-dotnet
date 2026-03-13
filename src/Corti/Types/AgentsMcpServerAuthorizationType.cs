using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(AgentsMcpServerAuthorizationType.AgentsMcpServerAuthorizationTypeSerializer))]
[Serializable]
public readonly record struct AgentsMcpServerAuthorizationType : IStringEnum
{
    public static readonly AgentsMcpServerAuthorizationType None = new(Values.None);

    public static readonly AgentsMcpServerAuthorizationType Bearer = new(Values.Bearer);

    public static readonly AgentsMcpServerAuthorizationType Inherit = new(Values.Inherit);

    public static readonly AgentsMcpServerAuthorizationType Oauth20 = new(Values.Oauth20);

    public AgentsMcpServerAuthorizationType(string value)
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
    public static AgentsMcpServerAuthorizationType FromCustom(string value)
    {
        return new AgentsMcpServerAuthorizationType(value);
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

    public static bool operator ==(AgentsMcpServerAuthorizationType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentsMcpServerAuthorizationType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentsMcpServerAuthorizationType value) => value.Value;

    public static explicit operator AgentsMcpServerAuthorizationType(string value) => new(value);

    internal class AgentsMcpServerAuthorizationTypeSerializer
        : JsonConverter<AgentsMcpServerAuthorizationType>
    {
        public override AgentsMcpServerAuthorizationType Read(
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
            return new AgentsMcpServerAuthorizationType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentsMcpServerAuthorizationType value,
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
        public const string None = "none";

        public const string Bearer = "bearer";

        public const string Inherit = "inherit";

        public const string Oauth20 = "oauth2.0";
    }
}
