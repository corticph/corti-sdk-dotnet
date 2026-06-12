using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(GuidedSectionSourceSerializer))]
public enum GuidedSectionSource
{
    [EnumMember(Value = "user")]
    User,

    [EnumMember(Value = "corti")]
    Corti,
}

internal class GuidedSectionSourceSerializer
    : global::System.Text.Json.Serialization.JsonConverter<GuidedSectionSource>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        GuidedSectionSource
    > _stringToEnum = new()
    {
        { "user", GuidedSectionSource.User },
        { "corti", GuidedSectionSource.Corti },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        GuidedSectionSource,
        string
    > _enumToString = new()
    {
        { GuidedSectionSource.User, "user" },
        { GuidedSectionSource.Corti, "corti" },
    };

    public override GuidedSectionSource Read(
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
        GuidedSectionSource value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override GuidedSectionSource ReadAsPropertyName(
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
        GuidedSectionSource value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
