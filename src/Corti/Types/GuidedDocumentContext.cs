// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

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
    /// Factory method to create a union from a Corti.CommonTextContext value.
    /// </summary>
    public static GuidedDocumentContext FromCommonTextContext(Corti.CommonTextContext value) =>
        new("commonTextContext", value);

    /// <summary>
    /// Factory method to create a union from a Corti.CommonTranscriptContext value.
    /// </summary>
    public static GuidedDocumentContext FromCommonTranscriptContext(
        Corti.CommonTranscriptContext value
    ) => new("commonTranscriptContext", value);

    /// <summary>
    /// Factory method to create a union from a Corti.CommonFactsContext value.
    /// </summary>
    public static GuidedDocumentContext FromCommonFactsContext(Corti.CommonFactsContext value) =>
        new("commonFactsContext", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "commonTextContext"
    /// </summary>
    public bool IsCommonTextContext() => Type == "commonTextContext";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "commonTranscriptContext"
    /// </summary>
    public bool IsCommonTranscriptContext() => Type == "commonTranscriptContext";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "commonFactsContext"
    /// </summary>
    public bool IsCommonFactsContext() => Type == "commonFactsContext";

    /// <summary>
    /// Returns the value as a <see cref="Corti.CommonTextContext"/> if <see cref="Type"/> is 'commonTextContext', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'commonTextContext'.</exception>
    public Corti.CommonTextContext AsCommonTextContext() =>
        IsCommonTextContext()
            ? (Corti.CommonTextContext)Value!
            : throw new CortiClientException("Union type is not 'commonTextContext'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.CommonTranscriptContext"/> if <see cref="Type"/> is 'commonTranscriptContext', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'commonTranscriptContext'.</exception>
    public Corti.CommonTranscriptContext AsCommonTranscriptContext() =>
        IsCommonTranscriptContext()
            ? (Corti.CommonTranscriptContext)Value!
            : throw new CortiClientException("Union type is not 'commonTranscriptContext'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.CommonFactsContext"/> if <see cref="Type"/> is 'commonFactsContext', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'commonFactsContext'.</exception>
    public Corti.CommonFactsContext AsCommonFactsContext() =>
        IsCommonFactsContext()
            ? (Corti.CommonFactsContext)Value!
            : throw new CortiClientException("Union type is not 'commonFactsContext'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.CommonTextContext"/> and returns true if successful.
    /// </summary>
    public bool TryGetCommonTextContext(out Corti.CommonTextContext? value)
    {
        if (Type == "commonTextContext")
        {
            value = (Corti.CommonTextContext)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.CommonTranscriptContext"/> and returns true if successful.
    /// </summary>
    public bool TryGetCommonTranscriptContext(out Corti.CommonTranscriptContext? value)
    {
        if (Type == "commonTranscriptContext")
        {
            value = (Corti.CommonTranscriptContext)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.CommonFactsContext"/> and returns true if successful.
    /// </summary>
    public bool TryGetCommonFactsContext(out Corti.CommonFactsContext? value)
    {
        if (Type == "commonFactsContext")
        {
            value = (Corti.CommonFactsContext)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Corti.CommonTextContext, T> onCommonTextContext,
        Func<Corti.CommonTranscriptContext, T> onCommonTranscriptContext,
        Func<Corti.CommonFactsContext, T> onCommonFactsContext
    )
    {
        return Type switch
        {
            "commonTextContext" => onCommonTextContext(AsCommonTextContext()),
            "commonTranscriptContext" => onCommonTranscriptContext(AsCommonTranscriptContext()),
            "commonFactsContext" => onCommonFactsContext(AsCommonFactsContext()),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Corti.CommonTextContext> onCommonTextContext,
        Action<Corti.CommonTranscriptContext> onCommonTranscriptContext,
        Action<Corti.CommonFactsContext> onCommonFactsContext
    )
    {
        switch (Type)
        {
            case "commonTextContext":
                onCommonTextContext(AsCommonTextContext());
                break;
            case "commonTranscriptContext":
                onCommonTranscriptContext(AsCommonTranscriptContext());
                break;
            case "commonFactsContext":
                onCommonFactsContext(AsCommonFactsContext());
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

    public static implicit operator GuidedDocumentContext(Corti.CommonTextContext value) =>
        new("commonTextContext", value);

    public static implicit operator GuidedDocumentContext(Corti.CommonTranscriptContext value) =>
        new("commonTranscriptContext", value);

    public static implicit operator GuidedDocumentContext(Corti.CommonFactsContext value) =>
        new("commonFactsContext", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<GuidedDocumentContext>
    {
        public override GuidedDocumentContext? Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
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
                    ("commonTextContext", typeof(Corti.CommonTextContext)),
                    ("commonTranscriptContext", typeof(Corti.CommonTranscriptContext)),
                    ("commonFactsContext", typeof(Corti.CommonFactsContext)),
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
            global::System.Type typeToConvert,
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
