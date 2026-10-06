using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(TranscriptsFormattingOrdinalsSerializer))]
public enum TranscriptsFormattingOrdinals
{
    [EnumMember(Value = "numerals_above_nine")]
    NumeralsAboveNine,

    [EnumMember(Value = "as_dictated")]
    AsDictated,

    [EnumMember(Value = "numerals")]
    Numerals,
}

internal class TranscriptsFormattingOrdinalsSerializer
    : global::System.Text.Json.Serialization.JsonConverter<TranscriptsFormattingOrdinals>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        TranscriptsFormattingOrdinals
    > _stringToEnum = new()
    {
        { "numerals_above_nine", TranscriptsFormattingOrdinals.NumeralsAboveNine },
        { "as_dictated", TranscriptsFormattingOrdinals.AsDictated },
        { "numerals", TranscriptsFormattingOrdinals.Numerals },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        TranscriptsFormattingOrdinals,
        string
    > _enumToString = new()
    {
        { TranscriptsFormattingOrdinals.NumeralsAboveNine, "numerals_above_nine" },
        { TranscriptsFormattingOrdinals.AsDictated, "as_dictated" },
        { TranscriptsFormattingOrdinals.Numerals, "numerals" },
    };

    public override TranscriptsFormattingOrdinals Read(
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
        TranscriptsFormattingOrdinals value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override TranscriptsFormattingOrdinals ReadAsPropertyName(
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
        TranscriptsFormattingOrdinals value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
