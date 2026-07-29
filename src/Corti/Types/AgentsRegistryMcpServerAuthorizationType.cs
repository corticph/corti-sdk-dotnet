using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(AgentsRegistryMcpServerAuthorizationTypeSerializer))]
public enum AgentsRegistryMcpServerAuthorizationType
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

internal class AgentsRegistryMcpServerAuthorizationTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AgentsRegistryMcpServerAuthorizationType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AgentsRegistryMcpServerAuthorizationType
    > _stringToEnum = new()
    {
        { "none", AgentsRegistryMcpServerAuthorizationType.None },
        { "bearer", AgentsRegistryMcpServerAuthorizationType.Bearer },
        { "inherit", AgentsRegistryMcpServerAuthorizationType.Inherit },
        { "oauth2.0", AgentsRegistryMcpServerAuthorizationType.Oauth20 },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AgentsRegistryMcpServerAuthorizationType,
        string
    > _enumToString = new()
    {
        { AgentsRegistryMcpServerAuthorizationType.None, "none" },
        { AgentsRegistryMcpServerAuthorizationType.Bearer, "bearer" },
        { AgentsRegistryMcpServerAuthorizationType.Inherit, "inherit" },
        { AgentsRegistryMcpServerAuthorizationType.Oauth20, "oauth2.0" },
    };

    public override AgentsRegistryMcpServerAuthorizationType Read(
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
        AgentsRegistryMcpServerAuthorizationType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AgentsRegistryMcpServerAuthorizationType ReadAsPropertyName(
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
        AgentsRegistryMcpServerAuthorizationType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
