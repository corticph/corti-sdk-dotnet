using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(StreamFormattingTimesSerializer))]
public enum StreamFormattingTimes
{
    [EnumMember(Value = "locale")]
    Locale,

    [EnumMember(Value = "h24")]
    H24,

    [EnumMember(Value = "h12")]
    H12,

    [EnumMember(Value = "as_dictated")]
    AsDictated,
}

internal class StreamFormattingTimesSerializer
    : global::System.Text.Json.Serialization.JsonConverter<StreamFormattingTimes>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        StreamFormattingTimes
    > _stringToEnum = new()
    {
        { "locale", StreamFormattingTimes.Locale },
        { "h24", StreamFormattingTimes.H24 },
        { "h12", StreamFormattingTimes.H12 },
        { "as_dictated", StreamFormattingTimes.AsDictated },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        StreamFormattingTimes,
        string
    > _enumToString = new()
    {
        { StreamFormattingTimes.Locale, "locale" },
        { StreamFormattingTimes.H24, "h24" },
        { StreamFormattingTimes.H12, "h12" },
        { StreamFormattingTimes.AsDictated, "as_dictated" },
    };

    public override StreamFormattingTimes Read(
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
        StreamFormattingTimes value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override StreamFormattingTimes ReadAsPropertyName(
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
        StreamFormattingTimes value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
