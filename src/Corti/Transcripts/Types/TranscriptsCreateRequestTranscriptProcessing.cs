using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(TranscriptsCreateRequestTranscriptProcessingSerializer))]
public enum TranscriptsCreateRequestTranscriptProcessing
{
    [EnumMember(Value = "standard")]
    Standard,

    [EnumMember(Value = "raw")]
    Raw,
}

internal class TranscriptsCreateRequestTranscriptProcessingSerializer
    : global::System.Text.Json.Serialization.JsonConverter<TranscriptsCreateRequestTranscriptProcessing>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        TranscriptsCreateRequestTranscriptProcessing
    > _stringToEnum = new()
    {
        { "standard", TranscriptsCreateRequestTranscriptProcessing.Standard },
        { "raw", TranscriptsCreateRequestTranscriptProcessing.Raw },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        TranscriptsCreateRequestTranscriptProcessing,
        string
    > _enumToString = new()
    {
        { TranscriptsCreateRequestTranscriptProcessing.Standard, "standard" },
        { TranscriptsCreateRequestTranscriptProcessing.Raw, "raw" },
    };

    public override TranscriptsCreateRequestTranscriptProcessing Read(
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
        TranscriptsCreateRequestTranscriptProcessing value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override TranscriptsCreateRequestTranscriptProcessing ReadAsPropertyName(
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
        TranscriptsCreateRequestTranscriptProcessing value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
