using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(AgenticVisibilitySerializer))]
public enum AgenticVisibility
{
    [EnumMember(Value = "private")]
    Private,

    [EnumMember(Value = "unlisted")]
    Unlisted,

    [EnumMember(Value = "public")]
    Public,
}

internal class AgenticVisibilitySerializer
    : global::System.Text.Json.Serialization.JsonConverter<AgenticVisibility>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AgenticVisibility
    > _stringToEnum = new()
    {
        { "private", AgenticVisibility.Private },
        { "unlisted", AgenticVisibility.Unlisted },
        { "public", AgenticVisibility.Public },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AgenticVisibility,
        string
    > _enumToString = new()
    {
        { AgenticVisibility.Private, "private" },
        { AgenticVisibility.Unlisted, "unlisted" },
        { AgenticVisibility.Public, "public" },
    };

    public override AgenticVisibility Read(
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
        AgenticVisibility value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AgenticVisibility ReadAsPropertyName(
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
        AgenticVisibility value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
