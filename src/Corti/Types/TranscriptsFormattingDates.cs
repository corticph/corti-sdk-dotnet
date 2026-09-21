using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(TranscriptsFormattingDatesSerializer))]
public enum TranscriptsFormattingDates
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

internal class TranscriptsFormattingDatesSerializer
    : global::System.Text.Json.Serialization.JsonConverter<TranscriptsFormattingDates>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        TranscriptsFormattingDates
    > _stringToEnum = new()
    {
        { "locale:long", TranscriptsFormattingDates.LocaleLong },
        { "locale:medium", TranscriptsFormattingDates.LocaleMedium },
        { "locale:short", TranscriptsFormattingDates.LocaleShort },
        { "as_dictated", TranscriptsFormattingDates.AsDictated },
        { "iso", TranscriptsFormattingDates.Iso },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        TranscriptsFormattingDates,
        string
    > _enumToString = new()
    {
        { TranscriptsFormattingDates.LocaleLong, "locale:long" },
        { TranscriptsFormattingDates.LocaleMedium, "locale:medium" },
        { TranscriptsFormattingDates.LocaleShort, "locale:short" },
        { TranscriptsFormattingDates.AsDictated, "as_dictated" },
        { TranscriptsFormattingDates.Iso, "iso" },
    };

    public override TranscriptsFormattingDates Read(
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
        TranscriptsFormattingDates value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override TranscriptsFormattingDates ReadAsPropertyName(
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
        TranscriptsFormattingDates value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
