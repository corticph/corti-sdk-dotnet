using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(AgenticRegistryConnectorStatusSerializer))]
public enum AgenticRegistryConnectorStatus
{
    [EnumMember(Value = "private")]
    Private,

    [EnumMember(Value = "public")]
    Public,

    [EnumMember(Value = "archived")]
    Archived,
}

internal class AgenticRegistryConnectorStatusSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AgenticRegistryConnectorStatus>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AgenticRegistryConnectorStatus
    > _stringToEnum = new()
    {
        { "private", AgenticRegistryConnectorStatus.Private },
        { "public", AgenticRegistryConnectorStatus.Public },
        { "archived", AgenticRegistryConnectorStatus.Archived },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AgenticRegistryConnectorStatus,
        string
    > _enumToString = new()
    {
        { AgenticRegistryConnectorStatus.Private, "private" },
        { AgenticRegistryConnectorStatus.Public, "public" },
        { AgenticRegistryConnectorStatus.Archived, "archived" },
    };

    public override AgenticRegistryConnectorStatus Read(
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
        AgenticRegistryConnectorStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AgenticRegistryConnectorStatus ReadAsPropertyName(
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
        AgenticRegistryConnectorStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
