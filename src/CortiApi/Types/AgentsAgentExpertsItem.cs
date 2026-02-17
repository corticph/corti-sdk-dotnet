// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(AgentsAgentExpertsItem.JsonConverter))]
[Serializable]
public class AgentsAgentExpertsItem
{
    private AgentsAgentExpertsItem(string type, object? value)
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
    /// Factory method to create a union from a CortiApi.AgentsExpert value.
    /// </summary>
    public static AgentsAgentExpertsItem FromAgentsExpert(CortiApi.AgentsExpert value) =>
        new("agentsExpert", value);

    /// <summary>
    /// Factory method to create a union from a CortiApi.AgentsExpertReference value.
    /// </summary>
    public static AgentsAgentExpertsItem FromAgentsExpertReference(
        CortiApi.AgentsExpertReference value
    ) => new("agentsExpertReference", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "agentsExpert"
    /// </summary>
    public bool IsAgentsExpert() => Type == "agentsExpert";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "agentsExpertReference"
    /// </summary>
    public bool IsAgentsExpertReference() => Type == "agentsExpertReference";

    /// <summary>
    /// Returns the value as a <see cref="CortiApi.AgentsExpert"/> if <see cref="Type"/> is 'agentsExpert', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'agentsExpert'.</exception>
    public CortiApi.AgentsExpert AsAgentsExpert() =>
        IsAgentsExpert()
            ? (CortiApi.AgentsExpert)Value!
            : throw new CortiClientException("Union type is not 'agentsExpert'");

    /// <summary>
    /// Returns the value as a <see cref="CortiApi.AgentsExpertReference"/> if <see cref="Type"/> is 'agentsExpertReference', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'agentsExpertReference'.</exception>
    public CortiApi.AgentsExpertReference AsAgentsExpertReference() =>
        IsAgentsExpertReference()
            ? (CortiApi.AgentsExpertReference)Value!
            : throw new CortiClientException("Union type is not 'agentsExpertReference'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="CortiApi.AgentsExpert"/> and returns true if successful.
    /// </summary>
    public bool TryGetAgentsExpert(out CortiApi.AgentsExpert? value)
    {
        if (Type == "agentsExpert")
        {
            value = (CortiApi.AgentsExpert)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="CortiApi.AgentsExpertReference"/> and returns true if successful.
    /// </summary>
    public bool TryGetAgentsExpertReference(out CortiApi.AgentsExpertReference? value)
    {
        if (Type == "agentsExpertReference")
        {
            value = (CortiApi.AgentsExpertReference)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<CortiApi.AgentsExpert, T> onAgentsExpert,
        Func<CortiApi.AgentsExpertReference, T> onAgentsExpertReference
    )
    {
        return Type switch
        {
            "agentsExpert" => onAgentsExpert(AsAgentsExpert()),
            "agentsExpertReference" => onAgentsExpertReference(AsAgentsExpertReference()),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<CortiApi.AgentsExpert> onAgentsExpert,
        Action<CortiApi.AgentsExpertReference> onAgentsExpertReference
    )
    {
        switch (Type)
        {
            case "agentsExpert":
                onAgentsExpert(AsAgentsExpert());
                break;
            case "agentsExpertReference":
                onAgentsExpertReference(AsAgentsExpertReference());
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
        if (obj is not AgentsAgentExpertsItem other)
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

    public static implicit operator AgentsAgentExpertsItem(CortiApi.AgentsExpert value) =>
        new("agentsExpert", value);

    public static implicit operator AgentsAgentExpertsItem(CortiApi.AgentsExpertReference value) =>
        new("agentsExpertReference", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<AgentsAgentExpertsItem>
    {
        public override AgentsAgentExpertsItem? Read(
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
                    ("agentsExpert", typeof(CortiApi.AgentsExpert)),
                    ("agentsExpertReference", typeof(CortiApi.AgentsExpertReference)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            AgentsAgentExpertsItem result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into AgentsAgentExpertsItem"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentsAgentExpertsItem value,
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

        public override AgentsAgentExpertsItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            AgentsAgentExpertsItem result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentsAgentExpertsItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
