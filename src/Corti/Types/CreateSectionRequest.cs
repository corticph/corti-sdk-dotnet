// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(CreateSectionRequest.JsonConverter))]
[Serializable]
public class CreateSectionRequest
{
    private CreateSectionRequest(string type, object? value)
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
    /// Factory method to create a union from a Corti.CreateSectionFromScratchRequest value.
    /// </summary>
    public static CreateSectionRequest FromCreateSectionFromScratchRequest(
        Corti.CreateSectionFromScratchRequest value
    ) => new("createSectionFromScratchRequest", value);

    /// <summary>
    /// Factory method to create a union from a Corti.CreateSectionFromInheritanceRequest value.
    /// </summary>
    public static CreateSectionRequest FromCreateSectionFromInheritanceRequest(
        Corti.CreateSectionFromInheritanceRequest value
    ) => new("createSectionFromInheritanceRequest", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createSectionFromScratchRequest"
    /// </summary>
    public bool IsCreateSectionFromScratchRequest() => Type == "createSectionFromScratchRequest";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createSectionFromInheritanceRequest"
    /// </summary>
    public bool IsCreateSectionFromInheritanceRequest() =>
        Type == "createSectionFromInheritanceRequest";

    /// <summary>
    /// Returns the value as a <see cref="Corti.CreateSectionFromScratchRequest"/> if <see cref="Type"/> is 'createSectionFromScratchRequest', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'createSectionFromScratchRequest'.</exception>
    public Corti.CreateSectionFromScratchRequest AsCreateSectionFromScratchRequest() =>
        IsCreateSectionFromScratchRequest()
            ? (Corti.CreateSectionFromScratchRequest)Value!
            : throw new CortiClientException("Union type is not 'createSectionFromScratchRequest'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.CreateSectionFromInheritanceRequest"/> if <see cref="Type"/> is 'createSectionFromInheritanceRequest', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'createSectionFromInheritanceRequest'.</exception>
    public Corti.CreateSectionFromInheritanceRequest AsCreateSectionFromInheritanceRequest() =>
        IsCreateSectionFromInheritanceRequest()
            ? (Corti.CreateSectionFromInheritanceRequest)Value!
            : throw new CortiClientException(
                "Union type is not 'createSectionFromInheritanceRequest'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.CreateSectionFromScratchRequest"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateSectionFromScratchRequest(
        out Corti.CreateSectionFromScratchRequest? value
    )
    {
        if (Type == "createSectionFromScratchRequest")
        {
            value = (Corti.CreateSectionFromScratchRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.CreateSectionFromInheritanceRequest"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateSectionFromInheritanceRequest(
        out Corti.CreateSectionFromInheritanceRequest? value
    )
    {
        if (Type == "createSectionFromInheritanceRequest")
        {
            value = (Corti.CreateSectionFromInheritanceRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Corti.CreateSectionFromScratchRequest, T> onCreateSectionFromScratchRequest,
        Func<Corti.CreateSectionFromInheritanceRequest, T> onCreateSectionFromInheritanceRequest
    )
    {
        return Type switch
        {
            "createSectionFromScratchRequest" => onCreateSectionFromScratchRequest(
                AsCreateSectionFromScratchRequest()
            ),
            "createSectionFromInheritanceRequest" => onCreateSectionFromInheritanceRequest(
                AsCreateSectionFromInheritanceRequest()
            ),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Corti.CreateSectionFromScratchRequest> onCreateSectionFromScratchRequest,
        Action<Corti.CreateSectionFromInheritanceRequest> onCreateSectionFromInheritanceRequest
    )
    {
        switch (Type)
        {
            case "createSectionFromScratchRequest":
                onCreateSectionFromScratchRequest(AsCreateSectionFromScratchRequest());
                break;
            case "createSectionFromInheritanceRequest":
                onCreateSectionFromInheritanceRequest(AsCreateSectionFromInheritanceRequest());
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
        if (obj is not CreateSectionRequest other)
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

    public static implicit operator CreateSectionRequest(
        Corti.CreateSectionFromScratchRequest value
    ) => new("createSectionFromScratchRequest", value);

    public static implicit operator CreateSectionRequest(
        Corti.CreateSectionFromInheritanceRequest value
    ) => new("createSectionFromInheritanceRequest", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateSectionRequest>
    {
        public override CreateSectionRequest? Read(
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
                        "createSectionFromScratchRequest",
                        typeof(Corti.CreateSectionFromScratchRequest)
                    ),
                    (
                        "createSectionFromInheritanceRequest",
                        typeof(Corti.CreateSectionFromInheritanceRequest)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            CreateSectionRequest result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into CreateSectionRequest"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateSectionRequest value,
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

        public override CreateSectionRequest ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CreateSectionRequest result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateSectionRequest value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
