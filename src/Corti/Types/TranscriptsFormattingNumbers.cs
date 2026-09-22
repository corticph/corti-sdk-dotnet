using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(TranscriptsFormattingNumbersSerializer))]
public enum TranscriptsFormattingNumbers
{
    [EnumMember(Value = "numerals_above_nine")]
    NumeralsAboveNine,

    [EnumMember(Value = "numerals")]
    Numerals,

    [EnumMember(Value = "as_dictated")]
    AsDictated,
}

internal class TranscriptsFormattingNumbersSerializer
    : global::System.Text.Json.Serialization.JsonConverter<TranscriptsFormattingNumbers>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        TranscriptsFormattingNumbers
    > _stringToEnum = new()
    {
        { "numerals_above_nine", TranscriptsFormattingNumbers.NumeralsAboveNine },
        { "numerals", TranscriptsFormattingNumbers.Numerals },
        { "as_dictated", TranscriptsFormattingNumbers.AsDictated },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        TranscriptsFormattingNumbers,
        string
    > _enumToString = new()
    {
        { TranscriptsFormattingNumbers.NumeralsAboveNine, "numerals_above_nine" },
        { TranscriptsFormattingNumbers.Numerals, "numerals" },
        { TranscriptsFormattingNumbers.AsDictated, "as_dictated" },
    };

    public override TranscriptsFormattingNumbers Read(
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
        TranscriptsFormattingNumbers value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override TranscriptsFormattingNumbers ReadAsPropertyName(
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
        TranscriptsFormattingNumbers value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
