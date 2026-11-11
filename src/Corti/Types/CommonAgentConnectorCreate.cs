// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Request body for attaching an agent connector, either an inline agent reference or a registry entry of type `agent`. Exactly one of `agentId` or the `registry` reference must be present; sending both, or neither, is rejected with `400`. For `agent`-type registry connectors, the entry's `payload.systemPrompt` is required and always exposed by the API.
/// </summary>
[JsonConverter(typeof(CommonAgentConnectorCreate.JsonConverter))]
[Serializable]
public class CommonAgentConnectorCreate
{
    private CommonAgentConnectorCreate(string type, object? value)
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
    /// Factory method to create a union from a object value.
    /// </summary>
    public static CommonAgentConnectorCreate FromUnknown(object value) => new("unknown", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "unknown"
    /// </summary>
    public bool IsUnknown() => Type == "unknown";

    /// <summary>
    /// Returns the value as a <see cref="object"/> if <see cref="Type"/> is 'unknown', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'unknown'.</exception>
    public object AsUnknown() =>
        IsUnknown() ? Value! : throw new CortiClientException("Union type is not 'unknown'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="object"/> and returns true if successful.
    /// </summary>
    public bool TryGetUnknown(out object? value)
    {
        if (Type == "unknown")
        {
            value = Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(Func<object, T> onUnknown)
    {
        return Type switch
        {
            "unknown" => onUnknown(AsUnknown()),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(Action<object> onUnknown)
    {
        switch (Type)
        {
            case "unknown":
                onUnknown(AsUnknown());
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
        if (obj is not CommonAgentConnectorCreate other)
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

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CommonAgentConnectorCreate>
    {
        public override CommonAgentConnectorCreate? Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into CommonAgentConnectorCreate"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CommonAgentConnectorCreate value,
            JsonSerializerOptions options
        )
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            value.Visit(obj => JsonSerializer.Serialize(writer, obj, options));
        }

        public override CommonAgentConnectorCreate ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CommonAgentConnectorCreate result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CommonAgentConnectorCreate value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
