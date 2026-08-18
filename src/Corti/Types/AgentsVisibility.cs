using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(AgentsVisibilitySerializer))]
public enum AgentsVisibility
{
    [EnumMember(Value = "private")]
    Private,

    [EnumMember(Value = "unlisted")]
    Unlisted,

    [EnumMember(Value = "public")]
    Public,
}

internal class AgentsVisibilitySerializer
    : global::System.Text.Json.Serialization.JsonConverter<AgentsVisibility>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AgentsVisibility
    > _stringToEnum = new()
    {
        { "private", AgentsVisibility.Private },
        { "unlisted", AgentsVisibility.Unlisted },
        { "public", AgentsVisibility.Public },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AgentsVisibility,
        string
    > _enumToString = new()
    {
        { AgentsVisibility.Private, "private" },
        { AgentsVisibility.Unlisted, "unlisted" },
        { AgentsVisibility.Public, "public" },
    };

    public override AgentsVisibility Read(
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
        AgentsVisibility value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AgentsVisibility ReadAsPropertyName(
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
        AgentsVisibility value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
