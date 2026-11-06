using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(TranscriptsListRequestSortSerializer))]
public enum TranscriptsListRequestSort
{
    [EnumMember(Value = "id")]
    Id,

    [EnumMember(Value = "recordingId")]
    RecordingId,

    [EnumMember(Value = "primaryLanguage")]
    PrimaryLanguage,

    [EnumMember(Value = "isMultichannel")]
    IsMultichannel,

    [EnumMember(Value = "status")]
    Status,

    [EnumMember(Value = "createdAt")]
    CreatedAt,
}

internal class TranscriptsListRequestSortSerializer
    : global::System.Text.Json.Serialization.JsonConverter<TranscriptsListRequestSort>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        TranscriptsListRequestSort
    > _stringToEnum = new()
    {
        { "id", TranscriptsListRequestSort.Id },
        { "recordingId", TranscriptsListRequestSort.RecordingId },
        { "primaryLanguage", TranscriptsListRequestSort.PrimaryLanguage },
        { "isMultichannel", TranscriptsListRequestSort.IsMultichannel },
        { "status", TranscriptsListRequestSort.Status },
        { "createdAt", TranscriptsListRequestSort.CreatedAt },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        TranscriptsListRequestSort,
        string
    > _enumToString = new()
    {
        { TranscriptsListRequestSort.Id, "id" },
        { TranscriptsListRequestSort.RecordingId, "recordingId" },
        { TranscriptsListRequestSort.PrimaryLanguage, "primaryLanguage" },
        { TranscriptsListRequestSort.IsMultichannel, "isMultichannel" },
        { TranscriptsListRequestSort.Status, "status" },
        { TranscriptsListRequestSort.CreatedAt, "createdAt" },
    };

    public override TranscriptsListRequestSort Read(
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
        TranscriptsListRequestSort value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override TranscriptsListRequestSort ReadAsPropertyName(
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
        TranscriptsListRequestSort value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
