// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(GuidedSectionsCreateRequest.JsonConverter))]
[Serializable]
public class GuidedSectionsCreateRequest
{
    private GuidedSectionsCreateRequest(string type, object? value)
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
    /// Factory method to create a union from a Corti.GuidedSectionsCreateFromScratchRequest value.
    /// </summary>
    public static GuidedSectionsCreateRequest FromGuidedSectionsCreateFromScratchRequest(
        Corti.GuidedSectionsCreateFromScratchRequest value
    ) => new("guidedSectionsCreateFromScratchRequest", value);

    /// <summary>
    /// Factory method to create a union from a Corti.GuidedSectionsCreateFromInheritanceRequest value.
    /// </summary>
    public static GuidedSectionsCreateRequest FromGuidedSectionsCreateFromInheritanceRequest(
        Corti.GuidedSectionsCreateFromInheritanceRequest value
    ) => new("guidedSectionsCreateFromInheritanceRequest", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guidedSectionsCreateFromScratchRequest"
    /// </summary>
    public bool IsGuidedSectionsCreateFromScratchRequest() =>
        Type == "guidedSectionsCreateFromScratchRequest";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guidedSectionsCreateFromInheritanceRequest"
    /// </summary>
    public bool IsGuidedSectionsCreateFromInheritanceRequest() =>
        Type == "guidedSectionsCreateFromInheritanceRequest";

    /// <summary>
    /// Returns the value as a <see cref="Corti.GuidedSectionsCreateFromScratchRequest"/> if <see cref="Type"/> is 'guidedSectionsCreateFromScratchRequest', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'guidedSectionsCreateFromScratchRequest'.</exception>
    public Corti.GuidedSectionsCreateFromScratchRequest AsGuidedSectionsCreateFromScratchRequest() =>
        IsGuidedSectionsCreateFromScratchRequest()
            ? (Corti.GuidedSectionsCreateFromScratchRequest)Value!
            : throw new CortiClientException(
                "Union type is not 'guidedSectionsCreateFromScratchRequest'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Corti.GuidedSectionsCreateFromInheritanceRequest"/> if <see cref="Type"/> is 'guidedSectionsCreateFromInheritanceRequest', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'guidedSectionsCreateFromInheritanceRequest'.</exception>
    public Corti.GuidedSectionsCreateFromInheritanceRequest AsGuidedSectionsCreateFromInheritanceRequest() =>
        IsGuidedSectionsCreateFromInheritanceRequest()
            ? (Corti.GuidedSectionsCreateFromInheritanceRequest)Value!
            : throw new CortiClientException(
                "Union type is not 'guidedSectionsCreateFromInheritanceRequest'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.GuidedSectionsCreateFromScratchRequest"/> and returns true if successful.
    /// </summary>
    public bool TryGetGuidedSectionsCreateFromScratchRequest(
        out Corti.GuidedSectionsCreateFromScratchRequest? value
    )
    {
        if (Type == "guidedSectionsCreateFromScratchRequest")
        {
            value = (Corti.GuidedSectionsCreateFromScratchRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.GuidedSectionsCreateFromInheritanceRequest"/> and returns true if successful.
    /// </summary>
    public bool TryGetGuidedSectionsCreateFromInheritanceRequest(
        out Corti.GuidedSectionsCreateFromInheritanceRequest? value
    )
    {
        if (Type == "guidedSectionsCreateFromInheritanceRequest")
        {
            value = (Corti.GuidedSectionsCreateFromInheritanceRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Corti.GuidedSectionsCreateFromScratchRequest,
            T
        > onGuidedSectionsCreateFromScratchRequest,
        Func<
            Corti.GuidedSectionsCreateFromInheritanceRequest,
            T
        > onGuidedSectionsCreateFromInheritanceRequest
    )
    {
        return Type switch
        {
            "guidedSectionsCreateFromScratchRequest" => onGuidedSectionsCreateFromScratchRequest(
                AsGuidedSectionsCreateFromScratchRequest()
            ),
            "guidedSectionsCreateFromInheritanceRequest" =>
                onGuidedSectionsCreateFromInheritanceRequest(
                    AsGuidedSectionsCreateFromInheritanceRequest()
                ),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Corti.GuidedSectionsCreateFromScratchRequest> onGuidedSectionsCreateFromScratchRequest,
        Action<Corti.GuidedSectionsCreateFromInheritanceRequest> onGuidedSectionsCreateFromInheritanceRequest
    )
    {
        switch (Type)
        {
            case "guidedSectionsCreateFromScratchRequest":
                onGuidedSectionsCreateFromScratchRequest(
                    AsGuidedSectionsCreateFromScratchRequest()
                );
                break;
            case "guidedSectionsCreateFromInheritanceRequest":
                onGuidedSectionsCreateFromInheritanceRequest(
                    AsGuidedSectionsCreateFromInheritanceRequest()
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
        if (obj is not GuidedSectionsCreateRequest other)
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

    public static implicit operator GuidedSectionsCreateRequest(
        Corti.GuidedSectionsCreateFromScratchRequest value
    ) => new("guidedSectionsCreateFromScratchRequest", value);

    public static implicit operator GuidedSectionsCreateRequest(
        Corti.GuidedSectionsCreateFromInheritanceRequest value
    ) => new("guidedSectionsCreateFromInheritanceRequest", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<GuidedSectionsCreateRequest>
    {
        public override GuidedSectionsCreateRequest? Read(
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
                    (
                        "guidedSectionsCreateFromScratchRequest",
                        typeof(Corti.GuidedSectionsCreateFromScratchRequest)
                    ),
                    (
                        "guidedSectionsCreateFromInheritanceRequest",
                        typeof(Corti.GuidedSectionsCreateFromInheritanceRequest)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            GuidedSectionsCreateRequest result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into GuidedSectionsCreateRequest"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            GuidedSectionsCreateRequest value,
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

        public override GuidedSectionsCreateRequest ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            GuidedSectionsCreateRequest result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GuidedSectionsCreateRequest value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
