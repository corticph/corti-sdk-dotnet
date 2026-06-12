using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(TranscribeFormattingMeasurementsSerializer))]
public enum TranscribeFormattingMeasurements
{
    [EnumMember(Value = "abbreviated")]
    Abbreviated,

    [EnumMember(Value = "as_dictated")]
    AsDictated,
}

internal class TranscribeFormattingMeasurementsSerializer
    : global::System.Text.Json.Serialization.JsonConverter<TranscribeFormattingMeasurements>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        TranscribeFormattingMeasurements
    > _stringToEnum = new()
    {
        { "abbreviated", TranscribeFormattingMeasurements.Abbreviated },
        { "as_dictated", TranscribeFormattingMeasurements.AsDictated },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        TranscribeFormattingMeasurements,
        string
    > _enumToString = new()
    {
        { TranscribeFormattingMeasurements.Abbreviated, "abbreviated" },
        { TranscribeFormattingMeasurements.AsDictated, "as_dictated" },
    };

    public override TranscribeFormattingMeasurements Read(
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
        TranscribeFormattingMeasurements value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override TranscribeFormattingMeasurements ReadAsPropertyName(
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
        TranscribeFormattingMeasurements value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
