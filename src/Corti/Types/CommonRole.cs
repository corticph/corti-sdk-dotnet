using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(CommonRoleSerializer))]
public enum CommonRole
{
    [EnumMember(Value = "ROLE_USER")]
    RoleUser,

    [EnumMember(Value = "ROLE_AGENT")]
    RoleAgent,
}

internal class CommonRoleSerializer
    : global::System.Text.Json.Serialization.JsonConverter<CommonRole>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        CommonRole
    > _stringToEnum = new()
    {
        { "ROLE_USER", CommonRole.RoleUser },
        { "ROLE_AGENT", CommonRole.RoleAgent },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        CommonRole,
        string
    > _enumToString = new()
    {
        { CommonRole.RoleUser, "ROLE_USER" },
        { CommonRole.RoleAgent, "ROLE_AGENT" },
    };

    public override CommonRole Read(
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
        CommonRole value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override CommonRole ReadAsPropertyName(
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
        CommonRole value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
