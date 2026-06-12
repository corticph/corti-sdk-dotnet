using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(TranscribeFormattingNumericRangesSerializer))]
public enum TranscribeFormattingNumericRanges
{
    [EnumMember(Value = "numerals")]
    Numerals,

    [EnumMember(Value = "as_dictated")]
    AsDictated,
}

internal class TranscribeFormattingNumericRangesSerializer
    : global::System.Text.Json.Serialization.JsonConverter<TranscribeFormattingNumericRanges>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        TranscribeFormattingNumericRanges
    > _stringToEnum = new()
    {
        { "numerals", TranscribeFormattingNumericRanges.Numerals },
        { "as_dictated", TranscribeFormattingNumericRanges.AsDictated },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        TranscribeFormattingNumericRanges,
        string
    > _enumToString = new()
    {
        { TranscribeFormattingNumericRanges.Numerals, "numerals" },
        { TranscribeFormattingNumericRanges.AsDictated, "as_dictated" },
    };

    public override TranscribeFormattingNumericRanges Read(
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
        TranscribeFormattingNumericRanges value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override TranscribeFormattingNumericRanges ReadAsPropertyName(
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
        TranscribeFormattingNumericRanges value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
