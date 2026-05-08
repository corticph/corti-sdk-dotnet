// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// Generate a document by assembling a template from existing stored sections. The resulting template aggregate is auto-saved and can be referenced in future calls.
/// Exactly one of `context` or `interactionId` must be supplied. supplying both is not currently supported.
/// </summary>
[JsonConverter(typeof(GuidedDocumentByAssembly.JsonConverter))]
[Serializable]
public class GuidedDocumentByAssembly
{
    private GuidedDocumentByAssembly(string type, object? value)
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
    /// Factory method to create a union from a Corti.GuidedDocumentByAssemblyWithContext value.
    /// </summary>
    public static GuidedDocumentByAssembly FromGuidedDocumentByAssemblyWithContext(
        Corti.GuidedDocumentByAssemblyWithContext value
    ) => new("guidedDocumentByAssemblyWithContext", value);

    /// <summary>
    /// Factory method to create a union from a Corti.GuidedDocumentByAssemblyWithInteractionId value.
    /// </summary>
    public static GuidedDocumentByAssembly FromGuidedDocumentByAssemblyWithInteractionId(
        Corti.GuidedDocumentByAssemblyWithInteractionId value
    ) => new("guidedDocumentByAssemblyWithInteractionId", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guidedDocumentByAssemblyWithContext"
    /// </summary>
    public bool IsGuidedDocumentByAssemblyWithContext() =>
        Type == "guidedDocumentByAssemblyWithContext";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guidedDocumentByAssemblyWithInteractionId"
    /// </summary>
    public bool IsGuidedDocumentByAssemblyWithInteractionId() =>
        Type == "guidedDocumentByAssemblyWithInteractionId";

    /// <summary>
    /// Returns the value as a <see cref="Corti.GuidedDocumentByAssemblyWithContext"/> if <see cref="Type"/> is 'guidedDocumentByAssemblyWithContext', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'guidedDocumentByAssemblyWithContext'.</exception>
    public Corti.GuidedDocumentByAssemblyWithContext AsGuidedDocumentByAssemblyWithContext() =>
        IsGuidedDocumentByAssemblyWithContext()
            ? (Corti.GuidedDocumentByAssemblyWithContext)Value!
            : throw new CortiClientException(
                "Union type is not 'guidedDocumentByAssemblyWithContext'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Corti.GuidedDocumentByAssemblyWithInteractionId"/> if <see cref="Type"/> is 'guidedDocumentByAssemblyWithInteractionId', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'guidedDocumentByAssemblyWithInteractionId'.</exception>
    public Corti.GuidedDocumentByAssemblyWithInteractionId AsGuidedDocumentByAssemblyWithInteractionId() =>
        IsGuidedDocumentByAssemblyWithInteractionId()
            ? (Corti.GuidedDocumentByAssemblyWithInteractionId)Value!
            : throw new CortiClientException(
                "Union type is not 'guidedDocumentByAssemblyWithInteractionId'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.GuidedDocumentByAssemblyWithContext"/> and returns true if successful.
    /// </summary>
    public bool TryGetGuidedDocumentByAssemblyWithContext(
        out Corti.GuidedDocumentByAssemblyWithContext? value
    )
    {
        if (Type == "guidedDocumentByAssemblyWithContext")
        {
            value = (Corti.GuidedDocumentByAssemblyWithContext)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.GuidedDocumentByAssemblyWithInteractionId"/> and returns true if successful.
    /// </summary>
    public bool TryGetGuidedDocumentByAssemblyWithInteractionId(
        out Corti.GuidedDocumentByAssemblyWithInteractionId? value
    )
    {
        if (Type == "guidedDocumentByAssemblyWithInteractionId")
        {
            value = (Corti.GuidedDocumentByAssemblyWithInteractionId)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Corti.GuidedDocumentByAssemblyWithContext, T> onGuidedDocumentByAssemblyWithContext,
        Func<
            Corti.GuidedDocumentByAssemblyWithInteractionId,
            T
        > onGuidedDocumentByAssemblyWithInteractionId
    )
    {
        return Type switch
        {
            "guidedDocumentByAssemblyWithContext" => onGuidedDocumentByAssemblyWithContext(
                AsGuidedDocumentByAssemblyWithContext()
            ),
            "guidedDocumentByAssemblyWithInteractionId" =>
                onGuidedDocumentByAssemblyWithInteractionId(
                    AsGuidedDocumentByAssemblyWithInteractionId()
                ),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Corti.GuidedDocumentByAssemblyWithContext> onGuidedDocumentByAssemblyWithContext,
        Action<Corti.GuidedDocumentByAssemblyWithInteractionId> onGuidedDocumentByAssemblyWithInteractionId
    )
    {
        switch (Type)
        {
            case "guidedDocumentByAssemblyWithContext":
                onGuidedDocumentByAssemblyWithContext(AsGuidedDocumentByAssemblyWithContext());
                break;
            case "guidedDocumentByAssemblyWithInteractionId":
                onGuidedDocumentByAssemblyWithInteractionId(
                    AsGuidedDocumentByAssemblyWithInteractionId()
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
        if (obj is not GuidedDocumentByAssembly other)
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

    public static implicit operator GuidedDocumentByAssembly(
        Corti.GuidedDocumentByAssemblyWithContext value
    ) => new("guidedDocumentByAssemblyWithContext", value);

    public static implicit operator GuidedDocumentByAssembly(
        Corti.GuidedDocumentByAssemblyWithInteractionId value
    ) => new("guidedDocumentByAssemblyWithInteractionId", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<GuidedDocumentByAssembly>
    {
        public override GuidedDocumentByAssembly? Read(
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
                        "guidedDocumentByAssemblyWithContext",
                        typeof(Corti.GuidedDocumentByAssemblyWithContext)
                    ),
                    (
                        "guidedDocumentByAssemblyWithInteractionId",
                        typeof(Corti.GuidedDocumentByAssemblyWithInteractionId)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            GuidedDocumentByAssembly result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into GuidedDocumentByAssembly"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            GuidedDocumentByAssembly value,
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

        public override GuidedDocumentByAssembly ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            GuidedDocumentByAssembly result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GuidedDocumentByAssembly value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
