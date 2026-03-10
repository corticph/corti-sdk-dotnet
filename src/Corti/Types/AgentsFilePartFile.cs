// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(AgentsFilePartFile.JsonConverter))]
[Serializable]
public class AgentsFilePartFile
{
    private AgentsFilePartFile(string type, object? value)
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
    /// Factory method to create a union from a Corti.AgentsFileWithUri value.
    /// </summary>
    public static AgentsFilePartFile FromAgentsFileWithUri(Corti.AgentsFileWithUri value) =>
        new("agentsFileWithUri", value);

    /// <summary>
    /// Factory method to create a union from a Corti.AgentsFileWithBytes value.
    /// </summary>
    public static AgentsFilePartFile FromAgentsFileWithBytes(Corti.AgentsFileWithBytes value) =>
        new("agentsFileWithBytes", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "agentsFileWithUri"
    /// </summary>
    public bool IsAgentsFileWithUri() => Type == "agentsFileWithUri";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "agentsFileWithBytes"
    /// </summary>
    public bool IsAgentsFileWithBytes() => Type == "agentsFileWithBytes";

    /// <summary>
    /// Returns the value as a <see cref="Corti.AgentsFileWithUri"/> if <see cref="Type"/> is 'agentsFileWithUri', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientBaseException">Thrown when <see cref="Type"/> is not 'agentsFileWithUri'.</exception>
    public Corti.AgentsFileWithUri AsAgentsFileWithUri() =>
        IsAgentsFileWithUri()
            ? (Corti.AgentsFileWithUri)Value!
            : throw new CortiClientBaseException("Union type is not 'agentsFileWithUri'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.AgentsFileWithBytes"/> if <see cref="Type"/> is 'agentsFileWithBytes', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientBaseException">Thrown when <see cref="Type"/> is not 'agentsFileWithBytes'.</exception>
    public Corti.AgentsFileWithBytes AsAgentsFileWithBytes() =>
        IsAgentsFileWithBytes()
            ? (Corti.AgentsFileWithBytes)Value!
            : throw new CortiClientBaseException("Union type is not 'agentsFileWithBytes'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.AgentsFileWithUri"/> and returns true if successful.
    /// </summary>
    public bool TryGetAgentsFileWithUri(out Corti.AgentsFileWithUri? value)
    {
        if (Type == "agentsFileWithUri")
        {
            value = (Corti.AgentsFileWithUri)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.AgentsFileWithBytes"/> and returns true if successful.
    /// </summary>
    public bool TryGetAgentsFileWithBytes(out Corti.AgentsFileWithBytes? value)
    {
        if (Type == "agentsFileWithBytes")
        {
            value = (Corti.AgentsFileWithBytes)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Corti.AgentsFileWithUri, T> onAgentsFileWithUri,
        Func<Corti.AgentsFileWithBytes, T> onAgentsFileWithBytes
    )
    {
        return Type switch
        {
            "agentsFileWithUri" => onAgentsFileWithUri(AsAgentsFileWithUri()),
            "agentsFileWithBytes" => onAgentsFileWithBytes(AsAgentsFileWithBytes()),
            _ => throw new CortiClientBaseException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Corti.AgentsFileWithUri> onAgentsFileWithUri,
        Action<Corti.AgentsFileWithBytes> onAgentsFileWithBytes
    )
    {
        switch (Type)
        {
            case "agentsFileWithUri":
                onAgentsFileWithUri(AsAgentsFileWithUri());
                break;
            case "agentsFileWithBytes":
                onAgentsFileWithBytes(AsAgentsFileWithBytes());
                break;
            default:
                throw new CortiClientBaseException($"Unknown union type: {Type}");
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
        if (obj is not AgentsFilePartFile other)
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

    public static implicit operator AgentsFilePartFile(Corti.AgentsFileWithUri value) =>
        new("agentsFileWithUri", value);

    public static implicit operator AgentsFilePartFile(Corti.AgentsFileWithBytes value) =>
        new("agentsFileWithBytes", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<AgentsFilePartFile>
    {
        public override AgentsFilePartFile? Read(
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
                    ("agentsFileWithUri", typeof(Corti.AgentsFileWithUri)),
                    ("agentsFileWithBytes", typeof(Corti.AgentsFileWithBytes)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            AgentsFilePartFile result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into AgentsFilePartFile"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentsFilePartFile value,
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

        public override AgentsFilePartFile ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            AgentsFilePartFile result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentsFilePartFile value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
