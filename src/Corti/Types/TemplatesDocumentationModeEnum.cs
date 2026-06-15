using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(TemplatesDocumentationModeEnumSerializer))]
public enum TemplatesDocumentationModeEnum
{
    [EnumMember(Value = "global_sequential")]
    GlobalSequential,

    [EnumMember(Value = "routed_parallel")]
    RoutedParallel,
}

internal class TemplatesDocumentationModeEnumSerializer
    : global::System.Text.Json.Serialization.JsonConverter<TemplatesDocumentationModeEnum>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        TemplatesDocumentationModeEnum
    > _stringToEnum = new()
    {
        { "global_sequential", TemplatesDocumentationModeEnum.GlobalSequential },
        { "routed_parallel", TemplatesDocumentationModeEnum.RoutedParallel },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        TemplatesDocumentationModeEnum,
        string
    > _enumToString = new()
    {
        { TemplatesDocumentationModeEnum.GlobalSequential, "global_sequential" },
        { TemplatesDocumentationModeEnum.RoutedParallel, "routed_parallel" },
    };

    public override TemplatesDocumentationModeEnum Read(
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
        TemplatesDocumentationModeEnum value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override TemplatesDocumentationModeEnum ReadAsPropertyName(
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
        TemplatesDocumentationModeEnum value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
