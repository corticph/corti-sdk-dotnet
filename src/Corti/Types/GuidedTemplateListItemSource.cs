using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(GuidedTemplateListItemSourceSerializer))]
public enum GuidedTemplateListItemSource
{
    [EnumMember(Value = "user")]
    User,

    [EnumMember(Value = "corti")]
    Corti,

    [EnumMember(Value = "project")]
    Project,
}

internal class GuidedTemplateListItemSourceSerializer
    : global::System.Text.Json.Serialization.JsonConverter<GuidedTemplateListItemSource>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        GuidedTemplateListItemSource
    > _stringToEnum = new()
    {
        { "user", GuidedTemplateListItemSource.User },
        { "corti", GuidedTemplateListItemSource.Corti },
        { "project", GuidedTemplateListItemSource.Project },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        GuidedTemplateListItemSource,
        string
    > _enumToString = new()
    {
        { GuidedTemplateListItemSource.User, "user" },
        { GuidedTemplateListItemSource.Corti, "corti" },
        { GuidedTemplateListItemSource.Project, "project" },
    };

    public override GuidedTemplateListItemSource Read(
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
        GuidedTemplateListItemSource value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override GuidedTemplateListItemSource ReadAsPropertyName(
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
        GuidedTemplateListItemSource value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
