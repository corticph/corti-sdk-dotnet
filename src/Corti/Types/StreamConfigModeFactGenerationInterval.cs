using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(StreamConfigModeFactGenerationIntervalSerializer))]
public enum StreamConfigModeFactGenerationInterval
{
    [EnumMember(Value = "fixed")]
    Fixed,

    [EnumMember(Value = "fast_init")]
    FastInit,
}

internal class StreamConfigModeFactGenerationIntervalSerializer
    : global::System.Text.Json.Serialization.JsonConverter<StreamConfigModeFactGenerationInterval>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        StreamConfigModeFactGenerationInterval
    > _stringToEnum = new()
    {
        { "fixed", StreamConfigModeFactGenerationInterval.Fixed },
        { "fast_init", StreamConfigModeFactGenerationInterval.FastInit },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        StreamConfigModeFactGenerationInterval,
        string
    > _enumToString = new()
    {
        { StreamConfigModeFactGenerationInterval.Fixed, "fixed" },
        { StreamConfigModeFactGenerationInterval.FastInit, "fast_init" },
    };

    public override StreamConfigModeFactGenerationInterval Read(
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
        StreamConfigModeFactGenerationInterval value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override StreamConfigModeFactGenerationInterval ReadAsPropertyName(
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
        StreamConfigModeFactGenerationInterval value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
