using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(UsageGranularitySerializer))]
public enum UsageGranularity
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

internal class UsageGranularitySerializer
    : global::System.Text.Json.Serialization.JsonConverter<UsageGranularity>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        UsageGranularity
    > _stringToEnum = new()
    {
        { "minute", UsageGranularity.Minute },
        { "hour", UsageGranularity.Hour },
        { "day", UsageGranularity.Day },
        { "week", UsageGranularity.Week },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        UsageGranularity,
        string
    > _enumToString = new()
    {
        { UsageGranularity.Minute, "minute" },
        { UsageGranularity.Hour, "hour" },
        { UsageGranularity.Day, "day" },
        { UsageGranularity.Week, "week" },
    };

    public override UsageGranularity Read(
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
        UsageGranularity value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override UsageGranularity ReadAsPropertyName(
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
        UsageGranularity value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
