// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(GuidedDocumentsGenerateRequest.JsonConverter))]
[Serializable]
public class GuidedDocumentsGenerateRequest
{
    private GuidedDocumentsGenerateRequest(string type, object? value)
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
    /// Factory method to create a union from a Corti.GuidedDocumentsGenerateByTemplateRef value.
    /// </summary>
    public static GuidedDocumentsGenerateRequest FromGuidedDocumentsGenerateByTemplateRef(
        Corti.GuidedDocumentsGenerateByTemplateRef value
    ) => new("guidedDocumentsGenerateByTemplateRef", value);

    /// <summary>
    /// Factory method to create a union from a Corti.GuidedDocumentsGenerateByAssembly value.
    /// </summary>
    public static GuidedDocumentsGenerateRequest FromGuidedDocumentsGenerateByAssembly(
        Corti.GuidedDocumentsGenerateByAssembly value
    ) => new("guidedDocumentsGenerateByAssembly", value);

    /// <summary>
    /// Factory method to create a union from a Corti.GuidedDocumentsGenerateByDynamic value.
    /// </summary>
    public static GuidedDocumentsGenerateRequest FromGuidedDocumentsGenerateByDynamic(
        Corti.GuidedDocumentsGenerateByDynamic value
    ) => new("guidedDocumentsGenerateByDynamic", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guidedDocumentsGenerateByTemplateRef"
    /// </summary>
    public bool IsGuidedDocumentsGenerateByTemplateRef() =>
        Type == "guidedDocumentsGenerateByTemplateRef";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guidedDocumentsGenerateByAssembly"
    /// </summary>
    public bool IsGuidedDocumentsGenerateByAssembly() =>
        Type == "guidedDocumentsGenerateByAssembly";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guidedDocumentsGenerateByDynamic"
    /// </summary>
    public bool IsGuidedDocumentsGenerateByDynamic() => Type == "guidedDocumentsGenerateByDynamic";

    /// <summary>
    /// Returns the value as a <see cref="Corti.GuidedDocumentsGenerateByTemplateRef"/> if <see cref="Type"/> is 'guidedDocumentsGenerateByTemplateRef', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'guidedDocumentsGenerateByTemplateRef'.</exception>
    public Corti.GuidedDocumentsGenerateByTemplateRef AsGuidedDocumentsGenerateByTemplateRef() =>
        IsGuidedDocumentsGenerateByTemplateRef()
            ? (Corti.GuidedDocumentsGenerateByTemplateRef)Value!
            : throw new CortiClientException(
                "Union type is not 'guidedDocumentsGenerateByTemplateRef'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Corti.GuidedDocumentsGenerateByAssembly"/> if <see cref="Type"/> is 'guidedDocumentsGenerateByAssembly', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'guidedDocumentsGenerateByAssembly'.</exception>
    public Corti.GuidedDocumentsGenerateByAssembly AsGuidedDocumentsGenerateByAssembly() =>
        IsGuidedDocumentsGenerateByAssembly()
            ? (Corti.GuidedDocumentsGenerateByAssembly)Value!
            : throw new CortiClientException(
                "Union type is not 'guidedDocumentsGenerateByAssembly'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Corti.GuidedDocumentsGenerateByDynamic"/> if <see cref="Type"/> is 'guidedDocumentsGenerateByDynamic', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'guidedDocumentsGenerateByDynamic'.</exception>
    public Corti.GuidedDocumentsGenerateByDynamic AsGuidedDocumentsGenerateByDynamic() =>
        IsGuidedDocumentsGenerateByDynamic()
            ? (Corti.GuidedDocumentsGenerateByDynamic)Value!
            : throw new CortiClientException(
                "Union type is not 'guidedDocumentsGenerateByDynamic'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.GuidedDocumentsGenerateByTemplateRef"/> and returns true if successful.
    /// </summary>
    public bool TryGetGuidedDocumentsGenerateByTemplateRef(
        out Corti.GuidedDocumentsGenerateByTemplateRef? value
    )
    {
        if (Type == "guidedDocumentsGenerateByTemplateRef")
        {
            value = (Corti.GuidedDocumentsGenerateByTemplateRef)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.GuidedDocumentsGenerateByAssembly"/> and returns true if successful.
    /// </summary>
    public bool TryGetGuidedDocumentsGenerateByAssembly(
        out Corti.GuidedDocumentsGenerateByAssembly? value
    )
    {
        if (Type == "guidedDocumentsGenerateByAssembly")
        {
            value = (Corti.GuidedDocumentsGenerateByAssembly)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.GuidedDocumentsGenerateByDynamic"/> and returns true if successful.
    /// </summary>
    public bool TryGetGuidedDocumentsGenerateByDynamic(
        out Corti.GuidedDocumentsGenerateByDynamic? value
    )
    {
        if (Type == "guidedDocumentsGenerateByDynamic")
        {
            value = (Corti.GuidedDocumentsGenerateByDynamic)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Corti.GuidedDocumentsGenerateByTemplateRef, T> onGuidedDocumentsGenerateByTemplateRef,
        Func<Corti.GuidedDocumentsGenerateByAssembly, T> onGuidedDocumentsGenerateByAssembly,
        Func<Corti.GuidedDocumentsGenerateByDynamic, T> onGuidedDocumentsGenerateByDynamic
    )
    {
        return Type switch
        {
            "guidedDocumentsGenerateByTemplateRef" => onGuidedDocumentsGenerateByTemplateRef(
                AsGuidedDocumentsGenerateByTemplateRef()
            ),
            "guidedDocumentsGenerateByAssembly" => onGuidedDocumentsGenerateByAssembly(
                AsGuidedDocumentsGenerateByAssembly()
            ),
            "guidedDocumentsGenerateByDynamic" => onGuidedDocumentsGenerateByDynamic(
                AsGuidedDocumentsGenerateByDynamic()
            ),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Corti.GuidedDocumentsGenerateByTemplateRef> onGuidedDocumentsGenerateByTemplateRef,
        Action<Corti.GuidedDocumentsGenerateByAssembly> onGuidedDocumentsGenerateByAssembly,
        Action<Corti.GuidedDocumentsGenerateByDynamic> onGuidedDocumentsGenerateByDynamic
    )
    {
        switch (Type)
        {
            case "guidedDocumentsGenerateByTemplateRef":
                onGuidedDocumentsGenerateByTemplateRef(AsGuidedDocumentsGenerateByTemplateRef());
                break;
            case "guidedDocumentsGenerateByAssembly":
                onGuidedDocumentsGenerateByAssembly(AsGuidedDocumentsGenerateByAssembly());
                break;
            case "guidedDocumentsGenerateByDynamic":
                onGuidedDocumentsGenerateByDynamic(AsGuidedDocumentsGenerateByDynamic());
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
        if (obj is not GuidedDocumentsGenerateRequest other)
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

    public static implicit operator GuidedDocumentsGenerateRequest(
        Corti.GuidedDocumentsGenerateByTemplateRef value
    ) => new("guidedDocumentsGenerateByTemplateRef", value);

    public static implicit operator GuidedDocumentsGenerateRequest(
        Corti.GuidedDocumentsGenerateByAssembly value
    ) => new("guidedDocumentsGenerateByAssembly", value);

    public static implicit operator GuidedDocumentsGenerateRequest(
        Corti.GuidedDocumentsGenerateByDynamic value
    ) => new("guidedDocumentsGenerateByDynamic", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<GuidedDocumentsGenerateRequest>
    {
        public override GuidedDocumentsGenerateRequest? Read(
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
                        "guidedDocumentsGenerateByTemplateRef",
                        typeof(Corti.GuidedDocumentsGenerateByTemplateRef)
                    ),
                    (
                        "guidedDocumentsGenerateByAssembly",
                        typeof(Corti.GuidedDocumentsGenerateByAssembly)
                    ),
                    (
                        "guidedDocumentsGenerateByDynamic",
                        typeof(Corti.GuidedDocumentsGenerateByDynamic)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            GuidedDocumentsGenerateRequest result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into GuidedDocumentsGenerateRequest"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            GuidedDocumentsGenerateRequest value,
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

        public override GuidedDocumentsGenerateRequest ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            GuidedDocumentsGenerateRequest result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GuidedDocumentsGenerateRequest value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
