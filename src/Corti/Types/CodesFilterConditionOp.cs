using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(CodesFilterConditionOpSerializer))]
public enum CodesFilterConditionOp
{
    [EnumMember(Value = "=")]
    EqualTo,

    [EnumMember(Value = "is-a")]
    IsA,

    [EnumMember(Value = "descendent-of")]
    DescendentOf,

    [EnumMember(Value = "exists")]
    Exists,

    [EnumMember(Value = "in")]
    In,
}

internal class CodesFilterConditionOpSerializer
    : global::System.Text.Json.Serialization.JsonConverter<CodesFilterConditionOp>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        CodesFilterConditionOp
    > _stringToEnum = new()
    {
        { "=", CodesFilterConditionOp.EqualTo },
        { "is-a", CodesFilterConditionOp.IsA },
        { "descendent-of", CodesFilterConditionOp.DescendentOf },
        { "exists", CodesFilterConditionOp.Exists },
        { "in", CodesFilterConditionOp.In },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        CodesFilterConditionOp,
        string
    > _enumToString = new()
    {
        { CodesFilterConditionOp.EqualTo, "=" },
        { CodesFilterConditionOp.IsA, "is-a" },
        { CodesFilterConditionOp.DescendentOf, "descendent-of" },
        { CodesFilterConditionOp.Exists, "exists" },
        { CodesFilterConditionOp.In, "in" },
    };

    public override CodesFilterConditionOp Read(
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
        CodesFilterConditionOp value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override CodesFilterConditionOp ReadAsPropertyName(
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
        CodesFilterConditionOp value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
