using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(AgentsMcpServerTransportTypeSerializer))]
public enum AgentsMcpServerTransportType
{
    [EnumMember(Value = "stdio")]
    Stdio,

    [EnumMember(Value = "streamable_http")]
    StreamableHttp,

    [EnumMember(Value = "sse")]
    Sse,
}

internal class AgentsMcpServerTransportTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AgentsMcpServerTransportType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AgentsMcpServerTransportType
    > _stringToEnum = new()
    {
        { "stdio", AgentsMcpServerTransportType.Stdio },
        { "streamable_http", AgentsMcpServerTransportType.StreamableHttp },
        { "sse", AgentsMcpServerTransportType.Sse },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AgentsMcpServerTransportType,
        string
    > _enumToString = new()
    {
        { AgentsMcpServerTransportType.Stdio, "stdio" },
        { AgentsMcpServerTransportType.StreamableHttp, "streamable_http" },
        { AgentsMcpServerTransportType.Sse, "sse" },
    };

    public override AgentsMcpServerTransportType Read(
        ref global::System.Text.Json.Utf8JsonReader reader,
        global::System.Type typeToConvert,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        var stringValue =
            reader.GetString()
            ?? throw new global::System.Exception("The JSON value could not be read as a string.");
        return _stringToEnum.TryGetValue(stringValue, out var enumValue) ? enumValue : default;
    }

    public override void Write(
        global::System.Text.Json.Utf8JsonWriter writer,
        AgentsMcpServerTransportType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AgentsMcpServerTransportType ReadAsPropertyName(
        ref global::System.Text.Json.Utf8JsonReader reader,
        global::System.Type typeToConvert,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        var stringValue =
            reader.GetString()
            ?? throw new global::System.Exception(
                "The JSON property name could not be read as a string."
            );
        return _stringToEnum.TryGetValue(stringValue, out var enumValue) ? enumValue : default;
    }

    public override void WriteAsPropertyName(
        global::System.Text.Json.Utf8JsonWriter writer,
        AgentsMcpServerTransportType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
