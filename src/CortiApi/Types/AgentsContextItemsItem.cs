// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(AgentsContextItemsItem.JsonConverter))]
[Serializable]
public class AgentsContextItemsItem
{
    private AgentsContextItemsItem(string type, object? value)
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
    /// Factory method to create a union from a CortiApi.AgentsTask value.
    /// </summary>
    public static AgentsContextItemsItem FromAgentsTask(CortiApi.AgentsTask value) =>
        new("agentsTask", value);

    /// <summary>
    /// Factory method to create a union from a CortiApi.AgentsMessage value.
    /// </summary>
    public static AgentsContextItemsItem FromAgentsMessage(CortiApi.AgentsMessage value) =>
        new("agentsMessage", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "agentsTask"
    /// </summary>
    public bool IsAgentsTask() => Type == "agentsTask";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "agentsMessage"
    /// </summary>
    public bool IsAgentsMessage() => Type == "agentsMessage";

    /// <summary>
    /// Returns the value as a <see cref="CortiApi.AgentsTask"/> if <see cref="Type"/> is 'agentsTask', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'agentsTask'.</exception>
    public CortiApi.AgentsTask AsAgentsTask() =>
        IsAgentsTask()
            ? (CortiApi.AgentsTask)Value!
            : throw new CortiClientException("Union type is not 'agentsTask'");

    /// <summary>
    /// Returns the value as a <see cref="CortiApi.AgentsMessage"/> if <see cref="Type"/> is 'agentsMessage', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'agentsMessage'.</exception>
    public CortiApi.AgentsMessage AsAgentsMessage() =>
        IsAgentsMessage()
            ? (CortiApi.AgentsMessage)Value!
            : throw new CortiClientException("Union type is not 'agentsMessage'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="CortiApi.AgentsTask"/> and returns true if successful.
    /// </summary>
    public bool TryGetAgentsTask(out CortiApi.AgentsTask? value)
    {
        if (Type == "agentsTask")
        {
            value = (CortiApi.AgentsTask)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="CortiApi.AgentsMessage"/> and returns true if successful.
    /// </summary>
    public bool TryGetAgentsMessage(out CortiApi.AgentsMessage? value)
    {
        if (Type == "agentsMessage")
        {
            value = (CortiApi.AgentsMessage)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<CortiApi.AgentsTask, T> onAgentsTask,
        Func<CortiApi.AgentsMessage, T> onAgentsMessage
    )
    {
        return Type switch
        {
            "agentsTask" => onAgentsTask(AsAgentsTask()),
            "agentsMessage" => onAgentsMessage(AsAgentsMessage()),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<CortiApi.AgentsTask> onAgentsTask,
        Action<CortiApi.AgentsMessage> onAgentsMessage
    )
    {
        switch (Type)
        {
            case "agentsTask":
                onAgentsTask(AsAgentsTask());
                break;
            case "agentsMessage":
                onAgentsMessage(AsAgentsMessage());
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
        if (obj is not AgentsContextItemsItem other)
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

    public static implicit operator AgentsContextItemsItem(CortiApi.AgentsTask value) =>
        new("agentsTask", value);

    public static implicit operator AgentsContextItemsItem(CortiApi.AgentsMessage value) =>
        new("agentsMessage", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<AgentsContextItemsItem>
    {
        public override AgentsContextItemsItem? Read(
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
                    ("agentsTask", typeof(CortiApi.AgentsTask)),
                    ("agentsMessage", typeof(CortiApi.AgentsMessage)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            AgentsContextItemsItem result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into AgentsContextItemsItem"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentsContextItemsItem value,
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

        public override AgentsContextItemsItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            AgentsContextItemsItem result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentsContextItemsItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
