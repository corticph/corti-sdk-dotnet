using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(TranscribeFormattingNumbersSerializer))]
public enum TranscribeFormattingNumbers
{
    [EnumMember(Value = "numerals_above_nine")]
    NumeralsAboveNine,

    [EnumMember(Value = "numerals")]
    Numerals,

    [EnumMember(Value = "as_dictated")]
    AsDictated,
}

internal class TranscribeFormattingNumbersSerializer
    : global::System.Text.Json.Serialization.JsonConverter<TranscribeFormattingNumbers>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        TranscribeFormattingNumbers
    > _stringToEnum = new()
    {
        { "numerals_above_nine", TranscribeFormattingNumbers.NumeralsAboveNine },
        { "numerals", TranscribeFormattingNumbers.Numerals },
        { "as_dictated", TranscribeFormattingNumbers.AsDictated },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        TranscribeFormattingNumbers,
        string
    > _enumToString = new()
    {
        { TranscribeFormattingNumbers.NumeralsAboveNine, "numerals_above_nine" },
        { TranscribeFormattingNumbers.Numerals, "numerals" },
        { TranscribeFormattingNumbers.AsDictated, "as_dictated" },
    };

    public override TranscribeFormattingNumbers Read(
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
        TranscribeFormattingNumbers value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override TranscribeFormattingNumbers ReadAsPropertyName(
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
        TranscribeFormattingNumbers value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
