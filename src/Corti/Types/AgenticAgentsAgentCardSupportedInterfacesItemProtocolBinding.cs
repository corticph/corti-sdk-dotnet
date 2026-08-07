using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(AgenticAgentsAgentCardSupportedInterfacesItemProtocolBindingSerializer))]
public enum AgenticAgentsAgentCardSupportedInterfacesItemProtocolBinding
{
    [EnumMember(Value = "JSONRPC")]
    Jsonrpc,

    [EnumMember(Value = "HTTP+JSON")]
    HttpJson,
}

internal class AgenticAgentsAgentCardSupportedInterfacesItemProtocolBindingSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AgenticAgentsAgentCardSupportedInterfacesItemProtocolBinding>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AgenticAgentsAgentCardSupportedInterfacesItemProtocolBinding
    > _stringToEnum = new()
    {
        { "JSONRPC", AgenticAgentsAgentCardSupportedInterfacesItemProtocolBinding.Jsonrpc },
        { "HTTP+JSON", AgenticAgentsAgentCardSupportedInterfacesItemProtocolBinding.HttpJson },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AgenticAgentsAgentCardSupportedInterfacesItemProtocolBinding,
        string
    > _enumToString = new()
    {
        { AgenticAgentsAgentCardSupportedInterfacesItemProtocolBinding.Jsonrpc, "JSONRPC" },
        { AgenticAgentsAgentCardSupportedInterfacesItemProtocolBinding.HttpJson, "HTTP+JSON" },
    };

    public override AgenticAgentsAgentCardSupportedInterfacesItemProtocolBinding Read(
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
        AgenticAgentsAgentCardSupportedInterfacesItemProtocolBinding value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AgenticAgentsAgentCardSupportedInterfacesItemProtocolBinding ReadAsPropertyName(
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
        AgenticAgentsAgentCardSupportedInterfacesItemProtocolBinding value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
