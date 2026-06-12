using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(DocumentsContextWithStringTypeSerializer))]
public enum DocumentsContextWithStringType
{
    [EnumMember(Value = "string")]
    String,
}

internal class DocumentsContextWithStringTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<DocumentsContextWithStringType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        DocumentsContextWithStringType
    > _stringToEnum = new() { { "string", DocumentsContextWithStringType.String } };

    private static readonly global::System.Collections.Generic.Dictionary<
        DocumentsContextWithStringType,
        string
    > _enumToString = new() { { DocumentsContextWithStringType.String, "string" } };

    public override DocumentsContextWithStringType Read(
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
        DocumentsContextWithStringType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override DocumentsContextWithStringType ReadAsPropertyName(
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
        DocumentsContextWithStringType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
