using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(TranscribeFormattingTimesSerializer))]
public enum TranscribeFormattingTimes
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

internal class TranscribeFormattingTimesSerializer
    : global::System.Text.Json.Serialization.JsonConverter<TranscribeFormattingTimes>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        TranscribeFormattingTimes
    > _stringToEnum = new()
    {
        { "locale", TranscribeFormattingTimes.Locale },
        { "h24", TranscribeFormattingTimes.H24 },
        { "h12", TranscribeFormattingTimes.H12 },
        { "as_dictated", TranscribeFormattingTimes.AsDictated },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        TranscribeFormattingTimes,
        string
    > _enumToString = new()
    {
        { TranscribeFormattingTimes.Locale, "locale" },
        { TranscribeFormattingTimes.H24, "h24" },
        { TranscribeFormattingTimes.H12, "h12" },
        { TranscribeFormattingTimes.AsDictated, "as_dictated" },
    };

    public override TranscribeFormattingTimes Read(
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
        TranscribeFormattingTimes value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override TranscribeFormattingTimes ReadAsPropertyName(
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
        TranscribeFormattingTimes value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
