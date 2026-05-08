// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// Generate a document using a stored template. Optionally supply runtime overrides to patch instructions or sections without mutating the base template.
/// Exactly one of `context` or `interactionId` must be supplied. Supplying both is not currently supported.
/// </summary>
[JsonConverter(typeof(GuidedDocumentByTemplateRef.JsonConverter))]
[Serializable]
public class GuidedDocumentByTemplateRef
{
    private GuidedDocumentByTemplateRef(string type, object? value)
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
    /// Factory method to create a union from a Corti.GuidedDocumentByTemplateRefWithContext value.
    /// </summary>
    public static GuidedDocumentByTemplateRef FromGuidedDocumentByTemplateRefWithContext(
        Corti.GuidedDocumentByTemplateRefWithContext value
    ) => new("guidedDocumentByTemplateRefWithContext", value);

    /// <summary>
    /// Factory method to create a union from a Corti.GuidedDocumentByTemplateRefWithInteractionId value.
    /// </summary>
    public static GuidedDocumentByTemplateRef FromGuidedDocumentByTemplateRefWithInteractionId(
        Corti.GuidedDocumentByTemplateRefWithInteractionId value
    ) => new("guidedDocumentByTemplateRefWithInteractionId", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guidedDocumentByTemplateRefWithContext"
    /// </summary>
    public bool IsGuidedDocumentByTemplateRefWithContext() =>
        Type == "guidedDocumentByTemplateRefWithContext";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guidedDocumentByTemplateRefWithInteractionId"
    /// </summary>
    public bool IsGuidedDocumentByTemplateRefWithInteractionId() =>
        Type == "guidedDocumentByTemplateRefWithInteractionId";

    /// <summary>
    /// Returns the value as a <see cref="Corti.GuidedDocumentByTemplateRefWithContext"/> if <see cref="Type"/> is 'guidedDocumentByTemplateRefWithContext', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'guidedDocumentByTemplateRefWithContext'.</exception>
    public Corti.GuidedDocumentByTemplateRefWithContext AsGuidedDocumentByTemplateRefWithContext() =>
        IsGuidedDocumentByTemplateRefWithContext()
            ? (Corti.GuidedDocumentByTemplateRefWithContext)Value!
            : throw new CortiClientException(
                "Union type is not 'guidedDocumentByTemplateRefWithContext'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Corti.GuidedDocumentByTemplateRefWithInteractionId"/> if <see cref="Type"/> is 'guidedDocumentByTemplateRefWithInteractionId', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'guidedDocumentByTemplateRefWithInteractionId'.</exception>
    public Corti.GuidedDocumentByTemplateRefWithInteractionId AsGuidedDocumentByTemplateRefWithInteractionId() =>
        IsGuidedDocumentByTemplateRefWithInteractionId()
            ? (Corti.GuidedDocumentByTemplateRefWithInteractionId)Value!
            : throw new CortiClientException(
                "Union type is not 'guidedDocumentByTemplateRefWithInteractionId'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.GuidedDocumentByTemplateRefWithContext"/> and returns true if successful.
    /// </summary>
    public bool TryGetGuidedDocumentByTemplateRefWithContext(
        out Corti.GuidedDocumentByTemplateRefWithContext? value
    )
    {
        if (Type == "guidedDocumentByTemplateRefWithContext")
        {
            value = (Corti.GuidedDocumentByTemplateRefWithContext)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.GuidedDocumentByTemplateRefWithInteractionId"/> and returns true if successful.
    /// </summary>
    public bool TryGetGuidedDocumentByTemplateRefWithInteractionId(
        out Corti.GuidedDocumentByTemplateRefWithInteractionId? value
    )
    {
        if (Type == "guidedDocumentByTemplateRefWithInteractionId")
        {
            value = (Corti.GuidedDocumentByTemplateRefWithInteractionId)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Corti.GuidedDocumentByTemplateRefWithContext,
            T
        > onGuidedDocumentByTemplateRefWithContext,
        Func<
            Corti.GuidedDocumentByTemplateRefWithInteractionId,
            T
        > onGuidedDocumentByTemplateRefWithInteractionId
    )
    {
        return Type switch
        {
            "guidedDocumentByTemplateRefWithContext" => onGuidedDocumentByTemplateRefWithContext(
                AsGuidedDocumentByTemplateRefWithContext()
            ),
            "guidedDocumentByTemplateRefWithInteractionId" =>
                onGuidedDocumentByTemplateRefWithInteractionId(
                    AsGuidedDocumentByTemplateRefWithInteractionId()
                ),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Corti.GuidedDocumentByTemplateRefWithContext> onGuidedDocumentByTemplateRefWithContext,
        Action<Corti.GuidedDocumentByTemplateRefWithInteractionId> onGuidedDocumentByTemplateRefWithInteractionId
    )
    {
        switch (Type)
        {
            case "guidedDocumentByTemplateRefWithContext":
                onGuidedDocumentByTemplateRefWithContext(
                    AsGuidedDocumentByTemplateRefWithContext()
                );
                break;
            case "guidedDocumentByTemplateRefWithInteractionId":
                onGuidedDocumentByTemplateRefWithInteractionId(
                    AsGuidedDocumentByTemplateRefWithInteractionId()
                );
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
        if (obj is not GuidedDocumentByTemplateRef other)
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

    public static implicit operator GuidedDocumentByTemplateRef(
        Corti.GuidedDocumentByTemplateRefWithContext value
    ) => new("guidedDocumentByTemplateRefWithContext", value);

    public static implicit operator GuidedDocumentByTemplateRef(
        Corti.GuidedDocumentByTemplateRefWithInteractionId value
    ) => new("guidedDocumentByTemplateRefWithInteractionId", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<GuidedDocumentByTemplateRef>
    {
        public override GuidedDocumentByTemplateRef? Read(
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
                        "guidedDocumentByTemplateRefWithContext",
                        typeof(Corti.GuidedDocumentByTemplateRefWithContext)
                    ),
                    (
                        "guidedDocumentByTemplateRefWithInteractionId",
                        typeof(Corti.GuidedDocumentByTemplateRefWithInteractionId)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            GuidedDocumentByTemplateRef result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into GuidedDocumentByTemplateRef"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            GuidedDocumentByTemplateRef value,
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

        public override GuidedDocumentByTemplateRef ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            GuidedDocumentByTemplateRef result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GuidedDocumentByTemplateRef value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
