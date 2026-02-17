// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(AgentsCreateAgentExpertsItem.JsonConverter))]
[Serializable]
public class AgentsCreateAgentExpertsItem
{
    private AgentsCreateAgentExpertsItem(string type, object? value)
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
    /// Factory method to create a union from a CortiApi.AgentsCreateExpert value.
    /// </summary>
    public static AgentsCreateAgentExpertsItem FromAgentsCreateExpert(
        CortiApi.AgentsCreateExpert value
    ) => new("agentsCreateExpert", value);

    /// <summary>
    /// Factory method to create a union from a CortiApi.AgentsCreateExpertReference value.
    /// </summary>
    public static AgentsCreateAgentExpertsItem FromAgentsCreateExpertReference(
        CortiApi.AgentsCreateExpertReference value
    ) => new("agentsCreateExpertReference", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "agentsCreateExpert"
    /// </summary>
    public bool IsAgentsCreateExpert() => Type == "agentsCreateExpert";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "agentsCreateExpertReference"
    /// </summary>
    public bool IsAgentsCreateExpertReference() => Type == "agentsCreateExpertReference";

    /// <summary>
    /// Returns the value as a <see cref="CortiApi.AgentsCreateExpert"/> if <see cref="Type"/> is 'agentsCreateExpert', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'agentsCreateExpert'.</exception>
    public CortiApi.AgentsCreateExpert AsAgentsCreateExpert() =>
        IsAgentsCreateExpert()
            ? (CortiApi.AgentsCreateExpert)Value!
            : throw new CortiClientException("Union type is not 'agentsCreateExpert'");

    /// <summary>
    /// Returns the value as a <see cref="CortiApi.AgentsCreateExpertReference"/> if <see cref="Type"/> is 'agentsCreateExpertReference', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'agentsCreateExpertReference'.</exception>
    public CortiApi.AgentsCreateExpertReference AsAgentsCreateExpertReference() =>
        IsAgentsCreateExpertReference()
            ? (CortiApi.AgentsCreateExpertReference)Value!
            : throw new CortiClientException("Union type is not 'agentsCreateExpertReference'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="CortiApi.AgentsCreateExpert"/> and returns true if successful.
    /// </summary>
    public bool TryGetAgentsCreateExpert(out CortiApi.AgentsCreateExpert? value)
    {
        if (Type == "agentsCreateExpert")
        {
            value = (CortiApi.AgentsCreateExpert)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="CortiApi.AgentsCreateExpertReference"/> and returns true if successful.
    /// </summary>
    public bool TryGetAgentsCreateExpertReference(out CortiApi.AgentsCreateExpertReference? value)
    {
        if (Type == "agentsCreateExpertReference")
        {
            value = (CortiApi.AgentsCreateExpertReference)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<CortiApi.AgentsCreateExpert, T> onAgentsCreateExpert,
        Func<CortiApi.AgentsCreateExpertReference, T> onAgentsCreateExpertReference
    )
    {
        return Type switch
        {
            "agentsCreateExpert" => onAgentsCreateExpert(AsAgentsCreateExpert()),
            "agentsCreateExpertReference" => onAgentsCreateExpertReference(
                AsAgentsCreateExpertReference()
            ),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<CortiApi.AgentsCreateExpert> onAgentsCreateExpert,
        Action<CortiApi.AgentsCreateExpertReference> onAgentsCreateExpertReference
    )
    {
        switch (Type)
        {
            case "agentsCreateExpert":
                onAgentsCreateExpert(AsAgentsCreateExpert());
                break;
            case "agentsCreateExpertReference":
                onAgentsCreateExpertReference(AsAgentsCreateExpertReference());
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
        if (obj is not AgentsCreateAgentExpertsItem other)
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

    public static implicit operator AgentsCreateAgentExpertsItem(
        CortiApi.AgentsCreateExpert value
    ) => new("agentsCreateExpert", value);

    public static implicit operator AgentsCreateAgentExpertsItem(
        CortiApi.AgentsCreateExpertReference value
    ) => new("agentsCreateExpertReference", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<AgentsCreateAgentExpertsItem>
    {
        public override AgentsCreateAgentExpertsItem? Read(
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
                    ("agentsCreateExpert", typeof(CortiApi.AgentsCreateExpert)),
                    ("agentsCreateExpertReference", typeof(CortiApi.AgentsCreateExpertReference)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            AgentsCreateAgentExpertsItem result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into AgentsCreateAgentExpertsItem"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentsCreateAgentExpertsItem value,
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

        public override AgentsCreateAgentExpertsItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            AgentsCreateAgentExpertsItem result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentsCreateAgentExpertsItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
