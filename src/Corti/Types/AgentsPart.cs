// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

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
    /// Factory method to create a union from a Corti.AgentsTextPart value.
    /// </summary>
    public static AgentsPart FromAgentsTextPart(Corti.AgentsTextPart value) =>
        new("agentsTextPart", value);

    /// <summary>
    /// Factory method to create a union from a Corti.AgentsFilePart value.
    /// </summary>
    public static AgentsPart FromAgentsFilePart(Corti.AgentsFilePart value) =>
        new("agentsFilePart", value);

    /// <summary>
    /// Factory method to create a union from a Corti.AgentsDataPart value.
    /// </summary>
    public static AgentsPart FromAgentsDataPart(Corti.AgentsDataPart value) =>
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
    /// Returns the value as a <see cref="Corti.AgentsTextPart"/> if <see cref="Type"/> is 'agentsTextPart', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'agentsTextPart'.</exception>
    public Corti.AgentsTextPart AsAgentsTextPart() =>
        IsAgentsTextPart()
            ? (Corti.AgentsTextPart)Value!
            : throw new CortiClientException("Union type is not 'agentsTextPart'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.AgentsFilePart"/> if <see cref="Type"/> is 'agentsFilePart', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'agentsFilePart'.</exception>
    public Corti.AgentsFilePart AsAgentsFilePart() =>
        IsAgentsFilePart()
            ? (Corti.AgentsFilePart)Value!
            : throw new CortiClientException("Union type is not 'agentsFilePart'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.AgentsDataPart"/> if <see cref="Type"/> is 'agentsDataPart', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'agentsDataPart'.</exception>
    public Corti.AgentsDataPart AsAgentsDataPart() =>
        IsAgentsDataPart()
            ? (Corti.AgentsDataPart)Value!
            : throw new CortiClientException("Union type is not 'agentsDataPart'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.AgentsTextPart"/> and returns true if successful.
    /// </summary>
    public bool TryGetAgentsTextPart(out Corti.AgentsTextPart? value)
    {
        if (Type == "agentsTextPart")
        {
            value = (Corti.AgentsTextPart)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.AgentsFilePart"/> and returns true if successful.
    /// </summary>
    public bool TryGetAgentsFilePart(out Corti.AgentsFilePart? value)
    {
        if (Type == "agentsFilePart")
        {
            value = (Corti.AgentsFilePart)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.AgentsDataPart"/> and returns true if successful.
    /// </summary>
    public bool TryGetAgentsDataPart(out Corti.AgentsDataPart? value)
    {
        if (Type == "agentsDataPart")
        {
            value = (Corti.AgentsDataPart)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Corti.AgentsTextPart, T> onAgentsTextPart,
        Func<Corti.AgentsFilePart, T> onAgentsFilePart,
        Func<Corti.AgentsDataPart, T> onAgentsDataPart
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
        Action<Corti.AgentsTextPart> onAgentsTextPart,
        Action<Corti.AgentsFilePart> onAgentsFilePart,
        Action<Corti.AgentsDataPart> onAgentsDataPart
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

    public static implicit operator AgentsPart(Corti.AgentsTextPart value) =>
        new("agentsTextPart", value);

    public static implicit operator AgentsPart(Corti.AgentsFilePart value) =>
        new("agentsFilePart", value);

    public static implicit operator AgentsPart(Corti.AgentsDataPart value) =>
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
                    ("agentsTextPart", typeof(Corti.AgentsTextPart)),
                    ("agentsFilePart", typeof(Corti.AgentsFilePart)),
                    ("agentsDataPart", typeof(Corti.AgentsDataPart)),
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
