using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(TranscriptsFormattingTimesSerializer))]
public enum TranscriptsFormattingTimes
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

internal class TranscriptsFormattingTimesSerializer
    : global::System.Text.Json.Serialization.JsonConverter<TranscriptsFormattingTimes>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        TranscriptsFormattingTimes
    > _stringToEnum = new()
    {
        { "locale", TranscriptsFormattingTimes.Locale },
        { "h24", TranscriptsFormattingTimes.H24 },
        { "h12", TranscriptsFormattingTimes.H12 },
        { "as_dictated", TranscriptsFormattingTimes.AsDictated },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        TranscriptsFormattingTimes,
        string
    > _enumToString = new()
    {
        { TranscriptsFormattingTimes.Locale, "locale" },
        { TranscriptsFormattingTimes.H24, "h24" },
        { TranscriptsFormattingTimes.H12, "h12" },
        { TranscriptsFormattingTimes.AsDictated, "as_dictated" },
    };

    public override TranscriptsFormattingTimes Read(
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
        TranscriptsFormattingTimes value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override TranscriptsFormattingTimes ReadAsPropertyName(
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
        TranscriptsFormattingTimes value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
