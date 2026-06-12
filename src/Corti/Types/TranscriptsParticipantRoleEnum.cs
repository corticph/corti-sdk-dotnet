using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(TranscriptsParticipantRoleEnumSerializer))]
public enum TranscriptsParticipantRoleEnum
{
    [EnumMember(Value = "doctor")]
    Doctor,

    [EnumMember(Value = "patient")]
    Patient,

    [EnumMember(Value = "multiple")]
    Multiple,
}

internal class TranscriptsParticipantRoleEnumSerializer
    : global::System.Text.Json.Serialization.JsonConverter<TranscriptsParticipantRoleEnum>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        TranscriptsParticipantRoleEnum
    > _stringToEnum = new()
    {
        { "doctor", TranscriptsParticipantRoleEnum.Doctor },
        { "patient", TranscriptsParticipantRoleEnum.Patient },
        { "multiple", TranscriptsParticipantRoleEnum.Multiple },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        TranscriptsParticipantRoleEnum,
        string
    > _enumToString = new()
    {
        { TranscriptsParticipantRoleEnum.Doctor, "doctor" },
        { TranscriptsParticipantRoleEnum.Patient, "patient" },
        { TranscriptsParticipantRoleEnum.Multiple, "multiple" },
    };

    public override TranscriptsParticipantRoleEnum Read(
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
        TranscriptsParticipantRoleEnum value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override TranscriptsParticipantRoleEnum ReadAsPropertyName(
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
        TranscriptsParticipantRoleEnum value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
