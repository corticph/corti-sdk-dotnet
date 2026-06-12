using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(StreamConfigStatusMessageTypeSerializer))]
public enum StreamConfigStatusMessageType
{
    [EnumMember(Value = "CONFIG_ACCEPTED")]
    ConfigAccepted,

    [EnumMember(Value = "CONFIG_DENIED")]
    ConfigDenied,

    [EnumMember(Value = "CONFIG_MISSING")]
    ConfigMissing,

    [EnumMember(Value = "CONFIG_NOT_PROVIDED")]
    ConfigNotProvided,

    [EnumMember(Value = "CONFIG_ALREADY_RECEIVED")]
    ConfigAlreadyReceived,
}

internal class StreamConfigStatusMessageTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<StreamConfigStatusMessageType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        StreamConfigStatusMessageType
    > _stringToEnum = new()
    {
        { "CONFIG_ACCEPTED", StreamConfigStatusMessageType.ConfigAccepted },
        { "CONFIG_DENIED", StreamConfigStatusMessageType.ConfigDenied },
        { "CONFIG_MISSING", StreamConfigStatusMessageType.ConfigMissing },
        { "CONFIG_NOT_PROVIDED", StreamConfigStatusMessageType.ConfigNotProvided },
        { "CONFIG_ALREADY_RECEIVED", StreamConfigStatusMessageType.ConfigAlreadyReceived },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        StreamConfigStatusMessageType,
        string
    > _enumToString = new()
    {
        { StreamConfigStatusMessageType.ConfigAccepted, "CONFIG_ACCEPTED" },
        { StreamConfigStatusMessageType.ConfigDenied, "CONFIG_DENIED" },
        { StreamConfigStatusMessageType.ConfigMissing, "CONFIG_MISSING" },
        { StreamConfigStatusMessageType.ConfigNotProvided, "CONFIG_NOT_PROVIDED" },
        { StreamConfigStatusMessageType.ConfigAlreadyReceived, "CONFIG_ALREADY_RECEIVED" },
    };

    public override StreamConfigStatusMessageType Read(
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
        StreamConfigStatusMessageType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override StreamConfigStatusMessageType ReadAsPropertyName(
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
        StreamConfigStatusMessageType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
