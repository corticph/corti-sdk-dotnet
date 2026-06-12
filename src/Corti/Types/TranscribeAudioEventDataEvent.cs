using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(TranscribeAudioEventDataEventSerializer))]
public enum TranscribeAudioEventDataEvent
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

internal class TranscribeAudioEventDataEventSerializer
    : global::System.Text.Json.Serialization.JsonConverter<TranscribeAudioEventDataEvent>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        TranscribeAudioEventDataEvent
    > _stringToEnum = new()
    {
        { "speechQualityIssueDetected", TranscribeAudioEventDataEvent.SpeechQualityIssueDetected },
        {
            "speechQualityIssueRecovered",
            TranscribeAudioEventDataEvent.SpeechQualityIssueRecovered
        },
        { "longSilenceDetected", TranscribeAudioEventDataEvent.LongSilenceDetected },
        { "longSilenceRecovered", TranscribeAudioEventDataEvent.LongSilenceRecovered },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        TranscribeAudioEventDataEvent,
        string
    > _enumToString = new()
    {
        { TranscribeAudioEventDataEvent.SpeechQualityIssueDetected, "speechQualityIssueDetected" },
        {
            TranscribeAudioEventDataEvent.SpeechQualityIssueRecovered,
            "speechQualityIssueRecovered"
        },
        { TranscribeAudioEventDataEvent.LongSilenceDetected, "longSilenceDetected" },
        { TranscribeAudioEventDataEvent.LongSilenceRecovered, "longSilenceRecovered" },
    };

    public override TranscribeAudioEventDataEvent Read(
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
        TranscribeAudioEventDataEvent value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override TranscribeAudioEventDataEvent ReadAsPropertyName(
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
        TranscribeAudioEventDataEvent value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
