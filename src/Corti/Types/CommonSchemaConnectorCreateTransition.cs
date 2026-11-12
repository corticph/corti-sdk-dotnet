using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(CommonSchemaConnectorCreateTransitionSerializer))]
public enum CommonSchemaConnectorCreateTransition
{
    [EnumMember(Value = "complete")]
    Complete,

    [EnumMember(Value = "input_required")]
    InputRequired,
}

internal class CommonSchemaConnectorCreateTransitionSerializer
    : global::System.Text.Json.Serialization.JsonConverter<CommonSchemaConnectorCreateTransition>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        CommonSchemaConnectorCreateTransition
    > _stringToEnum = new()
    {
        { "complete", CommonSchemaConnectorCreateTransition.Complete },
        { "input_required", CommonSchemaConnectorCreateTransition.InputRequired },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        CommonSchemaConnectorCreateTransition,
        string
    > _enumToString = new()
    {
        { CommonSchemaConnectorCreateTransition.Complete, "complete" },
        { CommonSchemaConnectorCreateTransition.InputRequired, "input_required" },
    };

    public override CommonSchemaConnectorCreateTransition Read(
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
        CommonSchemaConnectorCreateTransition value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override CommonSchemaConnectorCreateTransition ReadAsPropertyName(
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
        CommonSchemaConnectorCreateTransition value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
