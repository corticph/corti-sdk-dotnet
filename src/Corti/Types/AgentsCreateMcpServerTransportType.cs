using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(AgentsCreateMcpServerTransportTypeSerializer))]
public enum AgentsCreateMcpServerTransportType
{
    [EnumMember(Value = "stdio")]
    Stdio,

    [EnumMember(Value = "streamable_http")]
    StreamableHttp,

    [EnumMember(Value = "sse")]
    Sse,
}

internal class AgentsCreateMcpServerTransportTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AgentsCreateMcpServerTransportType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AgentsCreateMcpServerTransportType
    > _stringToEnum = new()
    {
        { "stdio", AgentsCreateMcpServerTransportType.Stdio },
        { "streamable_http", AgentsCreateMcpServerTransportType.StreamableHttp },
        { "sse", AgentsCreateMcpServerTransportType.Sse },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AgentsCreateMcpServerTransportType,
        string
    > _enumToString = new()
    {
        { AgentsCreateMcpServerTransportType.Stdio, "stdio" },
        { AgentsCreateMcpServerTransportType.StreamableHttp, "streamable_http" },
        { AgentsCreateMcpServerTransportType.Sse, "sse" },
    };

    public override AgentsCreateMcpServerTransportType Read(
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
        AgentsCreateMcpServerTransportType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AgentsCreateMcpServerTransportType ReadAsPropertyName(
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
        AgentsCreateMcpServerTransportType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
