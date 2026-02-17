// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(AgentsAgentResponse.JsonConverter))]
[Serializable]
public class AgentsAgentResponse
{
    private AgentsAgentResponse(string type, object? value)
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
    /// Factory method to create a union from a CortiApi.AgentsAgent value.
    /// </summary>
    public static AgentsAgentResponse FromAgentsAgent(CortiApi.AgentsAgent value) =>
        new("agentsAgent", value);

    /// <summary>
    /// Factory method to create a union from a CortiApi.AgentsAgentReference value.
    /// </summary>
    public static AgentsAgentResponse FromAgentsAgentReference(
        CortiApi.AgentsAgentReference value
    ) => new("agentsAgentReference", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "agentsAgent"
    /// </summary>
    public bool IsAgentsAgent() => Type == "agentsAgent";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "agentsAgentReference"
    /// </summary>
    public bool IsAgentsAgentReference() => Type == "agentsAgentReference";

    /// <summary>
    /// Returns the value as a <see cref="CortiApi.AgentsAgent"/> if <see cref="Type"/> is 'agentsAgent', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'agentsAgent'.</exception>
    public CortiApi.AgentsAgent AsAgentsAgent() =>
        IsAgentsAgent()
            ? (CortiApi.AgentsAgent)Value!
            : throw new CortiClientException("Union type is not 'agentsAgent'");

    /// <summary>
    /// Returns the value as a <see cref="CortiApi.AgentsAgentReference"/> if <see cref="Type"/> is 'agentsAgentReference', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'agentsAgentReference'.</exception>
    public CortiApi.AgentsAgentReference AsAgentsAgentReference() =>
        IsAgentsAgentReference()
            ? (CortiApi.AgentsAgentReference)Value!
            : throw new CortiClientException("Union type is not 'agentsAgentReference'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="CortiApi.AgentsAgent"/> and returns true if successful.
    /// </summary>
    public bool TryGetAgentsAgent(out CortiApi.AgentsAgent? value)
    {
        if (Type == "agentsAgent")
        {
            value = (CortiApi.AgentsAgent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="CortiApi.AgentsAgentReference"/> and returns true if successful.
    /// </summary>
    public bool TryGetAgentsAgentReference(out CortiApi.AgentsAgentReference? value)
    {
        if (Type == "agentsAgentReference")
        {
            value = (CortiApi.AgentsAgentReference)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<CortiApi.AgentsAgent, T> onAgentsAgent,
        Func<CortiApi.AgentsAgentReference, T> onAgentsAgentReference
    )
    {
        return Type switch
        {
            "agentsAgent" => onAgentsAgent(AsAgentsAgent()),
            "agentsAgentReference" => onAgentsAgentReference(AsAgentsAgentReference()),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<CortiApi.AgentsAgent> onAgentsAgent,
        Action<CortiApi.AgentsAgentReference> onAgentsAgentReference
    )
    {
        switch (Type)
        {
            case "agentsAgent":
                onAgentsAgent(AsAgentsAgent());
                break;
            case "agentsAgentReference":
                onAgentsAgentReference(AsAgentsAgentReference());
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
        if (obj is not AgentsAgentResponse other)
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

    public static implicit operator AgentsAgentResponse(CortiApi.AgentsAgent value) =>
        new("agentsAgent", value);

    public static implicit operator AgentsAgentResponse(CortiApi.AgentsAgentReference value) =>
        new("agentsAgentReference", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<AgentsAgentResponse>
    {
        public override AgentsAgentResponse? Read(
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
                    ("agentsAgent", typeof(CortiApi.AgentsAgent)),
                    ("agentsAgentReference", typeof(CortiApi.AgentsAgentReference)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            AgentsAgentResponse result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into AgentsAgentResponse"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentsAgentResponse value,
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

        public override AgentsAgentResponse ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            AgentsAgentResponse result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentsAgentResponse value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
