// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(CreateTemplateRequest.JsonConverter))]
[Serializable]
public class CreateTemplateRequest
{
    private CreateTemplateRequest(string type, object? value)
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
    /// Factory method to create a union from a Corti.CreateTemplateFromScratchRequest value.
    /// </summary>
    public static CreateTemplateRequest FromCreateTemplateFromScratchRequest(
        Corti.CreateTemplateFromScratchRequest value
    ) => new("createTemplateFromScratchRequest", value);

    /// <summary>
    /// Factory method to create a union from a Corti.CreateTemplateFromInheritanceRequest value.
    /// </summary>
    public static CreateTemplateRequest FromCreateTemplateFromInheritanceRequest(
        Corti.CreateTemplateFromInheritanceRequest value
    ) => new("createTemplateFromInheritanceRequest", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createTemplateFromScratchRequest"
    /// </summary>
    public bool IsCreateTemplateFromScratchRequest() => Type == "createTemplateFromScratchRequest";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createTemplateFromInheritanceRequest"
    /// </summary>
    public bool IsCreateTemplateFromInheritanceRequest() =>
        Type == "createTemplateFromInheritanceRequest";

    /// <summary>
    /// Returns the value as a <see cref="Corti.CreateTemplateFromScratchRequest"/> if <see cref="Type"/> is 'createTemplateFromScratchRequest', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'createTemplateFromScratchRequest'.</exception>
    public Corti.CreateTemplateFromScratchRequest AsCreateTemplateFromScratchRequest() =>
        IsCreateTemplateFromScratchRequest()
            ? (Corti.CreateTemplateFromScratchRequest)Value!
            : throw new CortiClientException(
                "Union type is not 'createTemplateFromScratchRequest'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Corti.CreateTemplateFromInheritanceRequest"/> if <see cref="Type"/> is 'createTemplateFromInheritanceRequest', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'createTemplateFromInheritanceRequest'.</exception>
    public Corti.CreateTemplateFromInheritanceRequest AsCreateTemplateFromInheritanceRequest() =>
        IsCreateTemplateFromInheritanceRequest()
            ? (Corti.CreateTemplateFromInheritanceRequest)Value!
            : throw new CortiClientException(
                "Union type is not 'createTemplateFromInheritanceRequest'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.CreateTemplateFromScratchRequest"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateTemplateFromScratchRequest(
        out Corti.CreateTemplateFromScratchRequest? value
    )
    {
        if (Type == "createTemplateFromScratchRequest")
        {
            value = (Corti.CreateTemplateFromScratchRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.CreateTemplateFromInheritanceRequest"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateTemplateFromInheritanceRequest(
        out Corti.CreateTemplateFromInheritanceRequest? value
    )
    {
        if (Type == "createTemplateFromInheritanceRequest")
        {
            value = (Corti.CreateTemplateFromInheritanceRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Corti.CreateTemplateFromScratchRequest, T> onCreateTemplateFromScratchRequest,
        Func<Corti.CreateTemplateFromInheritanceRequest, T> onCreateTemplateFromInheritanceRequest
    )
    {
        return Type switch
        {
            "createTemplateFromScratchRequest" => onCreateTemplateFromScratchRequest(
                AsCreateTemplateFromScratchRequest()
            ),
            "createTemplateFromInheritanceRequest" => onCreateTemplateFromInheritanceRequest(
                AsCreateTemplateFromInheritanceRequest()
            ),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Corti.CreateTemplateFromScratchRequest> onCreateTemplateFromScratchRequest,
        Action<Corti.CreateTemplateFromInheritanceRequest> onCreateTemplateFromInheritanceRequest
    )
    {
        switch (Type)
        {
            case "createTemplateFromScratchRequest":
                onCreateTemplateFromScratchRequest(AsCreateTemplateFromScratchRequest());
                break;
            case "createTemplateFromInheritanceRequest":
                onCreateTemplateFromInheritanceRequest(AsCreateTemplateFromInheritanceRequest());
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
        if (obj is not CreateTemplateRequest other)
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

    public static implicit operator CreateTemplateRequest(
        Corti.CreateTemplateFromScratchRequest value
    ) => new("createTemplateFromScratchRequest", value);

    public static implicit operator CreateTemplateRequest(
        Corti.CreateTemplateFromInheritanceRequest value
    ) => new("createTemplateFromInheritanceRequest", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateTemplateRequest>
    {
        public override CreateTemplateRequest? Read(
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
                        "createTemplateFromScratchRequest",
                        typeof(Corti.CreateTemplateFromScratchRequest)
                    ),
                    (
                        "createTemplateFromInheritanceRequest",
                        typeof(Corti.CreateTemplateFromInheritanceRequest)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            CreateTemplateRequest result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into CreateTemplateRequest"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateTemplateRequest value,
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

        public override CreateTemplateRequest ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CreateTemplateRequest result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateTemplateRequest value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
