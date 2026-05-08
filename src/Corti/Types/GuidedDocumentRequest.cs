// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(GuidedDocumentRequest.JsonConverter))]
[Serializable]
public class GuidedDocumentRequest
{
    private GuidedDocumentRequest(string type, object? value)
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
    public static GuidedDocumentRequest FromGuidedDocumentByTemplateRefWithContext(
        Corti.GuidedDocumentByTemplateRefWithContext value
    ) => new("guidedDocumentByTemplateRefWithContext", value);

    /// <summary>
    /// Factory method to create a union from a Corti.GuidedDocumentByTemplateRefWithInteractionId value.
    /// </summary>
    public static GuidedDocumentRequest FromGuidedDocumentByTemplateRefWithInteractionId(
        Corti.GuidedDocumentByTemplateRefWithInteractionId value
    ) => new("guidedDocumentByTemplateRefWithInteractionId", value);

    /// <summary>
    /// Factory method to create a union from a Corti.GuidedDocumentByAssemblyWithContext value.
    /// </summary>
    public static GuidedDocumentRequest FromGuidedDocumentByAssemblyWithContext(
        Corti.GuidedDocumentByAssemblyWithContext value
    ) => new("guidedDocumentByAssemblyWithContext", value);

    /// <summary>
    /// Factory method to create a union from a Corti.GuidedDocumentByAssemblyWithInteractionId value.
    /// </summary>
    public static GuidedDocumentRequest FromGuidedDocumentByAssemblyWithInteractionId(
        Corti.GuidedDocumentByAssemblyWithInteractionId value
    ) => new("guidedDocumentByAssemblyWithInteractionId", value);

    /// <summary>
    /// Factory method to create a union from a Corti.GuidedDocumentByDynamicWithContext value.
    /// </summary>
    public static GuidedDocumentRequest FromGuidedDocumentByDynamicWithContext(
        Corti.GuidedDocumentByDynamicWithContext value
    ) => new("guidedDocumentByDynamicWithContext", value);

    /// <summary>
    /// Factory method to create a union from a Corti.GuidedDocumentByDynamicWithInteractionId value.
    /// </summary>
    public static GuidedDocumentRequest FromGuidedDocumentByDynamicWithInteractionId(
        Corti.GuidedDocumentByDynamicWithInteractionId value
    ) => new("guidedDocumentByDynamicWithInteractionId", value);

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
        Func<
            Corti.GuidedDocumentByTemplateRefWithContext,
            T
        > onGuidedDocumentByTemplateRefWithContext,
        Func<
            Corti.GuidedDocumentByTemplateRefWithInteractionId,
            T
        > onGuidedDocumentByTemplateRefWithInteractionId,
        Func<Corti.GuidedDocumentByAssemblyWithContext, T> onGuidedDocumentByAssemblyWithContext,
        Func<
            Corti.GuidedDocumentByAssemblyWithInteractionId,
            T
        > onGuidedDocumentByAssemblyWithInteractionId,
        Func<Corti.GuidedDocumentByDynamicWithContext, T> onGuidedDocumentByDynamicWithContext,
        Func<
            Corti.GuidedDocumentByDynamicWithInteractionId,
            T
        > onGuidedDocumentByDynamicWithInteractionId
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
            "guidedDocumentByAssemblyWithContext" => onGuidedDocumentByAssemblyWithContext(
                AsGuidedDocumentByAssemblyWithContext()
            ),
            "guidedDocumentByAssemblyWithInteractionId" =>
                onGuidedDocumentByAssemblyWithInteractionId(
                    AsGuidedDocumentByAssemblyWithInteractionId()
                ),
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
        Action<Corti.GuidedDocumentByTemplateRefWithContext> onGuidedDocumentByTemplateRefWithContext,
        Action<Corti.GuidedDocumentByTemplateRefWithInteractionId> onGuidedDocumentByTemplateRefWithInteractionId,
        Action<Corti.GuidedDocumentByAssemblyWithContext> onGuidedDocumentByAssemblyWithContext,
        Action<Corti.GuidedDocumentByAssemblyWithInteractionId> onGuidedDocumentByAssemblyWithInteractionId,
        Action<Corti.GuidedDocumentByDynamicWithContext> onGuidedDocumentByDynamicWithContext,
        Action<Corti.GuidedDocumentByDynamicWithInteractionId> onGuidedDocumentByDynamicWithInteractionId
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
            case "guidedDocumentByAssemblyWithContext":
                onGuidedDocumentByAssemblyWithContext(AsGuidedDocumentByAssemblyWithContext());
                break;
            case "guidedDocumentByAssemblyWithInteractionId":
                onGuidedDocumentByAssemblyWithInteractionId(
                    AsGuidedDocumentByAssemblyWithInteractionId()
                );
                break;
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
        if (obj is not GuidedDocumentRequest other)
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

    public static implicit operator GuidedDocumentRequest(
        Corti.GuidedDocumentByTemplateRefWithContext value
    ) => new("guidedDocumentByTemplateRefWithContext", value);

    public static implicit operator GuidedDocumentRequest(
        Corti.GuidedDocumentByTemplateRefWithInteractionId value
    ) => new("guidedDocumentByTemplateRefWithInteractionId", value);

    public static implicit operator GuidedDocumentRequest(
        Corti.GuidedDocumentByAssemblyWithContext value
    ) => new("guidedDocumentByAssemblyWithContext", value);

    public static implicit operator GuidedDocumentRequest(
        Corti.GuidedDocumentByAssemblyWithInteractionId value
    ) => new("guidedDocumentByAssemblyWithInteractionId", value);

    public static implicit operator GuidedDocumentRequest(
        Corti.GuidedDocumentByDynamicWithContext value
    ) => new("guidedDocumentByDynamicWithContext", value);

    public static implicit operator GuidedDocumentRequest(
        Corti.GuidedDocumentByDynamicWithInteractionId value
    ) => new("guidedDocumentByDynamicWithInteractionId", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<GuidedDocumentRequest>
    {
        public override GuidedDocumentRequest? Read(
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
                    (
                        "guidedDocumentByAssemblyWithContext",
                        typeof(Corti.GuidedDocumentByAssemblyWithContext)
                    ),
                    (
                        "guidedDocumentByAssemblyWithInteractionId",
                        typeof(Corti.GuidedDocumentByAssemblyWithInteractionId)
                    ),
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
                            GuidedDocumentRequest result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into GuidedDocumentRequest"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            GuidedDocumentRequest value,
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
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override GuidedDocumentRequest ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            GuidedDocumentRequest result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GuidedDocumentRequest value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
