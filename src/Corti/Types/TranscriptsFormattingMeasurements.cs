using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(TranscriptsFormattingMeasurementsSerializer))]
public enum TranscriptsFormattingMeasurements
{
    [EnumMember(Value = "abbreviated")]
    Abbreviated,

    [EnumMember(Value = "as_dictated")]
    AsDictated,
}

internal class TranscriptsFormattingMeasurementsSerializer
    : global::System.Text.Json.Serialization.JsonConverter<TranscriptsFormattingMeasurements>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        TranscriptsFormattingMeasurements
    > _stringToEnum = new()
    {
        { "abbreviated", TranscriptsFormattingMeasurements.Abbreviated },
        { "as_dictated", TranscriptsFormattingMeasurements.AsDictated },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        TranscriptsFormattingMeasurements,
        string
    > _enumToString = new()
    {
        { TranscriptsFormattingMeasurements.Abbreviated, "abbreviated" },
        { TranscriptsFormattingMeasurements.AsDictated, "as_dictated" },
    };

    public override TranscriptsFormattingMeasurements Read(
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
        TranscriptsFormattingMeasurements value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override TranscriptsFormattingMeasurements ReadAsPropertyName(
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
        TranscriptsFormattingMeasurements value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
