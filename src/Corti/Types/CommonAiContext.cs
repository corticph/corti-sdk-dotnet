// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(CommonAiContext.JsonConverter))]
[Serializable]
public class CommonAiContext
{
    private CommonAiContext(string type, object? value)
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
    public static CommonAiContext FromCommonTextContext(Corti.CommonTextContext value) =>
        new("commonTextContext", value);

    /// <summary>
    /// Factory method to create a union from a Corti.CommonDocumentIdContext value.
    /// </summary>
    public static CommonAiContext FromCommonDocumentIdContext(
        Corti.CommonDocumentIdContext value
    ) => new("commonDocumentIdContext", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "commonTextContext"
    /// </summary>
    public bool IsCommonTextContext() => Type == "commonTextContext";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "commonDocumentIdContext"
    /// </summary>
    public bool IsCommonDocumentIdContext() => Type == "commonDocumentIdContext";

    /// <summary>
    /// Returns the value as a <see cref="Corti.CommonTextContext"/> if <see cref="Type"/> is 'commonTextContext', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'commonTextContext'.</exception>
    public Corti.CommonTextContext AsCommonTextContext() =>
        IsCommonTextContext()
            ? (Corti.CommonTextContext)Value!
            : throw new CortiClientException("Union type is not 'commonTextContext'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.CommonDocumentIdContext"/> if <see cref="Type"/> is 'commonDocumentIdContext', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'commonDocumentIdContext'.</exception>
    public Corti.CommonDocumentIdContext AsCommonDocumentIdContext() =>
        IsCommonDocumentIdContext()
            ? (Corti.CommonDocumentIdContext)Value!
            : throw new CortiClientException("Union type is not 'commonDocumentIdContext'");

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
    /// Attempts to cast the value to a <see cref="Corti.CommonDocumentIdContext"/> and returns true if successful.
    /// </summary>
    public bool TryGetCommonDocumentIdContext(out Corti.CommonDocumentIdContext? value)
    {
        if (Type == "commonDocumentIdContext")
        {
            value = (Corti.CommonDocumentIdContext)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Corti.CommonTextContext, T> onCommonTextContext,
        Func<Corti.CommonDocumentIdContext, T> onCommonDocumentIdContext
    )
    {
        return Type switch
        {
            "commonTextContext" => onCommonTextContext(AsCommonTextContext()),
            "commonDocumentIdContext" => onCommonDocumentIdContext(AsCommonDocumentIdContext()),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Corti.CommonTextContext> onCommonTextContext,
        Action<Corti.CommonDocumentIdContext> onCommonDocumentIdContext
    )
    {
        switch (Type)
        {
            case "commonTextContext":
                onCommonTextContext(AsCommonTextContext());
                break;
            case "commonDocumentIdContext":
                onCommonDocumentIdContext(AsCommonDocumentIdContext());
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
        if (obj is not CommonAiContext other)
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

    public static implicit operator CommonAiContext(Corti.CommonTextContext value) =>
        new("commonTextContext", value);

    public static implicit operator CommonAiContext(Corti.CommonDocumentIdContext value) =>
        new("commonDocumentIdContext", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CommonAiContext>
    {
        public override CommonAiContext? Read(
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
                    ("commonTextContext", typeof(Corti.CommonTextContext)),
                    ("commonDocumentIdContext", typeof(Corti.CommonDocumentIdContext)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            CommonAiContext result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into CommonAiContext"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CommonAiContext value,
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

        public override CommonAiContext ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CommonAiContext result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CommonAiContext value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
