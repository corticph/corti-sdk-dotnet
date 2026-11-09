using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(InteractionsDeletionReasonEnumSerializer))]
public enum InteractionsDeletionReasonEnum
{
    [EnumMember(Value = "manual")]
    Manual,

    [EnumMember(Value = "other")]
    Other,

    [EnumMember(Value = "retention")]
    Retention,
}

internal class InteractionsDeletionReasonEnumSerializer
    : global::System.Text.Json.Serialization.JsonConverter<InteractionsDeletionReasonEnum>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        InteractionsDeletionReasonEnum
    > _stringToEnum = new()
    {
        { "manual", InteractionsDeletionReasonEnum.Manual },
        { "other", InteractionsDeletionReasonEnum.Other },
        { "retention", InteractionsDeletionReasonEnum.Retention },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        InteractionsDeletionReasonEnum,
        string
    > _enumToString = new()
    {
        { InteractionsDeletionReasonEnum.Manual, "manual" },
        { InteractionsDeletionReasonEnum.Other, "other" },
        { InteractionsDeletionReasonEnum.Retention, "retention" },
    };

    public override InteractionsDeletionReasonEnum Read(
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
        InteractionsDeletionReasonEnum value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override InteractionsDeletionReasonEnum ReadAsPropertyName(
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
        InteractionsDeletionReasonEnum value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
