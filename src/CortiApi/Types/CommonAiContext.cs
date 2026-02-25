// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(CommonAiContext.JsonConverter))]
[Serializable]
public record CommonAiContext
{
    internal CommonAiContext(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of CommonAiContext with <see cref="CommonAiContext.Text"/>.
    /// </summary>
    public CommonAiContext(CommonAiContext.Text value)
    {
        Type = "text";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CommonAiContext with <see cref="CommonAiContext.DocumentId"/>.
    /// </summary>
    public CommonAiContext(CommonAiContext.DocumentId value)
    {
        Type = "documentId";
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
    /// Returns true if <see cref="Type"/> is "text"
    /// </summary>
    public bool IsText => Type == "text";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "documentId"
    /// </summary>
    public bool IsDocumentId => Type == "documentId";

    /// <summary>
    /// Returns the value as a <see cref="CortiApi.Text"/> if <see cref="Type"/> is 'text', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'text'.</exception>
    public CortiApi.Text AsText() =>
        IsText
            ? (CortiApi.Text)Value!
            : throw new System.Exception("CommonAiContext.Type is not 'text'");

    /// <summary>
    /// Returns the value as a <see cref="CortiApi.DocumentId"/> if <see cref="Type"/> is 'documentId', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'documentId'.</exception>
    public CortiApi.DocumentId AsDocumentId() =>
        IsDocumentId
            ? (CortiApi.DocumentId)Value!
            : throw new System.Exception("CommonAiContext.Type is not 'documentId'");

    public T Match<T>(
        Func<CortiApi.Text, T> onText,
        Func<CortiApi.DocumentId, T> onDocumentId,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "text" => onText(AsText()),
            "documentId" => onDocumentId(AsDocumentId()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<CortiApi.Text> onText,
        Action<CortiApi.DocumentId> onDocumentId,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "text":
                onText(AsText());
                break;
            case "documentId":
                onDocumentId(AsDocumentId());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="CortiApi.Text"/> and returns true if successful.
    /// </summary>
    public bool TryAsText(out CortiApi.Text? value)
    {
        if (Type == "text")
        {
            value = (CortiApi.Text)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="CortiApi.DocumentId"/> and returns true if successful.
    /// </summary>
    public bool TryAsDocumentId(out CortiApi.DocumentId? value)
    {
        if (Type == "documentId")
        {
            value = (CortiApi.DocumentId)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator CommonAiContext(CommonAiContext.Text value) => new(value);

    public static implicit operator CommonAiContext(CommonAiContext.DocumentId value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CommonAiContext>
    {
        public override bool CanConvert(System.Type typeToConvert) =>
            typeof(CommonAiContext).IsAssignableFrom(typeToConvert);

        public override CommonAiContext Read(
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
                "text" => json.Deserialize<CortiApi.Text?>(options)
                    ?? throw new JsonException("Failed to deserialize CortiApi.Text"),
                "documentId" => json.Deserialize<CortiApi.DocumentId?>(options)
                    ?? throw new JsonException("Failed to deserialize CortiApi.DocumentId"),
                _ => json.Deserialize<object?>(options),
            };
            return new CommonAiContext(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CommonAiContext value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "text" => JsonSerializer.SerializeToNode(value.Value, options),
                    "documentId" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }
    }

    /// <summary>
    /// Discriminated union type for text
    /// </summary>
    [Serializable]
    public struct Text
    {
        public Text(CortiApi.Text value)
        {
            Value = value;
        }

        internal CortiApi.Text Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CommonAiContext.Text(CortiApi.Text value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for documentId
    /// </summary>
    [Serializable]
    public struct DocumentId
    {
        public DocumentId(CortiApi.DocumentId value)
        {
            Value = value;
        }

        internal CortiApi.DocumentId Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CommonAiContext.DocumentId(CortiApi.DocumentId value) =>
            new(value);
    }
}
