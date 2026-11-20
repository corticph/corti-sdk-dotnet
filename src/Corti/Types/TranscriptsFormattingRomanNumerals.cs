using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(TranscriptsFormattingRomanNumeralsSerializer))]
public enum TranscriptsFormattingRomanNumerals
{
    [EnumMember(Value = "upper")]
    Upper,

    [EnumMember(Value = "lower")]
    Lower,

    [EnumMember(Value = "as_dictated")]
    AsDictated,
}

internal class TranscriptsFormattingRomanNumeralsSerializer
    : global::System.Text.Json.Serialization.JsonConverter<TranscriptsFormattingRomanNumerals>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        TranscriptsFormattingRomanNumerals
    > _stringToEnum = new()
    {
        { "upper", TranscriptsFormattingRomanNumerals.Upper },
        { "lower", TranscriptsFormattingRomanNumerals.Lower },
        { "as_dictated", TranscriptsFormattingRomanNumerals.AsDictated },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        TranscriptsFormattingRomanNumerals,
        string
    > _enumToString = new()
    {
        { TranscriptsFormattingRomanNumerals.Upper, "upper" },
        { TranscriptsFormattingRomanNumerals.Lower, "lower" },
        { TranscriptsFormattingRomanNumerals.AsDictated, "as_dictated" },
    };

    public override TranscriptsFormattingRomanNumerals Read(
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
        TranscriptsFormattingRomanNumerals value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override TranscriptsFormattingRomanNumerals ReadAsPropertyName(
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
        TranscriptsFormattingRomanNumerals value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
