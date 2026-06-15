using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(TranscribeFormattingDatesSerializer))]
public enum TranscribeFormattingDates
{
    [EnumMember(Value = "locale:long")]
    LocaleLong,

    [EnumMember(Value = "locale:medium")]
    LocaleMedium,

    [EnumMember(Value = "locale:short")]
    LocaleShort,

    [EnumMember(Value = "as_dictated")]
    AsDictated,

    [EnumMember(Value = "iso")]
    Iso,
}

internal class TranscribeFormattingDatesSerializer
    : global::System.Text.Json.Serialization.JsonConverter<TranscribeFormattingDates>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        TranscribeFormattingDates
    > _stringToEnum = new()
    {
        { "locale:long", TranscribeFormattingDates.LocaleLong },
        { "locale:medium", TranscribeFormattingDates.LocaleMedium },
        { "locale:short", TranscribeFormattingDates.LocaleShort },
        { "as_dictated", TranscribeFormattingDates.AsDictated },
        { "iso", TranscribeFormattingDates.Iso },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        TranscribeFormattingDates,
        string
    > _enumToString = new()
    {
        { TranscribeFormattingDates.LocaleLong, "locale:long" },
        { TranscribeFormattingDates.LocaleMedium, "locale:medium" },
        { TranscribeFormattingDates.LocaleShort, "locale:short" },
        { TranscribeFormattingDates.AsDictated, "as_dictated" },
        { TranscribeFormattingDates.Iso, "iso" },
    };

    public override TranscribeFormattingDates Read(
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
        TranscribeFormattingDates value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override TranscribeFormattingDates ReadAsPropertyName(
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
        TranscribeFormattingDates value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
