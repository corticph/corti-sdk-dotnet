using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(GuidedTemplateSourceSerializer))]
public enum GuidedTemplateSource
{
    [EnumMember(Value = "user")]
    User,

    [EnumMember(Value = "corti")]
    Corti,
}

internal class GuidedTemplateSourceSerializer
    : global::System.Text.Json.Serialization.JsonConverter<GuidedTemplateSource>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        GuidedTemplateSource
    > _stringToEnum = new()
    {
        { "user", GuidedTemplateSource.User },
        { "corti", GuidedTemplateSource.Corti },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        GuidedTemplateSource,
        string
    > _enumToString = new()
    {
        { GuidedTemplateSource.User, "user" },
        { GuidedTemplateSource.Corti, "corti" },
    };

    public override GuidedTemplateSource Read(
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
        GuidedTemplateSource value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override GuidedTemplateSource ReadAsPropertyName(
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
        GuidedTemplateSource value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
