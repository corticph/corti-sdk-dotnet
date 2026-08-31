using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(TranscribeConfigTranscriptProcessingSerializer))]
public enum TranscribeConfigTranscriptProcessing
{
    [EnumMember(Value = "standard")]
    Standard,

    [EnumMember(Value = "raw")]
    Raw,
}

internal class TranscribeConfigTranscriptProcessingSerializer
    : global::System.Text.Json.Serialization.JsonConverter<TranscribeConfigTranscriptProcessing>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        TranscribeConfigTranscriptProcessing
    > _stringToEnum = new()
    {
        { "standard", TranscribeConfigTranscriptProcessing.Standard },
        { "raw", TranscribeConfigTranscriptProcessing.Raw },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        TranscribeConfigTranscriptProcessing,
        string
    > _enumToString = new()
    {
        { TranscribeConfigTranscriptProcessing.Standard, "standard" },
        { TranscribeConfigTranscriptProcessing.Raw, "raw" },
    };

    public override TranscribeConfigTranscriptProcessing Read(
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
        TranscribeConfigTranscriptProcessing value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override TranscribeConfigTranscriptProcessing ReadAsPropertyName(
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
        TranscribeConfigTranscriptProcessing value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
