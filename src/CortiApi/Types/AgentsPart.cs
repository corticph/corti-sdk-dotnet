// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(AgentsPart.JsonConverter))]
[Serializable]
public class AgentsPart
{
    private AgentsPart(string type, object? value)
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
    /// Factory method to create a union from a CortiApi.AgentsTextPart value.
    /// </summary>
    public static AgentsPart FromAgentsTextPart(CortiApi.AgentsTextPart value) =>
        new("agentsTextPart", value);

    /// <summary>
    /// Factory method to create a union from a CortiApi.AgentsFilePart value.
    /// </summary>
    public static AgentsPart FromAgentsFilePart(CortiApi.AgentsFilePart value) =>
        new("agentsFilePart", value);

    /// <summary>
    /// Factory method to create a union from a CortiApi.AgentsDataPart value.
    /// </summary>
    public static AgentsPart FromAgentsDataPart(CortiApi.AgentsDataPart value) =>
        new("agentsDataPart", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "agentsTextPart"
    /// </summary>
    public bool IsAgentsTextPart() => Type == "agentsTextPart";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "agentsFilePart"
    /// </summary>
    public bool IsAgentsFilePart() => Type == "agentsFilePart";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "agentsDataPart"
    /// </summary>
    public bool IsAgentsDataPart() => Type == "agentsDataPart";

    /// <summary>
    /// Returns the value as a <see cref="CortiApi.AgentsTextPart"/> if <see cref="Type"/> is 'agentsTextPart', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'agentsTextPart'.</exception>
    public CortiApi.AgentsTextPart AsAgentsTextPart() =>
        IsAgentsTextPart()
            ? (CortiApi.AgentsTextPart)Value!
            : throw new CortiClientException("Union type is not 'agentsTextPart'");

    /// <summary>
    /// Returns the value as a <see cref="CortiApi.AgentsFilePart"/> if <see cref="Type"/> is 'agentsFilePart', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'agentsFilePart'.</exception>
    public CortiApi.AgentsFilePart AsAgentsFilePart() =>
        IsAgentsFilePart()
            ? (CortiApi.AgentsFilePart)Value!
            : throw new CortiClientException("Union type is not 'agentsFilePart'");

    /// <summary>
    /// Returns the value as a <see cref="CortiApi.AgentsDataPart"/> if <see cref="Type"/> is 'agentsDataPart', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'agentsDataPart'.</exception>
    public CortiApi.AgentsDataPart AsAgentsDataPart() =>
        IsAgentsDataPart()
            ? (CortiApi.AgentsDataPart)Value!
            : throw new CortiClientException("Union type is not 'agentsDataPart'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="CortiApi.AgentsTextPart"/> and returns true if successful.
    /// </summary>
    public bool TryGetAgentsTextPart(out CortiApi.AgentsTextPart? value)
    {
        if (Type == "agentsTextPart")
        {
            value = (CortiApi.AgentsTextPart)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="CortiApi.AgentsFilePart"/> and returns true if successful.
    /// </summary>
    public bool TryGetAgentsFilePart(out CortiApi.AgentsFilePart? value)
    {
        if (Type == "agentsFilePart")
        {
            value = (CortiApi.AgentsFilePart)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="CortiApi.AgentsDataPart"/> and returns true if successful.
    /// </summary>
    public bool TryGetAgentsDataPart(out CortiApi.AgentsDataPart? value)
    {
        if (Type == "agentsDataPart")
        {
            value = (CortiApi.AgentsDataPart)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<CortiApi.AgentsTextPart, T> onAgentsTextPart,
        Func<CortiApi.AgentsFilePart, T> onAgentsFilePart,
        Func<CortiApi.AgentsDataPart, T> onAgentsDataPart
    )
    {
        return Type switch
        {
            "agentsTextPart" => onAgentsTextPart(AsAgentsTextPart()),
            "agentsFilePart" => onAgentsFilePart(AsAgentsFilePart()),
            "agentsDataPart" => onAgentsDataPart(AsAgentsDataPart()),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<CortiApi.AgentsTextPart> onAgentsTextPart,
        Action<CortiApi.AgentsFilePart> onAgentsFilePart,
        Action<CortiApi.AgentsDataPart> onAgentsDataPart
    )
    {
        switch (Type)
        {
            case "agentsTextPart":
                onAgentsTextPart(AsAgentsTextPart());
                break;
            case "agentsFilePart":
                onAgentsFilePart(AsAgentsFilePart());
                break;
            case "agentsDataPart":
                onAgentsDataPart(AsAgentsDataPart());
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
        if (obj is not AgentsPart other)
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

    public static implicit operator AgentsPart(CortiApi.AgentsTextPart value) =>
        new("agentsTextPart", value);

    public static implicit operator AgentsPart(CortiApi.AgentsFilePart value) =>
        new("agentsFilePart", value);

    public static implicit operator AgentsPart(CortiApi.AgentsDataPart value) =>
        new("agentsDataPart", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<AgentsPart>
    {
        public override AgentsPart? Read(
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
                    ("agentsTextPart", typeof(CortiApi.AgentsTextPart)),
                    ("agentsFilePart", typeof(CortiApi.AgentsFilePart)),
                    ("agentsDataPart", typeof(CortiApi.AgentsDataPart)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            AgentsPart result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into AgentsPart"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentsPart value,
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
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override AgentsPart ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            AgentsPart result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentsPart value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
