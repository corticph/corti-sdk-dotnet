using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(InteractionsEncounterTypeEnumSerializer))]
public enum InteractionsEncounterTypeEnum
{
    [EnumMember(Value = "first_consultation")]
    FirstConsultation,

    [EnumMember(Value = "consultation")]
    Consultation,

    [EnumMember(Value = "emergency")]
    Emergency,

    [EnumMember(Value = "inpatient")]
    Inpatient,

    [EnumMember(Value = "outpatient")]
    Outpatient,
}

internal class InteractionsEncounterTypeEnumSerializer
    : global::System.Text.Json.Serialization.JsonConverter<InteractionsEncounterTypeEnum>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        InteractionsEncounterTypeEnum
    > _stringToEnum = new()
    {
        { "first_consultation", InteractionsEncounterTypeEnum.FirstConsultation },
        { "consultation", InteractionsEncounterTypeEnum.Consultation },
        { "emergency", InteractionsEncounterTypeEnum.Emergency },
        { "inpatient", InteractionsEncounterTypeEnum.Inpatient },
        { "outpatient", InteractionsEncounterTypeEnum.Outpatient },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        InteractionsEncounterTypeEnum,
        string
    > _enumToString = new()
    {
        { InteractionsEncounterTypeEnum.FirstConsultation, "first_consultation" },
        { InteractionsEncounterTypeEnum.Consultation, "consultation" },
        { InteractionsEncounterTypeEnum.Emergency, "emergency" },
        { InteractionsEncounterTypeEnum.Inpatient, "inpatient" },
        { InteractionsEncounterTypeEnum.Outpatient, "outpatient" },
    };

    public override InteractionsEncounterTypeEnum Read(
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
        InteractionsEncounterTypeEnum value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override InteractionsEncounterTypeEnum ReadAsPropertyName(
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
        InteractionsEncounterTypeEnum value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
