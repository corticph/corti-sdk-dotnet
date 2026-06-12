using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(CommonSourceEnumSerializer))]
public enum CommonSourceEnum
{
    [EnumMember(Value = "core")]
    Core,

    [EnumMember(Value = "system")]
    System,

    [EnumMember(Value = "user")]
    User,
}

internal class CommonSourceEnumSerializer
    : global::System.Text.Json.Serialization.JsonConverter<CommonSourceEnum>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        CommonSourceEnum
    > _stringToEnum = new()
    {
        { "core", CommonSourceEnum.Core },
        { "system", CommonSourceEnum.System },
        { "user", CommonSourceEnum.User },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        CommonSourceEnum,
        string
    > _enumToString = new()
    {
        { CommonSourceEnum.Core, "core" },
        { CommonSourceEnum.System, "system" },
        { CommonSourceEnum.User, "user" },
    };

    public override CommonSourceEnum Read(
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
        CommonSourceEnum value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override CommonSourceEnum ReadAsPropertyName(
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
        CommonSourceEnum value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
