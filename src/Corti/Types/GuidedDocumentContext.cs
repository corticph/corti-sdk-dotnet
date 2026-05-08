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
    /// Factory method to create a union from a Corti.GuidedDocumentContextText value.
    /// </summary>
    public static GuidedDocumentContext FromGuidedDocumentContextText(
        Corti.GuidedDocumentContextText value
    ) => new("guidedDocumentContextText", value);

    /// <summary>
    /// Factory method to create a union from a Corti.GuidedDocumentContextTranscript value.
    /// </summary>
    public static GuidedDocumentContext FromGuidedDocumentContextTranscript(
        Corti.GuidedDocumentContextTranscript value
    ) => new("guidedDocumentContextTranscript", value);

    /// <summary>
    /// Factory method to create a union from a Corti.GuidedDocumentContextFacts value.
    /// </summary>
    public static GuidedDocumentContext FromGuidedDocumentContextFacts(
        Corti.GuidedDocumentContextFacts value
    ) => new("guidedDocumentContextFacts", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guidedDocumentContextText"
    /// </summary>
    public bool IsGuidedDocumentContextText() => Type == "guidedDocumentContextText";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guidedDocumentContextTranscript"
    /// </summary>
    public bool IsGuidedDocumentContextTranscript() => Type == "guidedDocumentContextTranscript";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guidedDocumentContextFacts"
    /// </summary>
    public bool IsGuidedDocumentContextFacts() => Type == "guidedDocumentContextFacts";

    /// <summary>
    /// Returns the value as a <see cref="Corti.GuidedDocumentContextText"/> if <see cref="Type"/> is 'guidedDocumentContextText', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'guidedDocumentContextText'.</exception>
    public Corti.GuidedDocumentContextText AsGuidedDocumentContextText() =>
        IsGuidedDocumentContextText()
            ? (Corti.GuidedDocumentContextText)Value!
            : throw new CortiClientException("Union type is not 'guidedDocumentContextText'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.GuidedDocumentContextTranscript"/> if <see cref="Type"/> is 'guidedDocumentContextTranscript', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'guidedDocumentContextTranscript'.</exception>
    public Corti.GuidedDocumentContextTranscript AsGuidedDocumentContextTranscript() =>
        IsGuidedDocumentContextTranscript()
            ? (Corti.GuidedDocumentContextTranscript)Value!
            : throw new CortiClientException("Union type is not 'guidedDocumentContextTranscript'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.GuidedDocumentContextFacts"/> if <see cref="Type"/> is 'guidedDocumentContextFacts', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'guidedDocumentContextFacts'.</exception>
    public Corti.GuidedDocumentContextFacts AsGuidedDocumentContextFacts() =>
        IsGuidedDocumentContextFacts()
            ? (Corti.GuidedDocumentContextFacts)Value!
            : throw new CortiClientException("Union type is not 'guidedDocumentContextFacts'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.GuidedDocumentContextText"/> and returns true if successful.
    /// </summary>
    public bool TryGetGuidedDocumentContextText(out Corti.GuidedDocumentContextText? value)
    {
        if (Type == "guidedDocumentContextText")
        {
            value = (Corti.GuidedDocumentContextText)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.GuidedDocumentContextTranscript"/> and returns true if successful.
    /// </summary>
    public bool TryGetGuidedDocumentContextTranscript(
        out Corti.GuidedDocumentContextTranscript? value
    )
    {
        if (Type == "guidedDocumentContextTranscript")
        {
            value = (Corti.GuidedDocumentContextTranscript)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.GuidedDocumentContextFacts"/> and returns true if successful.
    /// </summary>
    public bool TryGetGuidedDocumentContextFacts(out Corti.GuidedDocumentContextFacts? value)
    {
        if (Type == "guidedDocumentContextFacts")
        {
            value = (Corti.GuidedDocumentContextFacts)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Corti.GuidedDocumentContextText, T> onGuidedDocumentContextText,
        Func<Corti.GuidedDocumentContextTranscript, T> onGuidedDocumentContextTranscript,
        Func<Corti.GuidedDocumentContextFacts, T> onGuidedDocumentContextFacts
    )
    {
        return Type switch
        {
            "guidedDocumentContextText" => onGuidedDocumentContextText(
                AsGuidedDocumentContextText()
            ),
            "guidedDocumentContextTranscript" => onGuidedDocumentContextTranscript(
                AsGuidedDocumentContextTranscript()
            ),
            "guidedDocumentContextFacts" => onGuidedDocumentContextFacts(
                AsGuidedDocumentContextFacts()
            ),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Corti.GuidedDocumentContextText> onGuidedDocumentContextText,
        Action<Corti.GuidedDocumentContextTranscript> onGuidedDocumentContextTranscript,
        Action<Corti.GuidedDocumentContextFacts> onGuidedDocumentContextFacts
    )
    {
        switch (Type)
        {
            case "guidedDocumentContextText":
                onGuidedDocumentContextText(AsGuidedDocumentContextText());
                break;
            case "guidedDocumentContextTranscript":
                onGuidedDocumentContextTranscript(AsGuidedDocumentContextTranscript());
                break;
            case "guidedDocumentContextFacts":
                onGuidedDocumentContextFacts(AsGuidedDocumentContextFacts());
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

    public static implicit operator GuidedDocumentContext(Corti.GuidedDocumentContextText value) =>
        new("guidedDocumentContextText", value);

    public static implicit operator GuidedDocumentContext(
        Corti.GuidedDocumentContextTranscript value
    ) => new("guidedDocumentContextTranscript", value);

    public static implicit operator GuidedDocumentContext(Corti.GuidedDocumentContextFacts value) =>
        new("guidedDocumentContextFacts", value);

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
                    ("guidedDocumentContextText", typeof(Corti.GuidedDocumentContextText)),
                    (
                        "guidedDocumentContextTranscript",
                        typeof(Corti.GuidedDocumentContextTranscript)
                    ),
                    ("guidedDocumentContextFacts", typeof(Corti.GuidedDocumentContextFacts)),
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
