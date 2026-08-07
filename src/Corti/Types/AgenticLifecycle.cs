using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(AgenticLifecycleSerializer))]
public enum AgenticLifecycle
{
    [EnumMember(Value = "ephemeral")]
    Ephemeral,

    [EnumMember(Value = "persistent")]
    Persistent,
}

internal class AgenticLifecycleSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AgenticLifecycle>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AgenticLifecycle
    > _stringToEnum = new()
    {
        { "ephemeral", AgenticLifecycle.Ephemeral },
        { "persistent", AgenticLifecycle.Persistent },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AgenticLifecycle,
        string
    > _enumToString = new()
    {
        { AgenticLifecycle.Ephemeral, "ephemeral" },
        { AgenticLifecycle.Persistent, "persistent" },
    };

    public override AgenticLifecycle Read(
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
        AgenticLifecycle value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AgenticLifecycle ReadAsPropertyName(
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
        AgenticLifecycle value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
