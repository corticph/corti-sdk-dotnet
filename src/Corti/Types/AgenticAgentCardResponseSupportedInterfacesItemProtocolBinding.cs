using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(AgenticAgentCardResponseSupportedInterfacesItemProtocolBindingSerializer))]
public enum AgenticAgentCardResponseSupportedInterfacesItemProtocolBinding
{
    [EnumMember(Value = "JSONRPC")]
    Jsonrpc,

    [EnumMember(Value = "HTTP+JSON")]
    HttpJson,
}

internal class AgenticAgentCardResponseSupportedInterfacesItemProtocolBindingSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AgenticAgentCardResponseSupportedInterfacesItemProtocolBinding>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AgenticAgentCardResponseSupportedInterfacesItemProtocolBinding
    > _stringToEnum = new()
    {
        { "JSONRPC", AgenticAgentCardResponseSupportedInterfacesItemProtocolBinding.Jsonrpc },
        { "HTTP+JSON", AgenticAgentCardResponseSupportedInterfacesItemProtocolBinding.HttpJson },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AgenticAgentCardResponseSupportedInterfacesItemProtocolBinding,
        string
    > _enumToString = new()
    {
        { AgenticAgentCardResponseSupportedInterfacesItemProtocolBinding.Jsonrpc, "JSONRPC" },
        { AgenticAgentCardResponseSupportedInterfacesItemProtocolBinding.HttpJson, "HTTP+JSON" },
    };

    public override AgenticAgentCardResponseSupportedInterfacesItemProtocolBinding Read(
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
        AgenticAgentCardResponseSupportedInterfacesItemProtocolBinding value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AgenticAgentCardResponseSupportedInterfacesItemProtocolBinding ReadAsPropertyName(
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
        AgenticAgentCardResponseSupportedInterfacesItemProtocolBinding value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
