using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(AgentsMcpServerAuthorizationTypeSerializer))]
public enum AgentsMcpServerAuthorizationType
{
    [EnumMember(Value = "none")]
    None,

    [EnumMember(Value = "bearer")]
    Bearer,

    [EnumMember(Value = "inherit")]
    Inherit,

    [EnumMember(Value = "oauth2.0")]
    Oauth20,
}

internal class AgentsMcpServerAuthorizationTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AgentsMcpServerAuthorizationType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AgentsMcpServerAuthorizationType
    > _stringToEnum = new()
    {
        { "none", AgentsMcpServerAuthorizationType.None },
        { "bearer", AgentsMcpServerAuthorizationType.Bearer },
        { "inherit", AgentsMcpServerAuthorizationType.Inherit },
        { "oauth2.0", AgentsMcpServerAuthorizationType.Oauth20 },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AgentsMcpServerAuthorizationType,
        string
    > _enumToString = new()
    {
        { AgentsMcpServerAuthorizationType.None, "none" },
        { AgentsMcpServerAuthorizationType.Bearer, "bearer" },
        { AgentsMcpServerAuthorizationType.Inherit, "inherit" },
        { AgentsMcpServerAuthorizationType.Oauth20, "oauth2.0" },
    };

    public override AgentsMcpServerAuthorizationType Read(
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
        AgentsMcpServerAuthorizationType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AgentsMcpServerAuthorizationType ReadAsPropertyName(
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
        AgentsMcpServerAuthorizationType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
