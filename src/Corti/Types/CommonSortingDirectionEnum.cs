using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(CommonSortingDirectionEnumSerializer))]
public enum CommonSortingDirectionEnum
{
    [EnumMember(Value = "asc")]
    Asc,

    [EnumMember(Value = "desc")]
    Desc,
}

internal class CommonSortingDirectionEnumSerializer
    : global::System.Text.Json.Serialization.JsonConverter<CommonSortingDirectionEnum>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        CommonSortingDirectionEnum
    > _stringToEnum = new()
    {
        { "asc", CommonSortingDirectionEnum.Asc },
        { "desc", CommonSortingDirectionEnum.Desc },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        CommonSortingDirectionEnum,
        string
    > _enumToString = new()
    {
        { CommonSortingDirectionEnum.Asc, "asc" },
        { CommonSortingDirectionEnum.Desc, "desc" },
    };

    public override CommonSortingDirectionEnum Read(
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
        CommonSortingDirectionEnum value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override CommonSortingDirectionEnum ReadAsPropertyName(
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
        CommonSortingDirectionEnum value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
