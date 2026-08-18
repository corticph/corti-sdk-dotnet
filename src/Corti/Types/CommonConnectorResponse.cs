// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// A connector attached to an agent, discriminated by `type`.
/// </summary>
[JsonConverter(typeof(CommonConnectorResponse.JsonConverter))]
[Serializable]
public class CommonConnectorResponse
{
    private CommonConnectorResponse(string type, object? value)
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
    /// Factory method to create a union from a Corti.CommonRegistryConnectorProvisioned value.
    /// </summary>
    public static CommonConnectorResponse FromCommonRegistryConnectorProvisioned(
        Corti.CommonRegistryConnectorProvisioned value
    ) => new("commonRegistryConnectorProvisioned", value);

    /// <summary>
    /// Factory method to create a union from a Corti.CommonMcpConnector value.
    /// </summary>
    public static CommonConnectorResponse FromCommonMcpConnector(Corti.CommonMcpConnector value) =>
        new("commonMcpConnector", value);

    /// <summary>
    /// Factory method to create a union from a Corti.CommonAgentConnector value.
    /// </summary>
    public static CommonConnectorResponse FromCommonAgentConnector(
        Corti.CommonAgentConnector value
    ) => new("commonAgentConnector", value);

    /// <summary>
    /// Factory method to create a union from a Corti.CommonA2AConnector value.
    /// </summary>
    public static CommonConnectorResponse FromCommonA2AConnector(Corti.CommonA2AConnector value) =>
        new("commonA2AConnector", value);

    /// <summary>
    /// Factory method to create a union from a Corti.CommonSchemaConnector value.
    /// </summary>
    public static CommonConnectorResponse FromCommonSchemaConnector(
        Corti.CommonSchemaConnector value
    ) => new("commonSchemaConnector", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "commonRegistryConnectorProvisioned"
    /// </summary>
    public bool IsCommonRegistryConnectorProvisioned() =>
        Type == "commonRegistryConnectorProvisioned";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "commonMcpConnector"
    /// </summary>
    public bool IsCommonMcpConnector() => Type == "commonMcpConnector";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "commonAgentConnector"
    /// </summary>
    public bool IsCommonAgentConnector() => Type == "commonAgentConnector";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "commonA2AConnector"
    /// </summary>
    public bool IsCommonA2AConnector() => Type == "commonA2AConnector";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "commonSchemaConnector"
    /// </summary>
    public bool IsCommonSchemaConnector() => Type == "commonSchemaConnector";

    /// <summary>
    /// Returns the value as a <see cref="Corti.CommonRegistryConnectorProvisioned"/> if <see cref="Type"/> is 'commonRegistryConnectorProvisioned', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'commonRegistryConnectorProvisioned'.</exception>
    public Corti.CommonRegistryConnectorProvisioned AsCommonRegistryConnectorProvisioned() =>
        IsCommonRegistryConnectorProvisioned()
            ? (Corti.CommonRegistryConnectorProvisioned)Value!
            : throw new CortiClientException(
                "Union type is not 'commonRegistryConnectorProvisioned'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Corti.CommonMcpConnector"/> if <see cref="Type"/> is 'commonMcpConnector', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'commonMcpConnector'.</exception>
    public Corti.CommonMcpConnector AsCommonMcpConnector() =>
        IsCommonMcpConnector()
            ? (Corti.CommonMcpConnector)Value!
            : throw new CortiClientException("Union type is not 'commonMcpConnector'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.CommonAgentConnector"/> if <see cref="Type"/> is 'commonAgentConnector', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'commonAgentConnector'.</exception>
    public Corti.CommonAgentConnector AsCommonAgentConnector() =>
        IsCommonAgentConnector()
            ? (Corti.CommonAgentConnector)Value!
            : throw new CortiClientException("Union type is not 'commonAgentConnector'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.CommonA2AConnector"/> if <see cref="Type"/> is 'commonA2AConnector', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'commonA2AConnector'.</exception>
    public Corti.CommonA2AConnector AsCommonA2AConnector() =>
        IsCommonA2AConnector()
            ? (Corti.CommonA2AConnector)Value!
            : throw new CortiClientException("Union type is not 'commonA2AConnector'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.CommonSchemaConnector"/> if <see cref="Type"/> is 'commonSchemaConnector', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'commonSchemaConnector'.</exception>
    public Corti.CommonSchemaConnector AsCommonSchemaConnector() =>
        IsCommonSchemaConnector()
            ? (Corti.CommonSchemaConnector)Value!
            : throw new CortiClientException("Union type is not 'commonSchemaConnector'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.CommonRegistryConnectorProvisioned"/> and returns true if successful.
    /// </summary>
    public bool TryGetCommonRegistryConnectorProvisioned(
        out Corti.CommonRegistryConnectorProvisioned? value
    )
    {
        if (Type == "commonRegistryConnectorProvisioned")
        {
            value = (Corti.CommonRegistryConnectorProvisioned)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.CommonMcpConnector"/> and returns true if successful.
    /// </summary>
    public bool TryGetCommonMcpConnector(out Corti.CommonMcpConnector? value)
    {
        if (Type == "commonMcpConnector")
        {
            value = (Corti.CommonMcpConnector)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.CommonAgentConnector"/> and returns true if successful.
    /// </summary>
    public bool TryGetCommonAgentConnector(out Corti.CommonAgentConnector? value)
    {
        if (Type == "commonAgentConnector")
        {
            value = (Corti.CommonAgentConnector)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.CommonA2AConnector"/> and returns true if successful.
    /// </summary>
    public bool TryGetCommonA2AConnector(out Corti.CommonA2AConnector? value)
    {
        if (Type == "commonA2AConnector")
        {
            value = (Corti.CommonA2AConnector)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.CommonSchemaConnector"/> and returns true if successful.
    /// </summary>
    public bool TryGetCommonSchemaConnector(out Corti.CommonSchemaConnector? value)
    {
        if (Type == "commonSchemaConnector")
        {
            value = (Corti.CommonSchemaConnector)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Corti.CommonRegistryConnectorProvisioned, T> onCommonRegistryConnectorProvisioned,
        Func<Corti.CommonMcpConnector, T> onCommonMcpConnector,
        Func<Corti.CommonAgentConnector, T> onCommonAgentConnector,
        Func<Corti.CommonA2AConnector, T> onCommonA2AConnector,
        Func<Corti.CommonSchemaConnector, T> onCommonSchemaConnector
    )
    {
        return Type switch
        {
            "commonRegistryConnectorProvisioned" => onCommonRegistryConnectorProvisioned(
                AsCommonRegistryConnectorProvisioned()
            ),
            "commonMcpConnector" => onCommonMcpConnector(AsCommonMcpConnector()),
            "commonAgentConnector" => onCommonAgentConnector(AsCommonAgentConnector()),
            "commonA2AConnector" => onCommonA2AConnector(AsCommonA2AConnector()),
            "commonSchemaConnector" => onCommonSchemaConnector(AsCommonSchemaConnector()),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Corti.CommonRegistryConnectorProvisioned> onCommonRegistryConnectorProvisioned,
        Action<Corti.CommonMcpConnector> onCommonMcpConnector,
        Action<Corti.CommonAgentConnector> onCommonAgentConnector,
        Action<Corti.CommonA2AConnector> onCommonA2AConnector,
        Action<Corti.CommonSchemaConnector> onCommonSchemaConnector
    )
    {
        switch (Type)
        {
            case "commonRegistryConnectorProvisioned":
                onCommonRegistryConnectorProvisioned(AsCommonRegistryConnectorProvisioned());
                break;
            case "commonMcpConnector":
                onCommonMcpConnector(AsCommonMcpConnector());
                break;
            case "commonAgentConnector":
                onCommonAgentConnector(AsCommonAgentConnector());
                break;
            case "commonA2AConnector":
                onCommonA2AConnector(AsCommonA2AConnector());
                break;
            case "commonSchemaConnector":
                onCommonSchemaConnector(AsCommonSchemaConnector());
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
        if (obj is not CommonConnectorResponse other)
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

    public static implicit operator CommonConnectorResponse(
        Corti.CommonRegistryConnectorProvisioned value
    ) => new("commonRegistryConnectorProvisioned", value);

    public static implicit operator CommonConnectorResponse(Corti.CommonMcpConnector value) =>
        new("commonMcpConnector", value);

    public static implicit operator CommonConnectorResponse(Corti.CommonAgentConnector value) =>
        new("commonAgentConnector", value);

    public static implicit operator CommonConnectorResponse(Corti.CommonA2AConnector value) =>
        new("commonA2AConnector", value);

    public static implicit operator CommonConnectorResponse(Corti.CommonSchemaConnector value) =>
        new("commonSchemaConnector", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CommonConnectorResponse>
    {
        public override CommonConnectorResponse? Read(
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
                        "commonRegistryConnectorProvisioned",
                        typeof(Corti.CommonRegistryConnectorProvisioned)
                    ),
                    ("commonMcpConnector", typeof(Corti.CommonMcpConnector)),
                    ("commonAgentConnector", typeof(Corti.CommonAgentConnector)),
                    ("commonA2AConnector", typeof(Corti.CommonA2AConnector)),
                    ("commonSchemaConnector", typeof(Corti.CommonSchemaConnector)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            CommonConnectorResponse result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into CommonConnectorResponse"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CommonConnectorResponse value,
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

        public override CommonConnectorResponse ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CommonConnectorResponse result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CommonConnectorResponse value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
