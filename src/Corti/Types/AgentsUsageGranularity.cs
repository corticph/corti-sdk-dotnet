using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(AgentsUsageGranularitySerializer))]
public enum AgentsUsageGranularity
{
    [EnumMember(Value = "minute")]
    Minute,

    [EnumMember(Value = "hour")]
    Hour,

    [EnumMember(Value = "day")]
    Day,

    [EnumMember(Value = "week")]
    Week,
}

internal class AgentsUsageGranularitySerializer
    : global::System.Text.Json.Serialization.JsonConverter<AgentsUsageGranularity>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AgentsUsageGranularity
    > _stringToEnum = new()
    {
        { "minute", AgentsUsageGranularity.Minute },
        { "hour", AgentsUsageGranularity.Hour },
        { "day", AgentsUsageGranularity.Day },
        { "week", AgentsUsageGranularity.Week },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AgentsUsageGranularity,
        string
    > _enumToString = new()
    {
        { AgentsUsageGranularity.Minute, "minute" },
        { AgentsUsageGranularity.Hour, "hour" },
        { AgentsUsageGranularity.Day, "day" },
        { AgentsUsageGranularity.Week, "week" },
    };

    public override AgentsUsageGranularity Read(
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
        AgentsUsageGranularity value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AgentsUsageGranularity ReadAsPropertyName(
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
        AgentsUsageGranularity value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
