using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(AgentsExpertReferenceTypeSerializer))]
public enum AgentsExpertReferenceType
{
    [EnumMember(Value = "reference")]
    Reference,
}

internal class AgentsExpertReferenceTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AgentsExpertReferenceType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AgentsExpertReferenceType
    > _stringToEnum = new() { { "reference", AgentsExpertReferenceType.Reference } };

    private static readonly global::System.Collections.Generic.Dictionary<
        AgentsExpertReferenceType,
        string
    > _enumToString = new() { { AgentsExpertReferenceType.Reference, "reference" } };

    public override AgentsExpertReferenceType Read(
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
        AgentsExpertReferenceType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AgentsExpertReferenceType ReadAsPropertyName(
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
        AgentsExpertReferenceType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
