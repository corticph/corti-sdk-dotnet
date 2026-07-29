using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(AgentsFilePartKindSerializer))]
public enum AgentsFilePartKind
{
    [EnumMember(Value = "file")]
    File,
}

internal class AgentsFilePartKindSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AgentsFilePartKind>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AgentsFilePartKind
    > _stringToEnum = new() { { "file", AgentsFilePartKind.File } };

    private static readonly global::System.Collections.Generic.Dictionary<
        AgentsFilePartKind,
        string
    > _enumToString = new() { { AgentsFilePartKind.File, "file" } };

    public override AgentsFilePartKind Read(
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
        AgentsFilePartKind value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AgentsFilePartKind ReadAsPropertyName(
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
        AgentsFilePartKind value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
