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
    /// Factory method to create a union from a Corti.GuidedDocumentByTemplateRef value.
    /// </summary>
    public static GuidedDocumentRequest FromGuidedDocumentByTemplateRef(
        Corti.GuidedDocumentByTemplateRef value
    ) => new("guidedDocumentByTemplateRef", value);

    /// <summary>
    /// Factory method to create a union from a Corti.GuidedDocumentByAssembly value.
    /// </summary>
    public static GuidedDocumentRequest FromGuidedDocumentByAssembly(
        Corti.GuidedDocumentByAssembly value
    ) => new("guidedDocumentByAssembly", value);

    /// <summary>
    /// Factory method to create a union from a Corti.GuidedDocumentByDynamic value.
    /// </summary>
    public static GuidedDocumentRequest FromGuidedDocumentByDynamic(
        Corti.GuidedDocumentByDynamic value
    ) => new("guidedDocumentByDynamic", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guidedDocumentByTemplateRef"
    /// </summary>
    public bool IsGuidedDocumentByTemplateRef() => Type == "guidedDocumentByTemplateRef";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guidedDocumentByAssembly"
    /// </summary>
    public bool IsGuidedDocumentByAssembly() => Type == "guidedDocumentByAssembly";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guidedDocumentByDynamic"
    /// </summary>
    public bool IsGuidedDocumentByDynamic() => Type == "guidedDocumentByDynamic";

    /// <summary>
    /// Returns the value as a <see cref="Corti.GuidedDocumentByTemplateRef"/> if <see cref="Type"/> is 'guidedDocumentByTemplateRef', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'guidedDocumentByTemplateRef'.</exception>
    public Corti.GuidedDocumentByTemplateRef AsGuidedDocumentByTemplateRef() =>
        IsGuidedDocumentByTemplateRef()
            ? (Corti.GuidedDocumentByTemplateRef)Value!
            : throw new CortiClientException("Union type is not 'guidedDocumentByTemplateRef'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.GuidedDocumentByAssembly"/> if <see cref="Type"/> is 'guidedDocumentByAssembly', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'guidedDocumentByAssembly'.</exception>
    public Corti.GuidedDocumentByAssembly AsGuidedDocumentByAssembly() =>
        IsGuidedDocumentByAssembly()
            ? (Corti.GuidedDocumentByAssembly)Value!
            : throw new CortiClientException("Union type is not 'guidedDocumentByAssembly'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.GuidedDocumentByDynamic"/> if <see cref="Type"/> is 'guidedDocumentByDynamic', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'guidedDocumentByDynamic'.</exception>
    public Corti.GuidedDocumentByDynamic AsGuidedDocumentByDynamic() =>
        IsGuidedDocumentByDynamic()
            ? (Corti.GuidedDocumentByDynamic)Value!
            : throw new CortiClientException("Union type is not 'guidedDocumentByDynamic'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.GuidedDocumentByTemplateRef"/> and returns true if successful.
    /// </summary>
    public bool TryGetGuidedDocumentByTemplateRef(out Corti.GuidedDocumentByTemplateRef? value)
    {
        if (Type == "guidedDocumentByTemplateRef")
        {
            value = (Corti.GuidedDocumentByTemplateRef)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.GuidedDocumentByAssembly"/> and returns true if successful.
    /// </summary>
    public bool TryGetGuidedDocumentByAssembly(out Corti.GuidedDocumentByAssembly? value)
    {
        if (Type == "guidedDocumentByAssembly")
        {
            value = (Corti.GuidedDocumentByAssembly)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.GuidedDocumentByDynamic"/> and returns true if successful.
    /// </summary>
    public bool TryGetGuidedDocumentByDynamic(out Corti.GuidedDocumentByDynamic? value)
    {
        if (Type == "guidedDocumentByDynamic")
        {
            value = (Corti.GuidedDocumentByDynamic)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Corti.GuidedDocumentByTemplateRef, T> onGuidedDocumentByTemplateRef,
        Func<Corti.GuidedDocumentByAssembly, T> onGuidedDocumentByAssembly,
        Func<Corti.GuidedDocumentByDynamic, T> onGuidedDocumentByDynamic
    )
    {
        return Type switch
        {
            "guidedDocumentByTemplateRef" => onGuidedDocumentByTemplateRef(
                AsGuidedDocumentByTemplateRef()
            ),
            "guidedDocumentByAssembly" => onGuidedDocumentByAssembly(AsGuidedDocumentByAssembly()),
            "guidedDocumentByDynamic" => onGuidedDocumentByDynamic(AsGuidedDocumentByDynamic()),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Corti.GuidedDocumentByTemplateRef> onGuidedDocumentByTemplateRef,
        Action<Corti.GuidedDocumentByAssembly> onGuidedDocumentByAssembly,
        Action<Corti.GuidedDocumentByDynamic> onGuidedDocumentByDynamic
    )
    {
        switch (Type)
        {
            case "guidedDocumentByTemplateRef":
                onGuidedDocumentByTemplateRef(AsGuidedDocumentByTemplateRef());
                break;
            case "guidedDocumentByAssembly":
                onGuidedDocumentByAssembly(AsGuidedDocumentByAssembly());
                break;
            case "guidedDocumentByDynamic":
                onGuidedDocumentByDynamic(AsGuidedDocumentByDynamic());
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
        Corti.GuidedDocumentByTemplateRef value
    ) => new("guidedDocumentByTemplateRef", value);

    public static implicit operator GuidedDocumentRequest(Corti.GuidedDocumentByAssembly value) =>
        new("guidedDocumentByAssembly", value);

    public static implicit operator GuidedDocumentRequest(Corti.GuidedDocumentByDynamic value) =>
        new("guidedDocumentByDynamic", value);

    public static implicit operator GuidedDocumentRequest(
        Corti.GuidedDocumentByTemplateRefWithContext value
    ) => new("guidedDocumentByTemplateRef", (GuidedDocumentByTemplateRef)value);

    public static implicit operator GuidedDocumentRequest(
        Corti.GuidedDocumentByTemplateRefWithInteractionId value
    ) => new("guidedDocumentByTemplateRef", (GuidedDocumentByTemplateRef)value);

    public static implicit operator GuidedDocumentRequest(
        Corti.GuidedDocumentByAssemblyWithContext value
    ) => new("guidedDocumentByAssembly", (GuidedDocumentByAssembly)value);

    public static implicit operator GuidedDocumentRequest(
        Corti.GuidedDocumentByAssemblyWithInteractionId value
    ) => new("guidedDocumentByAssembly", (GuidedDocumentByAssembly)value);

    public static implicit operator GuidedDocumentRequest(
        Corti.GuidedDocumentByDynamicWithContext value
    ) => new("guidedDocumentByDynamic", (GuidedDocumentByDynamic)value);

    public static implicit operator GuidedDocumentRequest(
        Corti.GuidedDocumentByDynamicWithInteractionId value
    ) => new("guidedDocumentByDynamic", (GuidedDocumentByDynamic)value);

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
                    ("guidedDocumentByTemplateRef", typeof(Corti.GuidedDocumentByTemplateRef)),
                    ("guidedDocumentByAssembly", typeof(Corti.GuidedDocumentByAssembly)),
                    ("guidedDocumentByDynamic", typeof(Corti.GuidedDocumentByDynamic)),
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
