// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(AgentsUpdateAgentExpertsItem.JsonConverter))]
[Serializable]
public class AgentsUpdateAgentExpertsItem
{
    private AgentsUpdateAgentExpertsItem(string type, object? value)
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
    /// Factory method to create a union from a Corti.AgentsCreateExpert value.
    /// </summary>
    public static AgentsUpdateAgentExpertsItem FromAgentsCreateExpert(
        Corti.AgentsCreateExpert value
    ) => new("agentsCreateExpert", value);

    /// <summary>
    /// Factory method to create a union from a Corti.AgentsCreateExpertReference value.
    /// </summary>
    public static AgentsUpdateAgentExpertsItem FromAgentsCreateExpertReference(
        Corti.AgentsCreateExpertReference value
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
    /// Returns the value as a <see cref="Corti.AgentsCreateExpert"/> if <see cref="Type"/> is 'agentsCreateExpert', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'agentsCreateExpert'.</exception>
    public Corti.AgentsCreateExpert AsAgentsCreateExpert() =>
        IsAgentsCreateExpert()
            ? (Corti.AgentsCreateExpert)Value!
            : throw new CortiClientException("Union type is not 'agentsCreateExpert'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.AgentsCreateExpertReference"/> if <see cref="Type"/> is 'agentsCreateExpertReference', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'agentsCreateExpertReference'.</exception>
    public Corti.AgentsCreateExpertReference AsAgentsCreateExpertReference() =>
        IsAgentsCreateExpertReference()
            ? (Corti.AgentsCreateExpertReference)Value!
            : throw new CortiClientException("Union type is not 'agentsCreateExpertReference'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.AgentsCreateExpert"/> and returns true if successful.
    /// </summary>
    public bool TryGetAgentsCreateExpert(out Corti.AgentsCreateExpert? value)
    {
        if (Type == "agentsCreateExpert")
        {
            value = (Corti.AgentsCreateExpert)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.AgentsCreateExpertReference"/> and returns true if successful.
    /// </summary>
    public bool TryGetAgentsCreateExpertReference(out Corti.AgentsCreateExpertReference? value)
    {
        if (Type == "agentsCreateExpertReference")
        {
            value = (Corti.AgentsCreateExpertReference)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Corti.AgentsCreateExpert, T> onAgentsCreateExpert,
        Func<Corti.AgentsCreateExpertReference, T> onAgentsCreateExpertReference
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
        Action<Corti.AgentsCreateExpert> onAgentsCreateExpert,
        Action<Corti.AgentsCreateExpertReference> onAgentsCreateExpertReference
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
        if (obj is not AgentsUpdateAgentExpertsItem other)
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

    public static implicit operator AgentsUpdateAgentExpertsItem(Corti.AgentsCreateExpert value) =>
        new("agentsCreateExpert", value);

    public static implicit operator AgentsUpdateAgentExpertsItem(
        Corti.AgentsCreateExpertReference value
    ) => new("agentsCreateExpertReference", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<AgentsUpdateAgentExpertsItem>
    {
        public override AgentsUpdateAgentExpertsItem? Read(
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
                    ("agentsCreateExpert", typeof(Corti.AgentsCreateExpert)),
                    ("agentsCreateExpertReference", typeof(Corti.AgentsCreateExpertReference)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            AgentsUpdateAgentExpertsItem result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into AgentsUpdateAgentExpertsItem"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentsUpdateAgentExpertsItem value,
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

        public override AgentsUpdateAgentExpertsItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            AgentsUpdateAgentExpertsItem result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentsUpdateAgentExpertsItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
