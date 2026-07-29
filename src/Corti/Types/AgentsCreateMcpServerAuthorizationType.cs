using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(AgentsCreateMcpServerAuthorizationTypeSerializer))]
public enum AgentsCreateMcpServerAuthorizationType
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

internal class AgentsCreateMcpServerAuthorizationTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AgentsCreateMcpServerAuthorizationType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AgentsCreateMcpServerAuthorizationType
    > _stringToEnum = new()
    {
        { "none", AgentsCreateMcpServerAuthorizationType.None },
        { "bearer", AgentsCreateMcpServerAuthorizationType.Bearer },
        { "inherit", AgentsCreateMcpServerAuthorizationType.Inherit },
        { "oauth2.0", AgentsCreateMcpServerAuthorizationType.Oauth20 },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AgentsCreateMcpServerAuthorizationType,
        string
    > _enumToString = new()
    {
        { AgentsCreateMcpServerAuthorizationType.None, "none" },
        { AgentsCreateMcpServerAuthorizationType.Bearer, "bearer" },
        { AgentsCreateMcpServerAuthorizationType.Inherit, "inherit" },
        { AgentsCreateMcpServerAuthorizationType.Oauth20, "oauth2.0" },
    };

    public override AgentsCreateMcpServerAuthorizationType Read(
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
        AgentsCreateMcpServerAuthorizationType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AgentsCreateMcpServerAuthorizationType ReadAsPropertyName(
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
        AgentsCreateMcpServerAuthorizationType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
