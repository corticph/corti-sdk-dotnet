using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(LanguagesListRequestEndpointSerializer))]
public enum LanguagesListRequestEndpoint
{
    [EnumMember(Value = "streams")]
    Streams,

    [EnumMember(Value = "transcribe")]
    Transcribe,

    [EnumMember(Value = "transcripts")]
    Transcripts,
}

internal class LanguagesListRequestEndpointSerializer
    : global::System.Text.Json.Serialization.JsonConverter<LanguagesListRequestEndpoint>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        LanguagesListRequestEndpoint
    > _stringToEnum = new()
    {
        { "streams", LanguagesListRequestEndpoint.Streams },
        { "transcribe", LanguagesListRequestEndpoint.Transcribe },
        { "transcripts", LanguagesListRequestEndpoint.Transcripts },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        LanguagesListRequestEndpoint,
        string
    > _enumToString = new()
    {
        { LanguagesListRequestEndpoint.Streams, "streams" },
        { LanguagesListRequestEndpoint.Transcribe, "transcribe" },
        { LanguagesListRequestEndpoint.Transcripts, "transcripts" },
    };

    public override LanguagesListRequestEndpoint Read(
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
        LanguagesListRequestEndpoint value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override LanguagesListRequestEndpoint ReadAsPropertyName(
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
        LanguagesListRequestEndpoint value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
