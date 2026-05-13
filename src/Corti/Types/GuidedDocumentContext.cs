// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(GuidedDocumentContext.JsonConverter))]
[Serializable]
public class GuidedDocumentContext
{
    private GuidedDocumentContext(string type, object? value)
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
    /// Factory method to create a union from a Corti.ContextText value.
    /// </summary>
    public static GuidedDocumentContext FromContextText(Corti.ContextText value) =>
        new("contextText", value);

    /// <summary>
    /// Factory method to create a union from a Corti.ContextTranscript value.
    /// </summary>
    public static GuidedDocumentContext FromContextTranscript(Corti.ContextTranscript value) =>
        new("contextTranscript", value);

    /// <summary>
    /// Factory method to create a union from a Corti.ContextFacts value.
    /// </summary>
    public static GuidedDocumentContext FromContextFacts(Corti.ContextFacts value) =>
        new("contextFacts", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "contextText"
    /// </summary>
    public bool IsContextText() => Type == "contextText";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "contextTranscript"
    /// </summary>
    public bool IsContextTranscript() => Type == "contextTranscript";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "contextFacts"
    /// </summary>
    public bool IsContextFacts() => Type == "contextFacts";

    /// <summary>
    /// Returns the value as a <see cref="Corti.ContextText"/> if <see cref="Type"/> is 'contextText', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'contextText'.</exception>
    public Corti.ContextText AsContextText() =>
        IsContextText()
            ? (Corti.ContextText)Value!
            : throw new CortiClientException("Union type is not 'contextText'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.ContextTranscript"/> if <see cref="Type"/> is 'contextTranscript', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'contextTranscript'.</exception>
    public Corti.ContextTranscript AsContextTranscript() =>
        IsContextTranscript()
            ? (Corti.ContextTranscript)Value!
            : throw new CortiClientException("Union type is not 'contextTranscript'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.ContextFacts"/> if <see cref="Type"/> is 'contextFacts', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'contextFacts'.</exception>
    public Corti.ContextFacts AsContextFacts() =>
        IsContextFacts()
            ? (Corti.ContextFacts)Value!
            : throw new CortiClientException("Union type is not 'contextFacts'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.ContextText"/> and returns true if successful.
    /// </summary>
    public bool TryGetContextText(out Corti.ContextText? value)
    {
        if (Type == "contextText")
        {
            value = (Corti.ContextText)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.ContextTranscript"/> and returns true if successful.
    /// </summary>
    public bool TryGetContextTranscript(out Corti.ContextTranscript? value)
    {
        if (Type == "contextTranscript")
        {
            value = (Corti.ContextTranscript)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.ContextFacts"/> and returns true if successful.
    /// </summary>
    public bool TryGetContextFacts(out Corti.ContextFacts? value)
    {
        if (Type == "contextFacts")
        {
            value = (Corti.ContextFacts)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Corti.ContextText, T> onContextText,
        Func<Corti.ContextTranscript, T> onContextTranscript,
        Func<Corti.ContextFacts, T> onContextFacts
    )
    {
        return Type switch
        {
            "contextText" => onContextText(AsContextText()),
            "contextTranscript" => onContextTranscript(AsContextTranscript()),
            "contextFacts" => onContextFacts(AsContextFacts()),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Corti.ContextText> onContextText,
        Action<Corti.ContextTranscript> onContextTranscript,
        Action<Corti.ContextFacts> onContextFacts
    )
    {
        switch (Type)
        {
            case "contextText":
                onContextText(AsContextText());
                break;
            case "contextTranscript":
                onContextTranscript(AsContextTranscript());
                break;
            case "contextFacts":
                onContextFacts(AsContextFacts());
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
        if (obj is not GuidedDocumentContext other)
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

    public static implicit operator GuidedDocumentContext(Corti.ContextText value) =>
        new("contextText", value);

    public static implicit operator GuidedDocumentContext(Corti.ContextTranscript value) =>
        new("contextTranscript", value);

    public static implicit operator GuidedDocumentContext(Corti.ContextFacts value) =>
        new("contextFacts", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<GuidedDocumentContext>
    {
        public override GuidedDocumentContext? Read(
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
                    ("contextText", typeof(Corti.ContextText)),
                    ("contextTranscript", typeof(Corti.ContextTranscript)),
                    ("contextFacts", typeof(Corti.ContextFacts)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            GuidedDocumentContext result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into GuidedDocumentContext"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            GuidedDocumentContext value,
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

        public override GuidedDocumentContext ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            GuidedDocumentContext result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GuidedDocumentContext value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
