using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(InteractionsGenderEnumSerializer))]
public enum InteractionsGenderEnum
{
    [EnumMember(Value = "male")]
    Male,

    [EnumMember(Value = "female")]
    Female,

    [EnumMember(Value = "unknown")]
    Unknown,

    [EnumMember(Value = "other")]
    Other,
}

internal class InteractionsGenderEnumSerializer
    : global::System.Text.Json.Serialization.JsonConverter<InteractionsGenderEnum>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        InteractionsGenderEnum
    > _stringToEnum = new()
    {
        { "male", InteractionsGenderEnum.Male },
        { "female", InteractionsGenderEnum.Female },
        { "unknown", InteractionsGenderEnum.Unknown },
        { "other", InteractionsGenderEnum.Other },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        InteractionsGenderEnum,
        string
    > _enumToString = new()
    {
        { InteractionsGenderEnum.Male, "male" },
        { InteractionsGenderEnum.Female, "female" },
        { InteractionsGenderEnum.Unknown, "unknown" },
        { InteractionsGenderEnum.Other, "other" },
    };

    public override InteractionsGenderEnum Read(
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
        InteractionsGenderEnum value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override InteractionsGenderEnum ReadAsPropertyName(
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
        InteractionsGenderEnum value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
