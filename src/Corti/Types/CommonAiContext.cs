// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

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
    /// Returns the value as a <see cref="Corti.Text"/> if <see cref="Type"/> is 'text', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'text'.</exception>
    public Corti.Text AsText() =>
        IsText
            ? (Corti.Text)Value!
            : throw new System.Exception("CommonAiContext.Type is not 'text'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.DocumentId"/> if <see cref="Type"/> is 'documentId', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'documentId'.</exception>
    public Corti.DocumentId AsDocumentId() =>
        IsDocumentId
            ? (Corti.DocumentId)Value!
            : throw new System.Exception("CommonAiContext.Type is not 'documentId'");

    public T Match<T>(
        Func<Corti.Text, T> onText,
        Func<Corti.DocumentId, T> onDocumentId,
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
        Action<Corti.Text> onText,
        Action<Corti.DocumentId> onDocumentId,
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
    /// Attempts to cast the value to a <see cref="Corti.Text"/> and returns true if successful.
    /// </summary>
    public bool TryAsText(out Corti.Text? value)
    {
        if (Type == "text")
        {
            value = (Corti.Text)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.DocumentId"/> and returns true if successful.
    /// </summary>
    public bool TryAsDocumentId(out Corti.DocumentId? value)
    {
        if (Type == "documentId")
        {
            value = (Corti.DocumentId)Value!;
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
                "text" => json.Deserialize<Corti.Text?>(options)
                    ?? throw new JsonException("Failed to deserialize Corti.Text"),
                "documentId" => json.Deserialize<Corti.DocumentId?>(options)
                    ?? throw new JsonException("Failed to deserialize Corti.DocumentId"),
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
        public Text(Corti.Text value)
        {
            Value = value;
        }

        internal Corti.Text Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CommonAiContext.Text(Corti.Text value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for documentId
    /// </summary>
    [Serializable]
    public struct DocumentId
    {
        public DocumentId(Corti.DocumentId value)
        {
            Value = value;
        }

        internal Corti.DocumentId Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CommonAiContext.DocumentId(Corti.DocumentId value) =>
            new(value);
    }
}
