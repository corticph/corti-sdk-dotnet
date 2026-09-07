using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(StreamFormattingNumericRangesSerializer))]
public enum StreamFormattingNumericRanges
{
    [EnumMember(Value = "numerals")]
    Numerals,

    [EnumMember(Value = "as_dictated")]
    AsDictated,
}

internal class StreamFormattingNumericRangesSerializer
    : global::System.Text.Json.Serialization.JsonConverter<StreamFormattingNumericRanges>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        StreamFormattingNumericRanges
    > _stringToEnum = new()
    {
        { "numerals", StreamFormattingNumericRanges.Numerals },
        { "as_dictated", StreamFormattingNumericRanges.AsDictated },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        StreamFormattingNumericRanges,
        string
    > _enumToString = new()
    {
        { StreamFormattingNumericRanges.Numerals, "numerals" },
        { StreamFormattingNumericRanges.AsDictated, "as_dictated" },
    };

    public override StreamFormattingNumericRanges Read(
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
        StreamFormattingNumericRanges value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override StreamFormattingNumericRanges ReadAsPropertyName(
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
        StreamFormattingNumericRanges value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
