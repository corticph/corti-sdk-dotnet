using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(DocumentsContextWithTranscriptTypeSerializer))]
public enum DocumentsContextWithTranscriptType
{
    [EnumMember(Value = "transcript")]
    Transcript,
}

internal class DocumentsContextWithTranscriptTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<DocumentsContextWithTranscriptType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        DocumentsContextWithTranscriptType
    > _stringToEnum = new() { { "transcript", DocumentsContextWithTranscriptType.Transcript } };

    private static readonly global::System.Collections.Generic.Dictionary<
        DocumentsContextWithTranscriptType,
        string
    > _enumToString = new() { { DocumentsContextWithTranscriptType.Transcript, "transcript" } };

    public override DocumentsContextWithTranscriptType Read(
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
        DocumentsContextWithTranscriptType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override DocumentsContextWithTranscriptType ReadAsPropertyName(
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
        DocumentsContextWithTranscriptType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
