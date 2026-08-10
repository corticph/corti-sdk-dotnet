using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(AgenticUsageGranularitySerializer))]
public enum AgenticUsageGranularity
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

internal class AgenticUsageGranularitySerializer
    : global::System.Text.Json.Serialization.JsonConverter<AgenticUsageGranularity>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AgenticUsageGranularity
    > _stringToEnum = new()
    {
        { "minute", AgenticUsageGranularity.Minute },
        { "hour", AgenticUsageGranularity.Hour },
        { "day", AgenticUsageGranularity.Day },
        { "week", AgenticUsageGranularity.Week },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AgenticUsageGranularity,
        string
    > _enumToString = new()
    {
        { AgenticUsageGranularity.Minute, "minute" },
        { AgenticUsageGranularity.Hour, "hour" },
        { AgenticUsageGranularity.Day, "day" },
        { AgenticUsageGranularity.Week, "week" },
    };

    public override AgenticUsageGranularity Read(
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
        AgenticUsageGranularity value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AgenticUsageGranularity ReadAsPropertyName(
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
        AgenticUsageGranularity value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
