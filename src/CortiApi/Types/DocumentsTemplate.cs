// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(DocumentsTemplate.JsonConverter))]
[Serializable]
public class DocumentsTemplate
{
    private DocumentsTemplate(string type, object? value)
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
    /// Factory method to create a union from a CortiApi.DocumentsTemplateWithSections value.
    /// </summary>
    public static DocumentsTemplate FromDocumentsTemplateWithSections(
        CortiApi.DocumentsTemplateWithSections value
    ) => new("documentsTemplateWithSections", value);

    /// <summary>
    /// Factory method to create a union from a CortiApi.DocumentsTemplateWithSectionKeys value.
    /// </summary>
    public static DocumentsTemplate FromDocumentsTemplateWithSectionKeys(
        CortiApi.DocumentsTemplateWithSectionKeys value
    ) => new("documentsTemplateWithSectionKeys", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "documentsTemplateWithSections"
    /// </summary>
    public bool IsDocumentsTemplateWithSections() => Type == "documentsTemplateWithSections";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "documentsTemplateWithSectionKeys"
    /// </summary>
    public bool IsDocumentsTemplateWithSectionKeys() => Type == "documentsTemplateWithSectionKeys";

    /// <summary>
    /// Returns the value as a <see cref="CortiApi.DocumentsTemplateWithSections"/> if <see cref="Type"/> is 'documentsTemplateWithSections', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'documentsTemplateWithSections'.</exception>
    public CortiApi.DocumentsTemplateWithSections AsDocumentsTemplateWithSections() =>
        IsDocumentsTemplateWithSections()
            ? (CortiApi.DocumentsTemplateWithSections)Value!
            : throw new CortiClientException("Union type is not 'documentsTemplateWithSections'");

    /// <summary>
    /// Returns the value as a <see cref="CortiApi.DocumentsTemplateWithSectionKeys"/> if <see cref="Type"/> is 'documentsTemplateWithSectionKeys', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'documentsTemplateWithSectionKeys'.</exception>
    public CortiApi.DocumentsTemplateWithSectionKeys AsDocumentsTemplateWithSectionKeys() =>
        IsDocumentsTemplateWithSectionKeys()
            ? (CortiApi.DocumentsTemplateWithSectionKeys)Value!
            : throw new CortiClientException(
                "Union type is not 'documentsTemplateWithSectionKeys'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="CortiApi.DocumentsTemplateWithSections"/> and returns true if successful.
    /// </summary>
    public bool TryGetDocumentsTemplateWithSections(
        out CortiApi.DocumentsTemplateWithSections? value
    )
    {
        if (Type == "documentsTemplateWithSections")
        {
            value = (CortiApi.DocumentsTemplateWithSections)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="CortiApi.DocumentsTemplateWithSectionKeys"/> and returns true if successful.
    /// </summary>
    public bool TryGetDocumentsTemplateWithSectionKeys(
        out CortiApi.DocumentsTemplateWithSectionKeys? value
    )
    {
        if (Type == "documentsTemplateWithSectionKeys")
        {
            value = (CortiApi.DocumentsTemplateWithSectionKeys)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<CortiApi.DocumentsTemplateWithSections, T> onDocumentsTemplateWithSections,
        Func<CortiApi.DocumentsTemplateWithSectionKeys, T> onDocumentsTemplateWithSectionKeys
    )
    {
        return Type switch
        {
            "documentsTemplateWithSections" => onDocumentsTemplateWithSections(
                AsDocumentsTemplateWithSections()
            ),
            "documentsTemplateWithSectionKeys" => onDocumentsTemplateWithSectionKeys(
                AsDocumentsTemplateWithSectionKeys()
            ),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<CortiApi.DocumentsTemplateWithSections> onDocumentsTemplateWithSections,
        Action<CortiApi.DocumentsTemplateWithSectionKeys> onDocumentsTemplateWithSectionKeys
    )
    {
        switch (Type)
        {
            case "documentsTemplateWithSections":
                onDocumentsTemplateWithSections(AsDocumentsTemplateWithSections());
                break;
            case "documentsTemplateWithSectionKeys":
                onDocumentsTemplateWithSectionKeys(AsDocumentsTemplateWithSectionKeys());
                break;
            default:
                throw new CortiClientException($"Unknown union type: {Type}");
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
        if (obj is not DocumentsTemplate other)
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

    public static implicit operator DocumentsTemplate(
        CortiApi.DocumentsTemplateWithSections value
    ) => new("documentsTemplateWithSections", value);

    public static implicit operator DocumentsTemplate(
        CortiApi.DocumentsTemplateWithSectionKeys value
    ) => new("documentsTemplateWithSectionKeys", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<DocumentsTemplate>
    {
        public override DocumentsTemplate? Read(
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
                        "documentsTemplateWithSections",
                        typeof(CortiApi.DocumentsTemplateWithSections)
                    ),
                    (
                        "documentsTemplateWithSectionKeys",
                        typeof(CortiApi.DocumentsTemplateWithSectionKeys)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            DocumentsTemplate result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into DocumentsTemplate"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            DocumentsTemplate value,
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

        public override DocumentsTemplate ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            DocumentsTemplate result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DocumentsTemplate value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
