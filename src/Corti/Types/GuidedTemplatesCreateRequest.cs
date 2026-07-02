// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(GuidedTemplatesCreateRequest.JsonConverter))]
[Serializable]
public class GuidedTemplatesCreateRequest
{
    private GuidedTemplatesCreateRequest(string type, object? value)
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
    /// Factory method to create a union from a Corti.GuidedTemplatesCreateFromInheritanceRequest value.
    /// </summary>
    public static GuidedTemplatesCreateRequest FromGuidedTemplatesCreateFromInheritanceRequest(
        Corti.GuidedTemplatesCreateFromInheritanceRequest value
    ) => new("guidedTemplatesCreateFromInheritanceRequest", value);

    /// <summary>
    /// Factory method to create a union from a Corti.GuidedTemplatesCreateFromScratchRequest value.
    /// </summary>
    public static GuidedTemplatesCreateRequest FromGuidedTemplatesCreateFromScratchRequest(
        Corti.GuidedTemplatesCreateFromScratchRequest value
    ) => new("guidedTemplatesCreateFromScratchRequest", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guidedTemplatesCreateFromInheritanceRequest"
    /// </summary>
    public bool IsGuidedTemplatesCreateFromInheritanceRequest() =>
        Type == "guidedTemplatesCreateFromInheritanceRequest";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guidedTemplatesCreateFromScratchRequest"
    /// </summary>
    public bool IsGuidedTemplatesCreateFromScratchRequest() =>
        Type == "guidedTemplatesCreateFromScratchRequest";

    /// <summary>
    /// Returns the value as a <see cref="Corti.GuidedTemplatesCreateFromInheritanceRequest"/> if <see cref="Type"/> is 'guidedTemplatesCreateFromInheritanceRequest', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'guidedTemplatesCreateFromInheritanceRequest'.</exception>
    public Corti.GuidedTemplatesCreateFromInheritanceRequest AsGuidedTemplatesCreateFromInheritanceRequest() =>
        IsGuidedTemplatesCreateFromInheritanceRequest()
            ? (Corti.GuidedTemplatesCreateFromInheritanceRequest)Value!
            : throw new CortiClientException(
                "Union type is not 'guidedTemplatesCreateFromInheritanceRequest'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Corti.GuidedTemplatesCreateFromScratchRequest"/> if <see cref="Type"/> is 'guidedTemplatesCreateFromScratchRequest', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'guidedTemplatesCreateFromScratchRequest'.</exception>
    public Corti.GuidedTemplatesCreateFromScratchRequest AsGuidedTemplatesCreateFromScratchRequest() =>
        IsGuidedTemplatesCreateFromScratchRequest()
            ? (Corti.GuidedTemplatesCreateFromScratchRequest)Value!
            : throw new CortiClientException(
                "Union type is not 'guidedTemplatesCreateFromScratchRequest'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.GuidedTemplatesCreateFromInheritanceRequest"/> and returns true if successful.
    /// </summary>
    public bool TryGetGuidedTemplatesCreateFromInheritanceRequest(
        out Corti.GuidedTemplatesCreateFromInheritanceRequest? value
    )
    {
        if (Type == "guidedTemplatesCreateFromInheritanceRequest")
        {
            value = (Corti.GuidedTemplatesCreateFromInheritanceRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.GuidedTemplatesCreateFromScratchRequest"/> and returns true if successful.
    /// </summary>
    public bool TryGetGuidedTemplatesCreateFromScratchRequest(
        out Corti.GuidedTemplatesCreateFromScratchRequest? value
    )
    {
        if (Type == "guidedTemplatesCreateFromScratchRequest")
        {
            value = (Corti.GuidedTemplatesCreateFromScratchRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Corti.GuidedTemplatesCreateFromInheritanceRequest,
            T
        > onGuidedTemplatesCreateFromInheritanceRequest,
        Func<
            Corti.GuidedTemplatesCreateFromScratchRequest,
            T
        > onGuidedTemplatesCreateFromScratchRequest
    )
    {
        return Type switch
        {
            "guidedTemplatesCreateFromInheritanceRequest" =>
                onGuidedTemplatesCreateFromInheritanceRequest(
                    AsGuidedTemplatesCreateFromInheritanceRequest()
                ),
            "guidedTemplatesCreateFromScratchRequest" => onGuidedTemplatesCreateFromScratchRequest(
                AsGuidedTemplatesCreateFromScratchRequest()
            ),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Corti.GuidedTemplatesCreateFromInheritanceRequest> onGuidedTemplatesCreateFromInheritanceRequest,
        Action<Corti.GuidedTemplatesCreateFromScratchRequest> onGuidedTemplatesCreateFromScratchRequest
    )
    {
        switch (Type)
        {
            case "guidedTemplatesCreateFromInheritanceRequest":
                onGuidedTemplatesCreateFromInheritanceRequest(
                    AsGuidedTemplatesCreateFromInheritanceRequest()
                );
                break;
            case "guidedTemplatesCreateFromScratchRequest":
                onGuidedTemplatesCreateFromScratchRequest(
                    AsGuidedTemplatesCreateFromScratchRequest()
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
        if (obj is not GuidedTemplatesCreateRequest other)
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

    public static implicit operator GuidedTemplatesCreateRequest(
        Corti.GuidedTemplatesCreateFromInheritanceRequest value
    ) => new("guidedTemplatesCreateFromInheritanceRequest", value);

    public static implicit operator GuidedTemplatesCreateRequest(
        Corti.GuidedTemplatesCreateFromScratchRequest value
    ) => new("guidedTemplatesCreateFromScratchRequest", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<GuidedTemplatesCreateRequest>
    {
        public override GuidedTemplatesCreateRequest? Read(
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
                        "guidedTemplatesCreateFromInheritanceRequest",
                        typeof(Corti.GuidedTemplatesCreateFromInheritanceRequest)
                    ),
                    (
                        "guidedTemplatesCreateFromScratchRequest",
                        typeof(Corti.GuidedTemplatesCreateFromScratchRequest)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            GuidedTemplatesCreateRequest result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into GuidedTemplatesCreateRequest"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            GuidedTemplatesCreateRequest value,
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

        public override GuidedTemplatesCreateRequest ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            GuidedTemplatesCreateRequest result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GuidedTemplatesCreateRequest value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
