using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(StreamAudioEventDataEventSerializer))]
public enum StreamAudioEventDataEvent
{
    [EnumMember(Value = "speechQualityIssueDetected")]
    SpeechQualityIssueDetected,

    [EnumMember(Value = "speechQualityIssueRecovered")]
    SpeechQualityIssueRecovered,

    [EnumMember(Value = "longSilenceDetected")]
    LongSilenceDetected,

    [EnumMember(Value = "longSilenceRecovered")]
    LongSilenceRecovered,
}

internal class StreamAudioEventDataEventSerializer
    : global::System.Text.Json.Serialization.JsonConverter<StreamAudioEventDataEvent>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        StreamAudioEventDataEvent
    > _stringToEnum = new()
    {
        { "speechQualityIssueDetected", StreamAudioEventDataEvent.SpeechQualityIssueDetected },
        { "speechQualityIssueRecovered", StreamAudioEventDataEvent.SpeechQualityIssueRecovered },
        { "longSilenceDetected", StreamAudioEventDataEvent.LongSilenceDetected },
        { "longSilenceRecovered", StreamAudioEventDataEvent.LongSilenceRecovered },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        StreamAudioEventDataEvent,
        string
    > _enumToString = new()
    {
        { StreamAudioEventDataEvent.SpeechQualityIssueDetected, "speechQualityIssueDetected" },
        { StreamAudioEventDataEvent.SpeechQualityIssueRecovered, "speechQualityIssueRecovered" },
        { StreamAudioEventDataEvent.LongSilenceDetected, "longSilenceDetected" },
        { StreamAudioEventDataEvent.LongSilenceRecovered, "longSilenceRecovered" },
    };

    public override StreamAudioEventDataEvent Read(
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
        StreamAudioEventDataEvent value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override StreamAudioEventDataEvent ReadAsPropertyName(
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
        StreamAudioEventDataEvent value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
