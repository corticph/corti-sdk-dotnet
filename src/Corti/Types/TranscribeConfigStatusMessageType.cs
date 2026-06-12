using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(TranscribeConfigStatusMessageTypeSerializer))]
public enum TranscribeConfigStatusMessageType
{
    [EnumMember(Value = "CONFIG_ACCEPTED")]
    ConfigAccepted,

    [EnumMember(Value = "CONFIG_DENIED")]
    ConfigDenied,

    [EnumMember(Value = "CONFIG_TIMEOUT")]
    ConfigTimeout,

    [EnumMember(Value = "CONFIG_ALREADY_RECEIVED")]
    ConfigAlreadyReceived,

    [EnumMember(Value = "CONFIG_MISSING")]
    ConfigMissing,
}

internal class TranscribeConfigStatusMessageTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<TranscribeConfigStatusMessageType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        TranscribeConfigStatusMessageType
    > _stringToEnum = new()
    {
        { "CONFIG_ACCEPTED", TranscribeConfigStatusMessageType.ConfigAccepted },
        { "CONFIG_DENIED", TranscribeConfigStatusMessageType.ConfigDenied },
        { "CONFIG_TIMEOUT", TranscribeConfigStatusMessageType.ConfigTimeout },
        { "CONFIG_ALREADY_RECEIVED", TranscribeConfigStatusMessageType.ConfigAlreadyReceived },
        { "CONFIG_MISSING", TranscribeConfigStatusMessageType.ConfigMissing },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        TranscribeConfigStatusMessageType,
        string
    > _enumToString = new()
    {
        { TranscribeConfigStatusMessageType.ConfigAccepted, "CONFIG_ACCEPTED" },
        { TranscribeConfigStatusMessageType.ConfigDenied, "CONFIG_DENIED" },
        { TranscribeConfigStatusMessageType.ConfigTimeout, "CONFIG_TIMEOUT" },
        { TranscribeConfigStatusMessageType.ConfigAlreadyReceived, "CONFIG_ALREADY_RECEIVED" },
        { TranscribeConfigStatusMessageType.ConfigMissing, "CONFIG_MISSING" },
    };

    public override TranscribeConfigStatusMessageType Read(
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
        TranscribeConfigStatusMessageType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override TranscribeConfigStatusMessageType ReadAsPropertyName(
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
        TranscribeConfigStatusMessageType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
