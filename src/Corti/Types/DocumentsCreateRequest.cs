// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(DocumentsCreateRequest.JsonConverter))]
[Serializable]
public class DocumentsCreateRequest
{
    private DocumentsCreateRequest(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Type discriminator
    /// </summary>
    [JsonIgnore]
    public string Type { get; internal set; }

    /// <summary>
    /// Union value
    /// </summary>
    [JsonIgnore]
    public object? Value { get; internal set; }

    /// <summary>
    /// Factory method to create a union from a Corti.DocumentsCreateRequestWithTemplateKey value.
    /// </summary>
    public static DocumentsCreateRequest FromDocumentsCreateRequestWithTemplateKey(
        Corti.DocumentsCreateRequestWithTemplateKey value
    ) => new("documentsCreateRequestWithTemplateKey", value);

    /// <summary>
    /// Factory method to create a union from a Corti.DocumentsCreateRequestWithTemplate value.
    /// </summary>
    public static DocumentsCreateRequest FromDocumentsCreateRequestWithTemplate(
        Corti.DocumentsCreateRequestWithTemplate value
    ) => new("documentsCreateRequestWithTemplate", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "documentsCreateRequestWithTemplateKey"
    /// </summary>
    public bool IsDocumentsCreateRequestWithTemplateKey() =>
        Type == "documentsCreateRequestWithTemplateKey";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "documentsCreateRequestWithTemplate"
    /// </summary>
    public bool IsDocumentsCreateRequestWithTemplate() =>
        Type == "documentsCreateRequestWithTemplate";

    /// <summary>
    /// Returns the value as a <see cref="Corti.DocumentsCreateRequestWithTemplateKey"/> if <see cref="Type"/> is 'documentsCreateRequestWithTemplateKey', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientBaseException">Thrown when <see cref="Type"/> is not 'documentsCreateRequestWithTemplateKey'.</exception>
    public Corti.DocumentsCreateRequestWithTemplateKey AsDocumentsCreateRequestWithTemplateKey() =>
        IsDocumentsCreateRequestWithTemplateKey()
            ? (Corti.DocumentsCreateRequestWithTemplateKey)Value!
            : throw new CortiClientBaseException(
                "Union type is not 'documentsCreateRequestWithTemplateKey'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Corti.DocumentsCreateRequestWithTemplate"/> if <see cref="Type"/> is 'documentsCreateRequestWithTemplate', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientBaseException">Thrown when <see cref="Type"/> is not 'documentsCreateRequestWithTemplate'.</exception>
    public Corti.DocumentsCreateRequestWithTemplate AsDocumentsCreateRequestWithTemplate() =>
        IsDocumentsCreateRequestWithTemplate()
            ? (Corti.DocumentsCreateRequestWithTemplate)Value!
            : throw new CortiClientBaseException(
                "Union type is not 'documentsCreateRequestWithTemplate'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.DocumentsCreateRequestWithTemplateKey"/> and returns true if successful.
    /// </summary>
    public bool TryGetDocumentsCreateRequestWithTemplateKey(
        out Corti.DocumentsCreateRequestWithTemplateKey? value
    )
    {
        if (Type == "documentsCreateRequestWithTemplateKey")
        {
            value = (Corti.DocumentsCreateRequestWithTemplateKey)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.DocumentsCreateRequestWithTemplate"/> and returns true if successful.
    /// </summary>
    public bool TryGetDocumentsCreateRequestWithTemplate(
        out Corti.DocumentsCreateRequestWithTemplate? value
    )
    {
        if (Type == "documentsCreateRequestWithTemplate")
        {
            value = (Corti.DocumentsCreateRequestWithTemplate)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Corti.DocumentsCreateRequestWithTemplateKey,
            T
        > onDocumentsCreateRequestWithTemplateKey,
        Func<Corti.DocumentsCreateRequestWithTemplate, T> onDocumentsCreateRequestWithTemplate
    )
    {
        return Type switch
        {
            "documentsCreateRequestWithTemplateKey" => onDocumentsCreateRequestWithTemplateKey(
                AsDocumentsCreateRequestWithTemplateKey()
            ),
            "documentsCreateRequestWithTemplate" => onDocumentsCreateRequestWithTemplate(
                AsDocumentsCreateRequestWithTemplate()
            ),
            _ => throw new CortiClientBaseException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Corti.DocumentsCreateRequestWithTemplateKey> onDocumentsCreateRequestWithTemplateKey,
        Action<Corti.DocumentsCreateRequestWithTemplate> onDocumentsCreateRequestWithTemplate
    )
    {
        switch (Type)
        {
            case "documentsCreateRequestWithTemplateKey":
                onDocumentsCreateRequestWithTemplateKey(AsDocumentsCreateRequestWithTemplateKey());
                break;
            case "documentsCreateRequestWithTemplate":
                onDocumentsCreateRequestWithTemplate(AsDocumentsCreateRequestWithTemplate());
                break;
            default:
                throw new CortiClientBaseException($"Unknown union type: {Type}");
        }
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = Type.GetHashCode();
            if (Value != null)
            {
                hashCode = (hashCode * 397) ^ Value.GetHashCode();
            }
            return hashCode;
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj is not DocumentsCreateRequest other)
            return false;

        // Compare type discriminators
        if (Type != other.Type)
            return false;

        // Compare values using EqualityComparer for deep comparison
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator DocumentsCreateRequest(
        Corti.DocumentsCreateRequestWithTemplateKey value
    ) => new("documentsCreateRequestWithTemplateKey", value);

    public static implicit operator DocumentsCreateRequest(
        Corti.DocumentsCreateRequestWithTemplate value
    ) => new("documentsCreateRequestWithTemplate", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<DocumentsCreateRequest>
    {
        public override DocumentsCreateRequest? Read(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, System.Type Type)[]
                {
                    (
                        "documentsCreateRequestWithTemplateKey",
                        typeof(Corti.DocumentsCreateRequestWithTemplateKey)
                    ),
                    (
                        "documentsCreateRequestWithTemplate",
                        typeof(Corti.DocumentsCreateRequestWithTemplate)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            DocumentsCreateRequest result = new(key, value);
                            return result;
                        }
                    }
                    catch (JsonException)
                    {
                        // Try next type;
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into DocumentsCreateRequest"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            DocumentsCreateRequest value,
            JsonSerializerOptions options
        )
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            value.Visit(
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override DocumentsCreateRequest ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            DocumentsCreateRequest result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DocumentsCreateRequest value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
