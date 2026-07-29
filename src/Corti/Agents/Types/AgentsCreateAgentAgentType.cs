using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(AgentsCreateAgentAgentTypeSerializer))]
public enum AgentsCreateAgentAgentType
{
    [EnumMember(Value = "expert")]
    Expert,

    [EnumMember(Value = "orchestrator")]
    Orchestrator,

    [EnumMember(Value = "interviewing-expert")]
    InterviewingExpert,
}

internal class AgentsCreateAgentAgentTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AgentsCreateAgentAgentType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AgentsCreateAgentAgentType
    > _stringToEnum = new()
    {
        { "expert", AgentsCreateAgentAgentType.Expert },
        { "orchestrator", AgentsCreateAgentAgentType.Orchestrator },
        { "interviewing-expert", AgentsCreateAgentAgentType.InterviewingExpert },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AgentsCreateAgentAgentType,
        string
    > _enumToString = new()
    {
        { AgentsCreateAgentAgentType.Expert, "expert" },
        { AgentsCreateAgentAgentType.Orchestrator, "orchestrator" },
        { AgentsCreateAgentAgentType.InterviewingExpert, "interviewing-expert" },
    };

    public override AgentsCreateAgentAgentType Read(
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
        AgentsCreateAgentAgentType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AgentsCreateAgentAgentType ReadAsPropertyName(
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
        AgentsCreateAgentAgentType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
