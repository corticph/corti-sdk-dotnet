using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti.Agentic;

[JsonConverter(typeof(A2AjsonrpcRequestMethodSerializer))]
public enum A2AjsonrpcRequestMethod
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

internal class A2AjsonrpcRequestMethodSerializer
    : global::System.Text.Json.Serialization.JsonConverter<A2AjsonrpcRequestMethod>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        A2AjsonrpcRequestMethod
    > _stringToEnum = new()
    {
        { "SendMessage", A2AjsonrpcRequestMethod.SendMessage },
        { "SendStreamingMessage", A2AjsonrpcRequestMethod.SendStreamingMessage },
        { "GetTask", A2AjsonrpcRequestMethod.GetTask },
        { "ListTasks", A2AjsonrpcRequestMethod.ListTasks },
        { "CancelTask", A2AjsonrpcRequestMethod.CancelTask },
        { "SubscribeToTask", A2AjsonrpcRequestMethod.SubscribeToTask },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        A2AjsonrpcRequestMethod,
        string
    > _enumToString = new()
    {
        { A2AjsonrpcRequestMethod.SendMessage, "SendMessage" },
        { A2AjsonrpcRequestMethod.SendStreamingMessage, "SendStreamingMessage" },
        { A2AjsonrpcRequestMethod.GetTask, "GetTask" },
        { A2AjsonrpcRequestMethod.ListTasks, "ListTasks" },
        { A2AjsonrpcRequestMethod.CancelTask, "CancelTask" },
        { A2AjsonrpcRequestMethod.SubscribeToTask, "SubscribeToTask" },
    };

    public override A2AjsonrpcRequestMethod Read(
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
        A2AjsonrpcRequestMethod value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override A2AjsonrpcRequestMethod ReadAsPropertyName(
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
        A2AjsonrpcRequestMethod value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
