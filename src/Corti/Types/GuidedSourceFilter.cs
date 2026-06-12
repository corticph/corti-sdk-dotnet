using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(GuidedSourceFilterSerializer))]
public enum GuidedSourceFilter
{
    [EnumMember(Value = "user")]
    User,

    [EnumMember(Value = "corti")]
    Corti,
}

internal class GuidedSourceFilterSerializer
    : global::System.Text.Json.Serialization.JsonConverter<GuidedSourceFilter>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        GuidedSourceFilter
    > _stringToEnum = new()
    {
        { "user", GuidedSourceFilter.User },
        { "corti", GuidedSourceFilter.Corti },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        GuidedSourceFilter,
        string
    > _enumToString = new()
    {
        { GuidedSourceFilter.User, "user" },
        { GuidedSourceFilter.Corti, "corti" },
    };

    public override GuidedSourceFilter Read(
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
        GuidedSourceFilter value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override GuidedSourceFilter ReadAsPropertyName(
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
        GuidedSourceFilter value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
