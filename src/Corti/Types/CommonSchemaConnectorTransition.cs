using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(CommonSchemaConnectorTransitionSerializer))]
public enum CommonSchemaConnectorTransition
{
    [EnumMember(Value = "complete")]
    Complete,

    [EnumMember(Value = "input_required")]
    InputRequired,
}

internal class CommonSchemaConnectorTransitionSerializer
    : global::System.Text.Json.Serialization.JsonConverter<CommonSchemaConnectorTransition>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        CommonSchemaConnectorTransition
    > _stringToEnum = new()
    {
        { "complete", CommonSchemaConnectorTransition.Complete },
        { "input_required", CommonSchemaConnectorTransition.InputRequired },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        CommonSchemaConnectorTransition,
        string
    > _enumToString = new()
    {
        { CommonSchemaConnectorTransition.Complete, "complete" },
        { CommonSchemaConnectorTransition.InputRequired, "input_required" },
    };

    public override CommonSchemaConnectorTransition Read(
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
        CommonSchemaConnectorTransition value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override CommonSchemaConnectorTransition ReadAsPropertyName(
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
        CommonSchemaConnectorTransition value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
