using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(AgentsAgentReferenceTypeSerializer))]
public enum AgentsAgentReferenceType
{
    [EnumMember(Value = "reference")]
    Reference,
}

internal class AgentsAgentReferenceTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AgentsAgentReferenceType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AgentsAgentReferenceType
    > _stringToEnum = new() { { "reference", AgentsAgentReferenceType.Reference } };

    private static readonly global::System.Collections.Generic.Dictionary<
        AgentsAgentReferenceType,
        string
    > _enumToString = new() { { AgentsAgentReferenceType.Reference, "reference" } };

    public override AgentsAgentReferenceType Read(
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
        AgentsAgentReferenceType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AgentsAgentReferenceType ReadAsPropertyName(
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
        AgentsAgentReferenceType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
