// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

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
    /// Factory method to create a union from a CortiApi.DocumentsContextWithFacts value.
    /// </summary>
    public static DocumentsContext FromDocumentsContextWithFacts(
        CortiApi.DocumentsContextWithFacts value
    ) => new("documentsContextWithFacts", value);

    /// <summary>
    /// Factory method to create a union from a CortiApi.DocumentsContextWithTranscript value.
    /// </summary>
    public static DocumentsContext FromDocumentsContextWithTranscript(
        CortiApi.DocumentsContextWithTranscript value
    ) => new("documentsContextWithTranscript", value);

    /// <summary>
    /// Factory method to create a union from a CortiApi.DocumentsContextWithString value.
    /// </summary>
    public static DocumentsContext FromDocumentsContextWithString(
        CortiApi.DocumentsContextWithString value
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
    /// Returns the value as a <see cref="CortiApi.DocumentsContextWithFacts"/> if <see cref="Type"/> is 'documentsContextWithFacts', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'documentsContextWithFacts'.</exception>
    public CortiApi.DocumentsContextWithFacts AsDocumentsContextWithFacts() =>
        IsDocumentsContextWithFacts()
            ? (CortiApi.DocumentsContextWithFacts)Value!
            : throw new CortiClientException("Union type is not 'documentsContextWithFacts'");

    /// <summary>
    /// Returns the value as a <see cref="CortiApi.DocumentsContextWithTranscript"/> if <see cref="Type"/> is 'documentsContextWithTranscript', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'documentsContextWithTranscript'.</exception>
    public CortiApi.DocumentsContextWithTranscript AsDocumentsContextWithTranscript() =>
        IsDocumentsContextWithTranscript()
            ? (CortiApi.DocumentsContextWithTranscript)Value!
            : throw new CortiClientException("Union type is not 'documentsContextWithTranscript'");

    /// <summary>
    /// Returns the value as a <see cref="CortiApi.DocumentsContextWithString"/> if <see cref="Type"/> is 'documentsContextWithString', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'documentsContextWithString'.</exception>
    public CortiApi.DocumentsContextWithString AsDocumentsContextWithString() =>
        IsDocumentsContextWithString()
            ? (CortiApi.DocumentsContextWithString)Value!
            : throw new CortiClientException("Union type is not 'documentsContextWithString'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="CortiApi.DocumentsContextWithFacts"/> and returns true if successful.
    /// </summary>
    public bool TryGetDocumentsContextWithFacts(out CortiApi.DocumentsContextWithFacts? value)
    {
        if (Type == "documentsContextWithFacts")
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
    public bool TryGetDocumentsContextWithTranscript(
        out CortiApi.DocumentsContextWithTranscript? value
    )
    {
        if (Type == "documentsContextWithTranscript")
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
    public bool TryGetDocumentsContextWithString(out CortiApi.DocumentsContextWithString? value)
    {
        if (Type == "documentsContextWithString")
        {
            value = (CortiApi.DocumentsContextWithString)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<CortiApi.DocumentsContextWithFacts, T> onDocumentsContextWithFacts,
        Func<CortiApi.DocumentsContextWithTranscript, T> onDocumentsContextWithTranscript,
        Func<CortiApi.DocumentsContextWithString, T> onDocumentsContextWithString
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
        Action<CortiApi.DocumentsContextWithFacts> onDocumentsContextWithFacts,
        Action<CortiApi.DocumentsContextWithTranscript> onDocumentsContextWithTranscript,
        Action<CortiApi.DocumentsContextWithString> onDocumentsContextWithString
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

    public static implicit operator DocumentsContext(CortiApi.DocumentsContextWithFacts value) =>
        new("documentsContextWithFacts", value);

    public static implicit operator DocumentsContext(
        CortiApi.DocumentsContextWithTranscript value
    ) => new("documentsContextWithTranscript", value);

    public static implicit operator DocumentsContext(CortiApi.DocumentsContextWithString value) =>
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
                    ("documentsContextWithFacts", typeof(CortiApi.DocumentsContextWithFacts)),
                    (
                        "documentsContextWithTranscript",
                        typeof(CortiApi.DocumentsContextWithTranscript)
                    ),
                    ("documentsContextWithString", typeof(CortiApi.DocumentsContextWithString)),
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
