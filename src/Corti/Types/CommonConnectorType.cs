using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(CommonConnectorTypeSerializer))]
public enum CommonConnectorType
{
    [EnumMember(Value = "registry")]
    Registry,

    [EnumMember(Value = "mcp")]
    Mcp,

    [EnumMember(Value = "agent")]
    Agent,

    [EnumMember(Value = "a2a")]
    A2A,

    [EnumMember(Value = "schema")]
    Schema,
}

internal class CommonConnectorTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<CommonConnectorType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        CommonConnectorType
    > _stringToEnum = new()
    {
        { "registry", CommonConnectorType.Registry },
        { "mcp", CommonConnectorType.Mcp },
        { "agent", CommonConnectorType.Agent },
        { "a2a", CommonConnectorType.A2A },
        { "schema", CommonConnectorType.Schema },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        CommonConnectorType,
        string
    > _enumToString = new()
    {
        { CommonConnectorType.Registry, "registry" },
        { CommonConnectorType.Mcp, "mcp" },
        { CommonConnectorType.Agent, "agent" },
        { CommonConnectorType.A2A, "a2a" },
        { CommonConnectorType.Schema, "schema" },
    };

    public override CommonConnectorType Read(
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
        CommonConnectorType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override CommonConnectorType ReadAsPropertyName(
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
        CommonConnectorType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
