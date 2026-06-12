using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(StreamConfigParticipantRoleSerializer))]
public enum StreamConfigParticipantRole
{
    [EnumMember(Value = "doctor")]
    Doctor,

    [EnumMember(Value = "patient")]
    Patient,

    [EnumMember(Value = "multiple")]
    Multiple,
}

internal class StreamConfigParticipantRoleSerializer
    : global::System.Text.Json.Serialization.JsonConverter<StreamConfigParticipantRole>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        StreamConfigParticipantRole
    > _stringToEnum = new()
    {
        { "doctor", StreamConfigParticipantRole.Doctor },
        { "patient", StreamConfigParticipantRole.Patient },
        { "multiple", StreamConfigParticipantRole.Multiple },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        StreamConfigParticipantRole,
        string
    > _enumToString = new()
    {
        { StreamConfigParticipantRole.Doctor, "doctor" },
        { StreamConfigParticipantRole.Patient, "patient" },
        { StreamConfigParticipantRole.Multiple, "multiple" },
    };

    public override StreamConfigParticipantRole Read(
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
        StreamConfigParticipantRole value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override StreamConfigParticipantRole ReadAsPropertyName(
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
        StreamConfigParticipantRole value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
