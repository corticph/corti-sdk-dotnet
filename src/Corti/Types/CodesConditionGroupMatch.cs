using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(CodesConditionGroupMatchSerializer))]
public enum CodesConditionGroupMatch
{
    [EnumMember(Value = "all")]
    All,

    [EnumMember(Value = "any")]
    Any,
}

internal class CodesConditionGroupMatchSerializer
    : global::System.Text.Json.Serialization.JsonConverter<CodesConditionGroupMatch>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        CodesConditionGroupMatch
    > _stringToEnum = new()
    {
        { "all", CodesConditionGroupMatch.All },
        { "any", CodesConditionGroupMatch.Any },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        CodesConditionGroupMatch,
        string
    > _enumToString = new()
    {
        { CodesConditionGroupMatch.All, "all" },
        { CodesConditionGroupMatch.Any, "any" },
    };

    public override CodesConditionGroupMatch Read(
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
        CodesConditionGroupMatch value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override CodesConditionGroupMatch ReadAsPropertyName(
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
        CodesConditionGroupMatch value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
