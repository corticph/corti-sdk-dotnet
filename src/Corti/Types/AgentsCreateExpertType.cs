using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(AgentsCreateExpertTypeSerializer))]
public enum AgentsCreateExpertType
{
    [EnumMember(Value = "new")]
    New,
}

internal class AgentsCreateExpertTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AgentsCreateExpertType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AgentsCreateExpertType
    > _stringToEnum = new() { { "new", AgentsCreateExpertType.New } };

    private static readonly global::System.Collections.Generic.Dictionary<
        AgentsCreateExpertType,
        string
    > _enumToString = new() { { AgentsCreateExpertType.New, "new" } };

    public override AgentsCreateExpertType Read(
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
        AgentsCreateExpertType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AgentsCreateExpertType ReadAsPropertyName(
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
        AgentsCreateExpertType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
