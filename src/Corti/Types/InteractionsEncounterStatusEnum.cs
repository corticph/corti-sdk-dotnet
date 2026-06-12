using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(InteractionsEncounterStatusEnumSerializer))]
public enum InteractionsEncounterStatusEnum
{
    [EnumMember(Value = "planned")]
    Planned,

    [EnumMember(Value = "in-progress")]
    InProgress,

    [EnumMember(Value = "on-hold")]
    OnHold,

    [EnumMember(Value = "completed")]
    Completed,

    [EnumMember(Value = "cancelled")]
    Cancelled,

    [EnumMember(Value = "deleted")]
    Deleted,
}

internal class InteractionsEncounterStatusEnumSerializer
    : global::System.Text.Json.Serialization.JsonConverter<InteractionsEncounterStatusEnum>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        InteractionsEncounterStatusEnum
    > _stringToEnum = new()
    {
        { "planned", InteractionsEncounterStatusEnum.Planned },
        { "in-progress", InteractionsEncounterStatusEnum.InProgress },
        { "on-hold", InteractionsEncounterStatusEnum.OnHold },
        { "completed", InteractionsEncounterStatusEnum.Completed },
        { "cancelled", InteractionsEncounterStatusEnum.Cancelled },
        { "deleted", InteractionsEncounterStatusEnum.Deleted },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        InteractionsEncounterStatusEnum,
        string
    > _enumToString = new()
    {
        { InteractionsEncounterStatusEnum.Planned, "planned" },
        { InteractionsEncounterStatusEnum.InProgress, "in-progress" },
        { InteractionsEncounterStatusEnum.OnHold, "on-hold" },
        { InteractionsEncounterStatusEnum.Completed, "completed" },
        { InteractionsEncounterStatusEnum.Cancelled, "cancelled" },
        { InteractionsEncounterStatusEnum.Deleted, "deleted" },
    };

    public override InteractionsEncounterStatusEnum Read(
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
        InteractionsEncounterStatusEnum value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override InteractionsEncounterStatusEnum ReadAsPropertyName(
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
        InteractionsEncounterStatusEnum value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
