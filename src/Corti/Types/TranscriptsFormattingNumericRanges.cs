using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(TranscriptsFormattingNumericRangesSerializer))]
public enum TranscriptsFormattingNumericRanges
{
    [EnumMember(Value = "numerals")]
    Numerals,

    [EnumMember(Value = "as_dictated")]
    AsDictated,
}

internal class TranscriptsFormattingNumericRangesSerializer
    : global::System.Text.Json.Serialization.JsonConverter<TranscriptsFormattingNumericRanges>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        TranscriptsFormattingNumericRanges
    > _stringToEnum = new()
    {
        { "numerals", TranscriptsFormattingNumericRanges.Numerals },
        { "as_dictated", TranscriptsFormattingNumericRanges.AsDictated },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        TranscriptsFormattingNumericRanges,
        string
    > _enumToString = new()
    {
        { TranscriptsFormattingNumericRanges.Numerals, "numerals" },
        { TranscriptsFormattingNumericRanges.AsDictated, "as_dictated" },
    };

    public override TranscriptsFormattingNumericRanges Read(
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
        TranscriptsFormattingNumericRanges value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override TranscriptsFormattingNumericRanges ReadAsPropertyName(
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
        TranscriptsFormattingNumericRanges value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
