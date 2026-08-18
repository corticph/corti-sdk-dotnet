using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(CommonTaskStateSerializer))]
public enum CommonTaskState
{
    [EnumMember(Value = "TASK_STATE_SUBMITTED")]
    TaskStateSubmitted,

    [EnumMember(Value = "TASK_STATE_WORKING")]
    TaskStateWorking,

    [EnumMember(Value = "TASK_STATE_COMPLETED")]
    TaskStateCompleted,

    [EnumMember(Value = "TASK_STATE_FAILED")]
    TaskStateFailed,

    [EnumMember(Value = "TASK_STATE_CANCELED")]
    TaskStateCanceled,

    [EnumMember(Value = "TASK_STATE_INPUT_REQUIRED")]
    TaskStateInputRequired,

    [EnumMember(Value = "TASK_STATE_REJECTED")]
    TaskStateRejected,

    [EnumMember(Value = "TASK_STATE_AUTH_REQUIRED")]
    TaskStateAuthRequired,
}

internal class CommonTaskStateSerializer
    : global::System.Text.Json.Serialization.JsonConverter<CommonTaskState>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        CommonTaskState
    > _stringToEnum = new()
    {
        { "TASK_STATE_SUBMITTED", CommonTaskState.TaskStateSubmitted },
        { "TASK_STATE_WORKING", CommonTaskState.TaskStateWorking },
        { "TASK_STATE_COMPLETED", CommonTaskState.TaskStateCompleted },
        { "TASK_STATE_FAILED", CommonTaskState.TaskStateFailed },
        { "TASK_STATE_CANCELED", CommonTaskState.TaskStateCanceled },
        { "TASK_STATE_INPUT_REQUIRED", CommonTaskState.TaskStateInputRequired },
        { "TASK_STATE_REJECTED", CommonTaskState.TaskStateRejected },
        { "TASK_STATE_AUTH_REQUIRED", CommonTaskState.TaskStateAuthRequired },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        CommonTaskState,
        string
    > _enumToString = new()
    {
        { CommonTaskState.TaskStateSubmitted, "TASK_STATE_SUBMITTED" },
        { CommonTaskState.TaskStateWorking, "TASK_STATE_WORKING" },
        { CommonTaskState.TaskStateCompleted, "TASK_STATE_COMPLETED" },
        { CommonTaskState.TaskStateFailed, "TASK_STATE_FAILED" },
        { CommonTaskState.TaskStateCanceled, "TASK_STATE_CANCELED" },
        { CommonTaskState.TaskStateInputRequired, "TASK_STATE_INPUT_REQUIRED" },
        { CommonTaskState.TaskStateRejected, "TASK_STATE_REJECTED" },
        { CommonTaskState.TaskStateAuthRequired, "TASK_STATE_AUTH_REQUIRED" },
    };

    public override CommonTaskState Read(
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
        CommonTaskState value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override CommonTaskState ReadAsPropertyName(
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
        CommonTaskState value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
