using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(StreamFormattingOrdinalsSerializer))]
public enum StreamFormattingOrdinals
{
    [EnumMember(Value = "numerals_above_nine")]
    NumeralsAboveNine,

    [EnumMember(Value = "as_dictated")]
    AsDictated,

    [EnumMember(Value = "numerals")]
    Numerals,
}

internal class StreamFormattingOrdinalsSerializer
    : global::System.Text.Json.Serialization.JsonConverter<StreamFormattingOrdinals>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        StreamFormattingOrdinals
    > _stringToEnum = new()
    {
        { "numerals_above_nine", StreamFormattingOrdinals.NumeralsAboveNine },
        { "as_dictated", StreamFormattingOrdinals.AsDictated },
        { "numerals", StreamFormattingOrdinals.Numerals },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        StreamFormattingOrdinals,
        string
    > _enumToString = new()
    {
        { StreamFormattingOrdinals.NumeralsAboveNine, "numerals_above_nine" },
        { StreamFormattingOrdinals.AsDictated, "as_dictated" },
        { StreamFormattingOrdinals.Numerals, "numerals" },
    };

    public override StreamFormattingOrdinals Read(
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
        StreamFormattingOrdinals value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override StreamFormattingOrdinals ReadAsPropertyName(
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
        StreamFormattingOrdinals value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
