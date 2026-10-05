using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(StreamFormattingDatesSerializer))]
public enum StreamFormattingDates
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

internal class StreamFormattingDatesSerializer
    : global::System.Text.Json.Serialization.JsonConverter<StreamFormattingDates>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        StreamFormattingDates
    > _stringToEnum = new()
    {
        { "locale:long", StreamFormattingDates.LocaleLong },
        { "locale:medium", StreamFormattingDates.LocaleMedium },
        { "locale:short", StreamFormattingDates.LocaleShort },
        { "as_dictated", StreamFormattingDates.AsDictated },
        { "iso", StreamFormattingDates.Iso },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        StreamFormattingDates,
        string
    > _enumToString = new()
    {
        { StreamFormattingDates.LocaleLong, "locale:long" },
        { StreamFormattingDates.LocaleMedium, "locale:medium" },
        { StreamFormattingDates.LocaleShort, "locale:short" },
        { StreamFormattingDates.AsDictated, "as_dictated" },
        { StreamFormattingDates.Iso, "iso" },
    };

    public override StreamFormattingDates Read(
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
        StreamFormattingDates value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override StreamFormattingDates ReadAsPropertyName(
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
        StreamFormattingDates value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
