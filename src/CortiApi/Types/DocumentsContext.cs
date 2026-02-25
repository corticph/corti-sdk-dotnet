// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(DocumentsContext.JsonConverter))]
[Serializable]
public record DocumentsContext
{
    internal DocumentsContext(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of DocumentsContext with <see cref="DocumentsContext.Facts"/>.
    /// </summary>
    public DocumentsContext(DocumentsContext.Facts value)
    {
        Type = "facts";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of DocumentsContext with <see cref="DocumentsContext.Transcript"/>.
    /// </summary>
    public DocumentsContext(DocumentsContext.Transcript value)
    {
        Type = "transcript";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of DocumentsContext with <see cref="DocumentsContext.String"/>.
    /// </summary>
    public DocumentsContext(DocumentsContext.String value)
    {
        Type = "string";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Type"/> is "facts"
    /// </summary>
    public bool IsFacts => Type == "facts";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "transcript"
    /// </summary>
    public bool IsTranscript => Type == "transcript";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "string"
    /// </summary>
    public bool IsString => Type == "string";

    /// <summary>
    /// Returns the value as a <see cref="CortiApi.DocumentsContextWithFacts"/> if <see cref="Type"/> is 'facts', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'facts'.</exception>
    public CortiApi.DocumentsContextWithFacts AsFacts() =>
        IsFacts
            ? (CortiApi.DocumentsContextWithFacts)Value!
            : throw new System.Exception("DocumentsContext.Type is not 'facts'");

    /// <summary>
    /// Returns the value as a <see cref="CortiApi.DocumentsContextWithTranscript"/> if <see cref="Type"/> is 'transcript', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'transcript'.</exception>
    public CortiApi.DocumentsContextWithTranscript AsTranscript() =>
        IsTranscript
            ? (CortiApi.DocumentsContextWithTranscript)Value!
            : throw new System.Exception("DocumentsContext.Type is not 'transcript'");

    /// <summary>
    /// Returns the value as a <see cref="CortiApi.DocumentsContextWithString"/> if <see cref="Type"/> is 'string', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'string'.</exception>
    public CortiApi.DocumentsContextWithString AsString() =>
        IsString
            ? (CortiApi.DocumentsContextWithString)Value!
            : throw new System.Exception("DocumentsContext.Type is not 'string'");

    public T Match<T>(
        Func<CortiApi.DocumentsContextWithFacts, T> onFacts,
        Func<CortiApi.DocumentsContextWithTranscript, T> onTranscript,
        Func<CortiApi.DocumentsContextWithString, T> onString,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "facts" => onFacts(AsFacts()),
            "transcript" => onTranscript(AsTranscript()),
            "string" => onString(AsString()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<CortiApi.DocumentsContextWithFacts> onFacts,
        Action<CortiApi.DocumentsContextWithTranscript> onTranscript,
        Action<CortiApi.DocumentsContextWithString> onString,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "facts":
                onFacts(AsFacts());
                break;
            case "transcript":
                onTranscript(AsTranscript());
                break;
            case "string":
                onString(AsString());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="CortiApi.DocumentsContextWithFacts"/> and returns true if successful.
    /// </summary>
    public bool TryAsFacts(out CortiApi.DocumentsContextWithFacts? value)
    {
        if (Type == "facts")
        {
            value = (CortiApi.DocumentsContextWithFacts)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="CortiApi.DocumentsContextWithTranscript"/> and returns true if successful.
    /// </summary>
    public bool TryAsTranscript(out CortiApi.DocumentsContextWithTranscript? value)
    {
        if (Type == "transcript")
        {
            value = (CortiApi.DocumentsContextWithTranscript)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="CortiApi.DocumentsContextWithString"/> and returns true if successful.
    /// </summary>
    public bool TryAsString(out CortiApi.DocumentsContextWithString? value)
    {
        if (Type == "string")
        {
            value = (CortiApi.DocumentsContextWithString)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator DocumentsContext(DocumentsContext.Facts value) => new(value);

    public static implicit operator DocumentsContext(DocumentsContext.Transcript value) =>
        new(value);

    public static implicit operator DocumentsContext(DocumentsContext.String value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<DocumentsContext>
    {
        public override bool CanConvert(System.Type typeToConvert) =>
            typeof(DocumentsContext).IsAssignableFrom(typeToConvert);

        public override DocumentsContext Read(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("type", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'type'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'type' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'type' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'type' is null");

            var value = discriminator switch
            {
                "facts" => json.Deserialize<CortiApi.DocumentsContextWithFacts?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize CortiApi.DocumentsContextWithFacts"
                    ),
                "transcript" => json.Deserialize<CortiApi.DocumentsContextWithTranscript?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize CortiApi.DocumentsContextWithTranscript"
                    ),
                "string" => json.Deserialize<CortiApi.DocumentsContextWithString?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize CortiApi.DocumentsContextWithString"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new DocumentsContext(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DocumentsContext value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "facts" => JsonSerializer.SerializeToNode(value.Value, options),
                    "transcript" => JsonSerializer.SerializeToNode(value.Value, options),
                    "string" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }
    }

    /// <summary>
    /// Discriminated union type for facts
    /// </summary>
    [Serializable]
    public struct Facts
    {
        public Facts(CortiApi.DocumentsContextWithFacts value)
        {
            Value = value;
        }

        internal CortiApi.DocumentsContextWithFacts Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator DocumentsContext.Facts(
            CortiApi.DocumentsContextWithFacts value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for transcript
    /// </summary>
    [Serializable]
    public struct Transcript
    {
        public Transcript(CortiApi.DocumentsContextWithTranscript value)
        {
            Value = value;
        }

        internal CortiApi.DocumentsContextWithTranscript Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator DocumentsContext.Transcript(
            CortiApi.DocumentsContextWithTranscript value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for string
    /// </summary>
    [Serializable]
    public struct String
    {
        public String(CortiApi.DocumentsContextWithString value)
        {
            Value = value;
        }

        internal CortiApi.DocumentsContextWithString Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator DocumentsContext.String(
            CortiApi.DocumentsContextWithString value
        ) => new(value);
    }
}
