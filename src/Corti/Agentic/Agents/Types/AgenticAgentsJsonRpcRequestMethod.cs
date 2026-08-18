using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti.Agentic;

[JsonConverter(typeof(AgenticAgentsJsonRpcRequestMethodSerializer))]
public enum AgenticAgentsJsonRpcRequestMethod
{
    [EnumMember(Value = "SendMessage")]
    SendMessage,

    [EnumMember(Value = "SendStreamingMessage")]
    SendStreamingMessage,

    [EnumMember(Value = "GetTask")]
    GetTask,

    [EnumMember(Value = "ListTasks")]
    ListTasks,

    [EnumMember(Value = "CancelTask")]
    CancelTask,

    [EnumMember(Value = "SubscribeToTask")]
    SubscribeToTask,
}

internal class AgenticAgentsJsonRpcRequestMethodSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AgenticAgentsJsonRpcRequestMethod>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AgenticAgentsJsonRpcRequestMethod
    > _stringToEnum = new()
    {
        { "SendMessage", AgenticAgentsJsonRpcRequestMethod.SendMessage },
        { "SendStreamingMessage", AgenticAgentsJsonRpcRequestMethod.SendStreamingMessage },
        { "GetTask", AgenticAgentsJsonRpcRequestMethod.GetTask },
        { "ListTasks", AgenticAgentsJsonRpcRequestMethod.ListTasks },
        { "CancelTask", AgenticAgentsJsonRpcRequestMethod.CancelTask },
        { "SubscribeToTask", AgenticAgentsJsonRpcRequestMethod.SubscribeToTask },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AgenticAgentsJsonRpcRequestMethod,
        string
    > _enumToString = new()
    {
        { AgenticAgentsJsonRpcRequestMethod.SendMessage, "SendMessage" },
        { AgenticAgentsJsonRpcRequestMethod.SendStreamingMessage, "SendStreamingMessage" },
        { AgenticAgentsJsonRpcRequestMethod.GetTask, "GetTask" },
        { AgenticAgentsJsonRpcRequestMethod.ListTasks, "ListTasks" },
        { AgenticAgentsJsonRpcRequestMethod.CancelTask, "CancelTask" },
        { AgenticAgentsJsonRpcRequestMethod.SubscribeToTask, "SubscribeToTask" },
    };

    public override AgenticAgentsJsonRpcRequestMethod Read(
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
        AgenticAgentsJsonRpcRequestMethod value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AgenticAgentsJsonRpcRequestMethod ReadAsPropertyName(
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
        AgenticAgentsJsonRpcRequestMethod value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
