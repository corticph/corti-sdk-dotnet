// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

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
    /// Factory method to create a union from a CortiApi.AgentsFileWithUri value.
    /// </summary>
    public static AgentsFilePartFile FromAgentsFileWithUri(CortiApi.AgentsFileWithUri value) =>
        new("agentsFileWithUri", value);

    /// <summary>
    /// Factory method to create a union from a CortiApi.AgentsFileWithBytes value.
    /// </summary>
    public static AgentsFilePartFile FromAgentsFileWithBytes(CortiApi.AgentsFileWithBytes value) =>
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
    /// Returns the value as a <see cref="CortiApi.AgentsFileWithUri"/> if <see cref="Type"/> is 'agentsFileWithUri', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'agentsFileWithUri'.</exception>
    public CortiApi.AgentsFileWithUri AsAgentsFileWithUri() =>
        IsAgentsFileWithUri()
            ? (CortiApi.AgentsFileWithUri)Value!
            : throw new CortiClientException("Union type is not 'agentsFileWithUri'");

    /// <summary>
    /// Returns the value as a <see cref="CortiApi.AgentsFileWithBytes"/> if <see cref="Type"/> is 'agentsFileWithBytes', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'agentsFileWithBytes'.</exception>
    public CortiApi.AgentsFileWithBytes AsAgentsFileWithBytes() =>
        IsAgentsFileWithBytes()
            ? (CortiApi.AgentsFileWithBytes)Value!
            : throw new CortiClientException("Union type is not 'agentsFileWithBytes'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="CortiApi.AgentsFileWithUri"/> and returns true if successful.
    /// </summary>
    public bool TryGetAgentsFileWithUri(out CortiApi.AgentsFileWithUri? value)
    {
        if (Type == "agentsFileWithUri")
        {
            value = (CortiApi.AgentsFileWithUri)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="CortiApi.AgentsFileWithBytes"/> and returns true if successful.
    /// </summary>
    public bool TryGetAgentsFileWithBytes(out CortiApi.AgentsFileWithBytes? value)
    {
        if (Type == "agentsFileWithBytes")
        {
            value = (CortiApi.AgentsFileWithBytes)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<CortiApi.AgentsFileWithUri, T> onAgentsFileWithUri,
        Func<CortiApi.AgentsFileWithBytes, T> onAgentsFileWithBytes
    )
    {
        return Type switch
        {
            "agentsFileWithUri" => onAgentsFileWithUri(AsAgentsFileWithUri()),
            "agentsFileWithBytes" => onAgentsFileWithBytes(AsAgentsFileWithBytes()),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<CortiApi.AgentsFileWithUri> onAgentsFileWithUri,
        Action<CortiApi.AgentsFileWithBytes> onAgentsFileWithBytes
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

    public static implicit operator AgentsFilePartFile(CortiApi.AgentsFileWithUri value) =>
        new("agentsFileWithUri", value);

    public static implicit operator AgentsFilePartFile(CortiApi.AgentsFileWithBytes value) =>
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
                    ("agentsFileWithUri", typeof(CortiApi.AgentsFileWithUri)),
                    ("agentsFileWithBytes", typeof(CortiApi.AgentsFileWithBytes)),
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
