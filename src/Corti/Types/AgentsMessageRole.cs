using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(AgentsMessageRoleSerializer))]
public enum AgentsMessageRole
{
    [EnumMember(Value = "user")]
    User,

    [EnumMember(Value = "agent")]
    Agent,
}

internal class AgentsMessageRoleSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AgentsMessageRole>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AgentsMessageRole
    > _stringToEnum = new()
    {
        { "user", AgentsMessageRole.User },
        { "agent", AgentsMessageRole.Agent },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AgentsMessageRole,
        string
    > _enumToString = new()
    {
        { AgentsMessageRole.User, "user" },
        { AgentsMessageRole.Agent, "agent" },
    };

    public override AgentsMessageRole Read(
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
        AgentsMessageRole value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AgentsMessageRole ReadAsPropertyName(
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
        AgentsMessageRole value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
