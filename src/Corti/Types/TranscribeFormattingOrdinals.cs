using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(TranscribeFormattingOrdinalsSerializer))]
public enum TranscribeFormattingOrdinals
{
    [EnumMember(Value = "numerals_above_nine")]
    NumeralsAboveNine,

    [EnumMember(Value = "as_dictated")]
    AsDictated,

    [EnumMember(Value = "numerals")]
    Numerals,
}

internal class TranscribeFormattingOrdinalsSerializer
    : global::System.Text.Json.Serialization.JsonConverter<TranscribeFormattingOrdinals>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        TranscribeFormattingOrdinals
    > _stringToEnum = new()
    {
        { "numerals_above_nine", TranscribeFormattingOrdinals.NumeralsAboveNine },
        { "as_dictated", TranscribeFormattingOrdinals.AsDictated },
        { "numerals", TranscribeFormattingOrdinals.Numerals },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        TranscribeFormattingOrdinals,
        string
    > _enumToString = new()
    {
        { TranscribeFormattingOrdinals.NumeralsAboveNine, "numerals_above_nine" },
        { TranscribeFormattingOrdinals.AsDictated, "as_dictated" },
        { TranscribeFormattingOrdinals.Numerals, "numerals" },
    };

    public override TranscribeFormattingOrdinals Read(
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
        TranscribeFormattingOrdinals value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override TranscribeFormattingOrdinals ReadAsPropertyName(
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
        TranscribeFormattingOrdinals value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
