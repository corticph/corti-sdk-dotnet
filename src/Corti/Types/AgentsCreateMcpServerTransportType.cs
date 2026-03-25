using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(
    typeof(AgentsCreateMcpServerTransportType.AgentsCreateMcpServerTransportTypeSerializer)
)]
[Serializable]
public readonly record struct AgentsCreateMcpServerTransportType : IStringEnum
{
    public static readonly AgentsCreateMcpServerTransportType Stdio = new(Values.Stdio);

    public static readonly AgentsCreateMcpServerTransportType StreamableHttp = new(
        Values.StreamableHttp
    );

    public static readonly AgentsCreateMcpServerTransportType Sse = new(Values.Sse);

    public AgentsCreateMcpServerTransportType(string value)
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
    public static AgentsCreateMcpServerTransportType FromCustom(string value)
    {
        return new AgentsCreateMcpServerTransportType(value);
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

    public static bool operator ==(AgentsCreateMcpServerTransportType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentsCreateMcpServerTransportType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentsCreateMcpServerTransportType value) => value.Value;

    public static explicit operator AgentsCreateMcpServerTransportType(string value) => new(value);

    internal class AgentsCreateMcpServerTransportTypeSerializer
        : JsonConverter<AgentsCreateMcpServerTransportType>
    {
        public override AgentsCreateMcpServerTransportType Read(
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
            return new AgentsCreateMcpServerTransportType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentsCreateMcpServerTransportType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentsCreateMcpServerTransportType ReadAsPropertyName(
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
            return new AgentsCreateMcpServerTransportType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentsCreateMcpServerTransportType value,
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
        public const string Stdio = "stdio";

        public const string StreamableHttp = "streamable_http";

        public const string Sse = "sse";
    }
}
