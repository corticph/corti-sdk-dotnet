using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(TranscriptsStatusEnumSerializer))]
public enum TranscriptsStatusEnum
{
    [EnumMember(Value = "completed")]
    Completed,

    [EnumMember(Value = "processing")]
    Processing,

    [EnumMember(Value = "failed")]
    Failed,
}

internal class TranscriptsStatusEnumSerializer
    : global::System.Text.Json.Serialization.JsonConverter<TranscriptsStatusEnum>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        TranscriptsStatusEnum
    > _stringToEnum = new()
    {
        { "completed", TranscriptsStatusEnum.Completed },
        { "processing", TranscriptsStatusEnum.Processing },
        { "failed", TranscriptsStatusEnum.Failed },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        TranscriptsStatusEnum,
        string
    > _enumToString = new()
    {
        { TranscriptsStatusEnum.Completed, "completed" },
        { TranscriptsStatusEnum.Processing, "processing" },
        { TranscriptsStatusEnum.Failed, "failed" },
    };

    public override TranscriptsStatusEnum Read(
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
        TranscriptsStatusEnum value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override TranscriptsStatusEnum ReadAsPropertyName(
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
        TranscriptsStatusEnum value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
