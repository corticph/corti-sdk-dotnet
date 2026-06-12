using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(AgentsTaskStatusStateSerializer))]
public enum AgentsTaskStatusState
{
    [EnumMember(Value = "submitted")]
    Submitted,

    [EnumMember(Value = "working")]
    Working,

    [EnumMember(Value = "input-required")]
    InputRequired,

    [EnumMember(Value = "completed")]
    Completed,

    [EnumMember(Value = "canceled")]
    Canceled,

    [EnumMember(Value = "failed")]
    Failed,

    [EnumMember(Value = "rejected")]
    Rejected,

    [EnumMember(Value = "auth-required")]
    AuthRequired,

    [EnumMember(Value = "unknown")]
    Unknown,
}

internal class AgentsTaskStatusStateSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AgentsTaskStatusState>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AgentsTaskStatusState
    > _stringToEnum = new()
    {
        { "submitted", AgentsTaskStatusState.Submitted },
        { "working", AgentsTaskStatusState.Working },
        { "input-required", AgentsTaskStatusState.InputRequired },
        { "completed", AgentsTaskStatusState.Completed },
        { "canceled", AgentsTaskStatusState.Canceled },
        { "failed", AgentsTaskStatusState.Failed },
        { "rejected", AgentsTaskStatusState.Rejected },
        { "auth-required", AgentsTaskStatusState.AuthRequired },
        { "unknown", AgentsTaskStatusState.Unknown },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AgentsTaskStatusState,
        string
    > _enumToString = new()
    {
        { AgentsTaskStatusState.Submitted, "submitted" },
        { AgentsTaskStatusState.Working, "working" },
        { AgentsTaskStatusState.InputRequired, "input-required" },
        { AgentsTaskStatusState.Completed, "completed" },
        { AgentsTaskStatusState.Canceled, "canceled" },
        { AgentsTaskStatusState.Failed, "failed" },
        { AgentsTaskStatusState.Rejected, "rejected" },
        { AgentsTaskStatusState.AuthRequired, "auth-required" },
        { AgentsTaskStatusState.Unknown, "unknown" },
    };

    public override AgentsTaskStatusState Read(
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
        AgentsTaskStatusState value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AgentsTaskStatusState ReadAsPropertyName(
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
        AgentsTaskStatusState value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
