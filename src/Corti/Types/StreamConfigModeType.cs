using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(StreamConfigModeTypeSerializer))]
public enum StreamConfigModeType
{
    [EnumMember(Value = "facts")]
    Facts,

    [EnumMember(Value = "transcription")]
    Transcription,
}

internal class StreamConfigModeTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<StreamConfigModeType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        StreamConfigModeType
    > _stringToEnum = new()
    {
        { "facts", StreamConfigModeType.Facts },
        { "transcription", StreamConfigModeType.Transcription },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        StreamConfigModeType,
        string
    > _enumToString = new()
    {
        { StreamConfigModeType.Facts, "facts" },
        { StreamConfigModeType.Transcription, "transcription" },
    };

    public override StreamConfigModeType Read(
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
        StreamConfigModeType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override StreamConfigModeType ReadAsPropertyName(
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
        StreamConfigModeType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
