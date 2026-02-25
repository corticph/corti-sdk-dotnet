// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(DocumentsContext.JsonConverter))]
[Serializable]
public class DocumentsContext
{
    private DocumentsContext(string type, object? value)
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
    /// Factory method to create a union from a Corti.DocumentsContextWithFacts value.
    /// </summary>
    public static DocumentsContext FromDocumentsContextWithFacts(
        Corti.DocumentsContextWithFacts value
    ) => new("documentsContextWithFacts", value);

    /// <summary>
    /// Factory method to create a union from a Corti.DocumentsContextWithTranscript value.
    /// </summary>
    public static DocumentsContext FromDocumentsContextWithTranscript(
        Corti.DocumentsContextWithTranscript value
    ) => new("documentsContextWithTranscript", value);

    /// <summary>
    /// Factory method to create a union from a Corti.DocumentsContextWithString value.
    /// </summary>
    public static DocumentsContext FromDocumentsContextWithString(
        Corti.DocumentsContextWithString value
    ) => new("documentsContextWithString", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "documentsContextWithFacts"
    /// </summary>
    public bool IsDocumentsContextWithFacts() => Type == "documentsContextWithFacts";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "documentsContextWithTranscript"
    /// </summary>
    public bool IsDocumentsContextWithTranscript() => Type == "documentsContextWithTranscript";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "documentsContextWithString"
    /// </summary>
    public bool IsDocumentsContextWithString() => Type == "documentsContextWithString";

    /// <summary>
    /// Returns the value as a <see cref="Corti.DocumentsContextWithFacts"/> if <see cref="Type"/> is 'documentsContextWithFacts', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'documentsContextWithFacts'.</exception>
    public Corti.DocumentsContextWithFacts AsDocumentsContextWithFacts() =>
        IsDocumentsContextWithFacts()
            ? (Corti.DocumentsContextWithFacts)Value!
            : throw new CortiClientException("Union type is not 'documentsContextWithFacts'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.DocumentsContextWithTranscript"/> if <see cref="Type"/> is 'documentsContextWithTranscript', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'documentsContextWithTranscript'.</exception>
    public Corti.DocumentsContextWithTranscript AsDocumentsContextWithTranscript() =>
        IsDocumentsContextWithTranscript()
            ? (Corti.DocumentsContextWithTranscript)Value!
            : throw new CortiClientException("Union type is not 'documentsContextWithTranscript'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.DocumentsContextWithString"/> if <see cref="Type"/> is 'documentsContextWithString', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'documentsContextWithString'.</exception>
    public Corti.DocumentsContextWithString AsDocumentsContextWithString() =>
        IsDocumentsContextWithString()
            ? (Corti.DocumentsContextWithString)Value!
            : throw new CortiClientException("Union type is not 'documentsContextWithString'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.DocumentsContextWithFacts"/> and returns true if successful.
    /// </summary>
    public bool TryGetDocumentsContextWithFacts(out Corti.DocumentsContextWithFacts? value)
    {
        if (Type == "documentsContextWithFacts")
        {
            value = (Corti.DocumentsContextWithFacts)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.DocumentsContextWithTranscript"/> and returns true if successful.
    /// </summary>
    public bool TryGetDocumentsContextWithTranscript(
        out Corti.DocumentsContextWithTranscript? value
    )
    {
        if (Type == "documentsContextWithTranscript")
        {
            value = (Corti.DocumentsContextWithTranscript)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.DocumentsContextWithString"/> and returns true if successful.
    /// </summary>
    public bool TryGetDocumentsContextWithString(out Corti.DocumentsContextWithString? value)
    {
        if (Type == "documentsContextWithString")
        {
            value = (Corti.DocumentsContextWithString)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Corti.DocumentsContextWithFacts, T> onDocumentsContextWithFacts,
        Func<Corti.DocumentsContextWithTranscript, T> onDocumentsContextWithTranscript,
        Func<Corti.DocumentsContextWithString, T> onDocumentsContextWithString
    )
    {
        return Type switch
        {
            "documentsContextWithFacts" => onDocumentsContextWithFacts(
                AsDocumentsContextWithFacts()
            ),
            "documentsContextWithTranscript" => onDocumentsContextWithTranscript(
                AsDocumentsContextWithTranscript()
            ),
            "documentsContextWithString" => onDocumentsContextWithString(
                AsDocumentsContextWithString()
            ),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Corti.DocumentsContextWithFacts> onDocumentsContextWithFacts,
        Action<Corti.DocumentsContextWithTranscript> onDocumentsContextWithTranscript,
        Action<Corti.DocumentsContextWithString> onDocumentsContextWithString
    )
    {
        switch (Type)
        {
            case "documentsContextWithFacts":
                onDocumentsContextWithFacts(AsDocumentsContextWithFacts());
                break;
            case "documentsContextWithTranscript":
                onDocumentsContextWithTranscript(AsDocumentsContextWithTranscript());
                break;
            case "documentsContextWithString":
                onDocumentsContextWithString(AsDocumentsContextWithString());
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
        if (obj is not DocumentsContext other)
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

    public static implicit operator DocumentsContext(Corti.DocumentsContextWithFacts value) =>
        new("documentsContextWithFacts", value);

    public static implicit operator DocumentsContext(Corti.DocumentsContextWithTranscript value) =>
        new("documentsContextWithTranscript", value);

    public static implicit operator DocumentsContext(Corti.DocumentsContextWithString value) =>
        new("documentsContextWithString", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<DocumentsContext>
    {
        public override DocumentsContext? Read(
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
                    ("documentsContextWithFacts", typeof(Corti.DocumentsContextWithFacts)),
                    (
                        "documentsContextWithTranscript",
                        typeof(Corti.DocumentsContextWithTranscript)
                    ),
                    ("documentsContextWithString", typeof(Corti.DocumentsContextWithString)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            DocumentsContext result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into DocumentsContext"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            DocumentsContext value,
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
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override DocumentsContext ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            DocumentsContext result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DocumentsContext value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
