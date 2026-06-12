using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(TranscribeCommandVariableTypeSerializer))]
public enum TranscribeCommandVariableType
{
    [EnumMember(Value = "enum")]
    Enum,

    [EnumMember(Value = "wildcard")]
    Wildcard,
}

internal class TranscribeCommandVariableTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<TranscribeCommandVariableType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        TranscribeCommandVariableType
    > _stringToEnum = new()
    {
        { "enum", TranscribeCommandVariableType.Enum },
        { "wildcard", TranscribeCommandVariableType.Wildcard },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        TranscribeCommandVariableType,
        string
    > _enumToString = new()
    {
        { TranscribeCommandVariableType.Enum, "enum" },
        { TranscribeCommandVariableType.Wildcard, "wildcard" },
    };

    public override TranscribeCommandVariableType Read(
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
        TranscribeCommandVariableType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override TranscribeCommandVariableType ReadAsPropertyName(
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
        TranscribeCommandVariableType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
