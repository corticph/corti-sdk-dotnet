using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(GuidedSectionListItemSourceSerializer))]
public enum GuidedSectionListItemSource
{
    [EnumMember(Value = "user")]
    User,

    [EnumMember(Value = "corti")]
    Corti,

    [EnumMember(Value = "project")]
    Project,
}

internal class GuidedSectionListItemSourceSerializer
    : global::System.Text.Json.Serialization.JsonConverter<GuidedSectionListItemSource>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        GuidedSectionListItemSource
    > _stringToEnum = new()
    {
        { "user", GuidedSectionListItemSource.User },
        { "corti", GuidedSectionListItemSource.Corti },
        { "project", GuidedSectionListItemSource.Project },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        GuidedSectionListItemSource,
        string
    > _enumToString = new()
    {
        { GuidedSectionListItemSource.User, "user" },
        { GuidedSectionListItemSource.Corti, "corti" },
        { GuidedSectionListItemSource.Project, "project" },
    };

    public override GuidedSectionListItemSource Read(
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
        GuidedSectionListItemSource value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override GuidedSectionListItemSource ReadAsPropertyName(
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
        GuidedSectionListItemSource value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
