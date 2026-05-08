// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// Generate a document from a fully inline template definition supplied in the request body. Sections and the wrapping template are created and immediately published as auto-generated resources.
/// Exactly one of `context` or `interactionId` must be supplied — supplying both is not currently supported.
/// </summary>
[JsonConverter(typeof(GuidedDocumentByDynamic.JsonConverter))]
[Serializable]
public class GuidedDocumentByDynamic
{
    private GuidedDocumentByDynamic(string type, object? value)
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
    /// Factory method to create a union from a Corti.GuidedDocumentByDynamicWithContext value.
    /// </summary>
    public static GuidedDocumentByDynamic FromGuidedDocumentByDynamicWithContext(
        Corti.GuidedDocumentByDynamicWithContext value
    ) => new("guidedDocumentByDynamicWithContext", value);

    /// <summary>
    /// Factory method to create a union from a Corti.GuidedDocumentByDynamicWithInteractionId value.
    /// </summary>
    public static GuidedDocumentByDynamic FromGuidedDocumentByDynamicWithInteractionId(
        Corti.GuidedDocumentByDynamicWithInteractionId value
    ) => new("guidedDocumentByDynamicWithInteractionId", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guidedDocumentByDynamicWithContext"
    /// </summary>
    public bool IsGuidedDocumentByDynamicWithContext() =>
        Type == "guidedDocumentByDynamicWithContext";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guidedDocumentByDynamicWithInteractionId"
    /// </summary>
    public bool IsGuidedDocumentByDynamicWithInteractionId() =>
        Type == "guidedDocumentByDynamicWithInteractionId";

    /// <summary>
    /// Returns the value as a <see cref="Corti.GuidedDocumentByDynamicWithContext"/> if <see cref="Type"/> is 'guidedDocumentByDynamicWithContext', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'guidedDocumentByDynamicWithContext'.</exception>
    public Corti.GuidedDocumentByDynamicWithContext AsGuidedDocumentByDynamicWithContext() =>
        IsGuidedDocumentByDynamicWithContext()
            ? (Corti.GuidedDocumentByDynamicWithContext)Value!
            : throw new CortiClientException(
                "Union type is not 'guidedDocumentByDynamicWithContext'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Corti.GuidedDocumentByDynamicWithInteractionId"/> if <see cref="Type"/> is 'guidedDocumentByDynamicWithInteractionId', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'guidedDocumentByDynamicWithInteractionId'.</exception>
    public Corti.GuidedDocumentByDynamicWithInteractionId AsGuidedDocumentByDynamicWithInteractionId() =>
        IsGuidedDocumentByDynamicWithInteractionId()
            ? (Corti.GuidedDocumentByDynamicWithInteractionId)Value!
            : throw new CortiClientException(
                "Union type is not 'guidedDocumentByDynamicWithInteractionId'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.GuidedDocumentByDynamicWithContext"/> and returns true if successful.
    /// </summary>
    public bool TryGetGuidedDocumentByDynamicWithContext(
        out Corti.GuidedDocumentByDynamicWithContext? value
    )
    {
        if (Type == "guidedDocumentByDynamicWithContext")
        {
            value = (Corti.GuidedDocumentByDynamicWithContext)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.GuidedDocumentByDynamicWithInteractionId"/> and returns true if successful.
    /// </summary>
    public bool TryGetGuidedDocumentByDynamicWithInteractionId(
        out Corti.GuidedDocumentByDynamicWithInteractionId? value
    )
    {
        if (Type == "guidedDocumentByDynamicWithInteractionId")
        {
            value = (Corti.GuidedDocumentByDynamicWithInteractionId)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Corti.GuidedDocumentByDynamicWithContext, T> onGuidedDocumentByDynamicWithContext,
        Func<
            Corti.GuidedDocumentByDynamicWithInteractionId,
            T
        > onGuidedDocumentByDynamicWithInteractionId
    )
    {
        return Type switch
        {
            "guidedDocumentByDynamicWithContext" => onGuidedDocumentByDynamicWithContext(
                AsGuidedDocumentByDynamicWithContext()
            ),
            "guidedDocumentByDynamicWithInteractionId" =>
                onGuidedDocumentByDynamicWithInteractionId(
                    AsGuidedDocumentByDynamicWithInteractionId()
                ),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Corti.GuidedDocumentByDynamicWithContext> onGuidedDocumentByDynamicWithContext,
        Action<Corti.GuidedDocumentByDynamicWithInteractionId> onGuidedDocumentByDynamicWithInteractionId
    )
    {
        switch (Type)
        {
            case "guidedDocumentByDynamicWithContext":
                onGuidedDocumentByDynamicWithContext(AsGuidedDocumentByDynamicWithContext());
                break;
            case "guidedDocumentByDynamicWithInteractionId":
                onGuidedDocumentByDynamicWithInteractionId(
                    AsGuidedDocumentByDynamicWithInteractionId()
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
        if (obj is not GuidedDocumentByDynamic other)
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

    public static implicit operator GuidedDocumentByDynamic(
        Corti.GuidedDocumentByDynamicWithContext value
    ) => new("guidedDocumentByDynamicWithContext", value);

    public static implicit operator GuidedDocumentByDynamic(
        Corti.GuidedDocumentByDynamicWithInteractionId value
    ) => new("guidedDocumentByDynamicWithInteractionId", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<GuidedDocumentByDynamic>
    {
        public override GuidedDocumentByDynamic? Read(
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
                        "guidedDocumentByDynamicWithContext",
                        typeof(Corti.GuidedDocumentByDynamicWithContext)
                    ),
                    (
                        "guidedDocumentByDynamicWithInteractionId",
                        typeof(Corti.GuidedDocumentByDynamicWithInteractionId)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            GuidedDocumentByDynamic result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into GuidedDocumentByDynamic"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            GuidedDocumentByDynamic value,
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

        public override GuidedDocumentByDynamic ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            GuidedDocumentByDynamic result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GuidedDocumentByDynamic value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
