using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(StreamConfigTranscriptionTranscriptProcessingSerializer))]
public enum StreamConfigTranscriptionTranscriptProcessing
{
    [EnumMember(Value = "standard")]
    Standard,

    [EnumMember(Value = "raw")]
    Raw,
}

internal class StreamConfigTranscriptionTranscriptProcessingSerializer
    : global::System.Text.Json.Serialization.JsonConverter<StreamConfigTranscriptionTranscriptProcessing>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        StreamConfigTranscriptionTranscriptProcessing
    > _stringToEnum = new()
    {
        { "standard", StreamConfigTranscriptionTranscriptProcessing.Standard },
        { "raw", StreamConfigTranscriptionTranscriptProcessing.Raw },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        StreamConfigTranscriptionTranscriptProcessing,
        string
    > _enumToString = new()
    {
        { StreamConfigTranscriptionTranscriptProcessing.Standard, "standard" },
        { StreamConfigTranscriptionTranscriptProcessing.Raw, "raw" },
    };

    public override StreamConfigTranscriptionTranscriptProcessing Read(
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
        StreamConfigTranscriptionTranscriptProcessing value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override StreamConfigTranscriptionTranscriptProcessing ReadAsPropertyName(
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
        StreamConfigTranscriptionTranscriptProcessing value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
