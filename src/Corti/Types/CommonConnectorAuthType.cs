using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(CommonConnectorAuthTypeSerializer))]
public enum CommonConnectorAuthType
{
    [EnumMember(Value = "none")]
    None,

    [EnumMember(Value = "bearer")]
    Bearer,

    [EnumMember(Value = "apiKey")]
    ApiKey,

    [EnumMember(Value = "oauth2")]
    Oauth2,

    [EnumMember(Value = "inherit")]
    Inherit,
}

internal class CommonConnectorAuthTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<CommonConnectorAuthType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        CommonConnectorAuthType
    > _stringToEnum = new()
    {
        { "none", CommonConnectorAuthType.None },
        { "bearer", CommonConnectorAuthType.Bearer },
        { "apiKey", CommonConnectorAuthType.ApiKey },
        { "oauth2", CommonConnectorAuthType.Oauth2 },
        { "inherit", CommonConnectorAuthType.Inherit },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        CommonConnectorAuthType,
        string
    > _enumToString = new()
    {
        { CommonConnectorAuthType.None, "none" },
        { CommonConnectorAuthType.Bearer, "bearer" },
        { CommonConnectorAuthType.ApiKey, "apiKey" },
        { CommonConnectorAuthType.Oauth2, "oauth2" },
        { CommonConnectorAuthType.Inherit, "inherit" },
    };

    public override CommonConnectorAuthType Read(
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
        CommonConnectorAuthType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override CommonConnectorAuthType ReadAsPropertyName(
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
        CommonConnectorAuthType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
