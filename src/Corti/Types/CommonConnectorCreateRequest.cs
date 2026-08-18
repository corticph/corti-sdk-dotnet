// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Same envelope as `Connector` but without the server-generated `id`.
/// </summary>
[JsonConverter(typeof(CommonConnectorCreateRequest.JsonConverter))]
[Serializable]
public class CommonConnectorCreateRequest
{
    private CommonConnectorCreateRequest(string type, object? value)
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
    /// Factory method to create a union from a Corti.CommonRegistryConnectorCreate value.
    /// </summary>
    public static CommonConnectorCreateRequest FromCommonRegistryConnectorCreate(
        Corti.CommonRegistryConnectorCreate value
    ) => new("commonRegistryConnectorCreate", value);

    /// <summary>
    /// Factory method to create a union from a Corti.CommonMcpConnectorCreate value.
    /// </summary>
    public static CommonConnectorCreateRequest FromCommonMcpConnectorCreate(
        Corti.CommonMcpConnectorCreate value
    ) => new("commonMcpConnectorCreate", value);

    /// <summary>
    /// Factory method to create a union from a Corti.CommonAgentConnectorCreate value.
    /// </summary>
    public static CommonConnectorCreateRequest FromCommonAgentConnectorCreate(
        Corti.CommonAgentConnectorCreate value
    ) => new("commonAgentConnectorCreate", value);

    /// <summary>
    /// Factory method to create a union from a Corti.CommonA2AConnectorCreate value.
    /// </summary>
    public static CommonConnectorCreateRequest FromCommonA2AConnectorCreate(
        Corti.CommonA2AConnectorCreate value
    ) => new("commonA2AConnectorCreate", value);

    /// <summary>
    /// Factory method to create a union from a Corti.CommonSchemaConnectorCreate value.
    /// </summary>
    public static CommonConnectorCreateRequest FromCommonSchemaConnectorCreate(
        Corti.CommonSchemaConnectorCreate value
    ) => new("commonSchemaConnectorCreate", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "commonRegistryConnectorCreate"
    /// </summary>
    public bool IsCommonRegistryConnectorCreate() => Type == "commonRegistryConnectorCreate";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "commonMcpConnectorCreate"
    /// </summary>
    public bool IsCommonMcpConnectorCreate() => Type == "commonMcpConnectorCreate";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "commonAgentConnectorCreate"
    /// </summary>
    public bool IsCommonAgentConnectorCreate() => Type == "commonAgentConnectorCreate";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "commonA2AConnectorCreate"
    /// </summary>
    public bool IsCommonA2AConnectorCreate() => Type == "commonA2AConnectorCreate";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "commonSchemaConnectorCreate"
    /// </summary>
    public bool IsCommonSchemaConnectorCreate() => Type == "commonSchemaConnectorCreate";

    /// <summary>
    /// Returns the value as a <see cref="Corti.CommonRegistryConnectorCreate"/> if <see cref="Type"/> is 'commonRegistryConnectorCreate', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'commonRegistryConnectorCreate'.</exception>
    public Corti.CommonRegistryConnectorCreate AsCommonRegistryConnectorCreate() =>
        IsCommonRegistryConnectorCreate()
            ? (Corti.CommonRegistryConnectorCreate)Value!
            : throw new CortiClientException("Union type is not 'commonRegistryConnectorCreate'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.CommonMcpConnectorCreate"/> if <see cref="Type"/> is 'commonMcpConnectorCreate', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'commonMcpConnectorCreate'.</exception>
    public Corti.CommonMcpConnectorCreate AsCommonMcpConnectorCreate() =>
        IsCommonMcpConnectorCreate()
            ? (Corti.CommonMcpConnectorCreate)Value!
            : throw new CortiClientException("Union type is not 'commonMcpConnectorCreate'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.CommonAgentConnectorCreate"/> if <see cref="Type"/> is 'commonAgentConnectorCreate', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'commonAgentConnectorCreate'.</exception>
    public Corti.CommonAgentConnectorCreate AsCommonAgentConnectorCreate() =>
        IsCommonAgentConnectorCreate()
            ? (Corti.CommonAgentConnectorCreate)Value!
            : throw new CortiClientException("Union type is not 'commonAgentConnectorCreate'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.CommonA2AConnectorCreate"/> if <see cref="Type"/> is 'commonA2AConnectorCreate', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'commonA2AConnectorCreate'.</exception>
    public Corti.CommonA2AConnectorCreate AsCommonA2AConnectorCreate() =>
        IsCommonA2AConnectorCreate()
            ? (Corti.CommonA2AConnectorCreate)Value!
            : throw new CortiClientException("Union type is not 'commonA2AConnectorCreate'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.CommonSchemaConnectorCreate"/> if <see cref="Type"/> is 'commonSchemaConnectorCreate', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'commonSchemaConnectorCreate'.</exception>
    public Corti.CommonSchemaConnectorCreate AsCommonSchemaConnectorCreate() =>
        IsCommonSchemaConnectorCreate()
            ? (Corti.CommonSchemaConnectorCreate)Value!
            : throw new CortiClientException("Union type is not 'commonSchemaConnectorCreate'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.CommonRegistryConnectorCreate"/> and returns true if successful.
    /// </summary>
    public bool TryGetCommonRegistryConnectorCreate(out Corti.CommonRegistryConnectorCreate? value)
    {
        if (Type == "commonRegistryConnectorCreate")
        {
            value = (Corti.CommonRegistryConnectorCreate)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.CommonMcpConnectorCreate"/> and returns true if successful.
    /// </summary>
    public bool TryGetCommonMcpConnectorCreate(out Corti.CommonMcpConnectorCreate? value)
    {
        if (Type == "commonMcpConnectorCreate")
        {
            value = (Corti.CommonMcpConnectorCreate)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.CommonAgentConnectorCreate"/> and returns true if successful.
    /// </summary>
    public bool TryGetCommonAgentConnectorCreate(out Corti.CommonAgentConnectorCreate? value)
    {
        if (Type == "commonAgentConnectorCreate")
        {
            value = (Corti.CommonAgentConnectorCreate)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.CommonA2AConnectorCreate"/> and returns true if successful.
    /// </summary>
    public bool TryGetCommonA2AConnectorCreate(out Corti.CommonA2AConnectorCreate? value)
    {
        if (Type == "commonA2AConnectorCreate")
        {
            value = (Corti.CommonA2AConnectorCreate)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.CommonSchemaConnectorCreate"/> and returns true if successful.
    /// </summary>
    public bool TryGetCommonSchemaConnectorCreate(out Corti.CommonSchemaConnectorCreate? value)
    {
        if (Type == "commonSchemaConnectorCreate")
        {
            value = (Corti.CommonSchemaConnectorCreate)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Corti.CommonRegistryConnectorCreate, T> onCommonRegistryConnectorCreate,
        Func<Corti.CommonMcpConnectorCreate, T> onCommonMcpConnectorCreate,
        Func<Corti.CommonAgentConnectorCreate, T> onCommonAgentConnectorCreate,
        Func<Corti.CommonA2AConnectorCreate, T> onCommonA2AConnectorCreate,
        Func<Corti.CommonSchemaConnectorCreate, T> onCommonSchemaConnectorCreate
    )
    {
        return Type switch
        {
            "commonRegistryConnectorCreate" => onCommonRegistryConnectorCreate(
                AsCommonRegistryConnectorCreate()
            ),
            "commonMcpConnectorCreate" => onCommonMcpConnectorCreate(AsCommonMcpConnectorCreate()),
            "commonAgentConnectorCreate" => onCommonAgentConnectorCreate(
                AsCommonAgentConnectorCreate()
            ),
            "commonA2AConnectorCreate" => onCommonA2AConnectorCreate(AsCommonA2AConnectorCreate()),
            "commonSchemaConnectorCreate" => onCommonSchemaConnectorCreate(
                AsCommonSchemaConnectorCreate()
            ),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Corti.CommonRegistryConnectorCreate> onCommonRegistryConnectorCreate,
        Action<Corti.CommonMcpConnectorCreate> onCommonMcpConnectorCreate,
        Action<Corti.CommonAgentConnectorCreate> onCommonAgentConnectorCreate,
        Action<Corti.CommonA2AConnectorCreate> onCommonA2AConnectorCreate,
        Action<Corti.CommonSchemaConnectorCreate> onCommonSchemaConnectorCreate
    )
    {
        switch (Type)
        {
            case "commonRegistryConnectorCreate":
                onCommonRegistryConnectorCreate(AsCommonRegistryConnectorCreate());
                break;
            case "commonMcpConnectorCreate":
                onCommonMcpConnectorCreate(AsCommonMcpConnectorCreate());
                break;
            case "commonAgentConnectorCreate":
                onCommonAgentConnectorCreate(AsCommonAgentConnectorCreate());
                break;
            case "commonA2AConnectorCreate":
                onCommonA2AConnectorCreate(AsCommonA2AConnectorCreate());
                break;
            case "commonSchemaConnectorCreate":
                onCommonSchemaConnectorCreate(AsCommonSchemaConnectorCreate());
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
        if (obj is not CommonConnectorCreateRequest other)
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

    public static implicit operator CommonConnectorCreateRequest(
        Corti.CommonRegistryConnectorCreate value
    ) => new("commonRegistryConnectorCreate", value);

    public static implicit operator CommonConnectorCreateRequest(
        Corti.CommonMcpConnectorCreate value
    ) => new("commonMcpConnectorCreate", value);

    public static implicit operator CommonConnectorCreateRequest(
        Corti.CommonAgentConnectorCreate value
    ) => new("commonAgentConnectorCreate", value);

    public static implicit operator CommonConnectorCreateRequest(
        Corti.CommonA2AConnectorCreate value
    ) => new("commonA2AConnectorCreate", value);

    public static implicit operator CommonConnectorCreateRequest(
        Corti.CommonSchemaConnectorCreate value
    ) => new("commonSchemaConnectorCreate", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CommonConnectorCreateRequest>
    {
        public override CommonConnectorCreateRequest? Read(
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
                    ("commonRegistryConnectorCreate", typeof(Corti.CommonRegistryConnectorCreate)),
                    ("commonMcpConnectorCreate", typeof(Corti.CommonMcpConnectorCreate)),
                    ("commonAgentConnectorCreate", typeof(Corti.CommonAgentConnectorCreate)),
                    ("commonA2AConnectorCreate", typeof(Corti.CommonA2AConnectorCreate)),
                    ("commonSchemaConnectorCreate", typeof(Corti.CommonSchemaConnectorCreate)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            CommonConnectorCreateRequest result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into CommonConnectorCreateRequest"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CommonConnectorCreateRequest value,
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
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override CommonConnectorCreateRequest ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CommonConnectorCreateRequest result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CommonConnectorCreateRequest value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
