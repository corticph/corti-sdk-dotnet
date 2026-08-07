using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(GenerateDocumentsRequestXCortiRetentionPolicySerializer))]
public enum GenerateDocumentsRequestXCortiRetentionPolicy
{
    [EnumMember(Value = "none")]
    None,
}

internal class GenerateDocumentsRequestXCortiRetentionPolicySerializer
    : global::System.Text.Json.Serialization.JsonConverter<GenerateDocumentsRequestXCortiRetentionPolicy>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        GenerateDocumentsRequestXCortiRetentionPolicy
    > _stringToEnum = new() { { "none", GenerateDocumentsRequestXCortiRetentionPolicy.None } };

    private static readonly global::System.Collections.Generic.Dictionary<
        GenerateDocumentsRequestXCortiRetentionPolicy,
        string
    > _enumToString = new() { { GenerateDocumentsRequestXCortiRetentionPolicy.None, "none" } };

    public override GenerateDocumentsRequestXCortiRetentionPolicy Read(
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
        GenerateDocumentsRequestXCortiRetentionPolicy value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override GenerateDocumentsRequestXCortiRetentionPolicy ReadAsPropertyName(
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
        GenerateDocumentsRequestXCortiRetentionPolicy value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
