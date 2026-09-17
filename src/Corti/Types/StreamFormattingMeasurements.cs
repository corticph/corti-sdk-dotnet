using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(StreamFormattingMeasurementsSerializer))]
public enum StreamFormattingMeasurements
{
    [EnumMember(Value = "abbreviated")]
    Abbreviated,

    [EnumMember(Value = "as_dictated")]
    AsDictated,
}

internal class StreamFormattingMeasurementsSerializer
    : global::System.Text.Json.Serialization.JsonConverter<StreamFormattingMeasurements>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        StreamFormattingMeasurements
    > _stringToEnum = new()
    {
        { "abbreviated", StreamFormattingMeasurements.Abbreviated },
        { "as_dictated", StreamFormattingMeasurements.AsDictated },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        StreamFormattingMeasurements,
        string
    > _enumToString = new()
    {
        { StreamFormattingMeasurements.Abbreviated, "abbreviated" },
        { StreamFormattingMeasurements.AsDictated, "as_dictated" },
    };

    public override StreamFormattingMeasurements Read(
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
        StreamFormattingMeasurements value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override StreamFormattingMeasurements ReadAsPropertyName(
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
        StreamFormattingMeasurements value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
