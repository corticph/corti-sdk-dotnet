using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(StringEnumSerializer<AgentsCreateMcpServerTransportType>))]
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
