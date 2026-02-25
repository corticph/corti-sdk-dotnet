// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(AgentsContextItemsItem.JsonConverter))]
[Serializable]
public record AgentsContextItemsItem
{
    internal AgentsContextItemsItem(string type, object? value)
    {
        Kind = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of AgentsContextItemsItem with <see cref="AgentsContextItemsItem.Task"/>.
    /// </summary>
    public AgentsContextItemsItem(AgentsContextItemsItem.Task value)
    {
        Kind = "task";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AgentsContextItemsItem with <see cref="AgentsContextItemsItem.Message"/>.
    /// </summary>
    public AgentsContextItemsItem(AgentsContextItemsItem.Message value)
    {
        Kind = "message";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("kind")]
    public string Kind { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Kind"/> is "task"
    /// </summary>
    public bool IsTask => Kind == "task";

    /// <summary>
    /// Returns true if <see cref="Kind"/> is "message"
    /// </summary>
    public bool IsMessage => Kind == "message";

    /// <summary>
    /// Returns the value as a <see cref="CortiApi.AgentsTask"/> if <see cref="Kind"/> is 'task', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'task'.</exception>
    public CortiApi.AgentsTask AsTask() =>
        IsTask
            ? (CortiApi.AgentsTask)Value!
            : throw new System.Exception("AgentsContextItemsItem.Kind is not 'task'");

    /// <summary>
    /// Returns the value as a <see cref="CortiApi.AgentsMessage"/> if <see cref="Kind"/> is 'message', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'message'.</exception>
    public CortiApi.AgentsMessage AsMessage() =>
        IsMessage
            ? (CortiApi.AgentsMessage)Value!
            : throw new System.Exception("AgentsContextItemsItem.Kind is not 'message'");

    public T Match<T>(
        Func<CortiApi.AgentsTask, T> onTask,
        Func<CortiApi.AgentsMessage, T> onMessage,
        Func<string, object?, T> onUnknown_
    )
    {
        return Kind switch
        {
            "task" => onTask(AsTask()),
            "message" => onMessage(AsMessage()),
            _ => onUnknown_(Kind, Value),
        };
    }

    public void Visit(
        Action<CortiApi.AgentsTask> onTask,
        Action<CortiApi.AgentsMessage> onMessage,
        Action<string, object?> onUnknown_
    )
    {
        switch (Kind)
        {
            case "task":
                onTask(AsTask());
                break;
            case "message":
                onMessage(AsMessage());
                break;
            default:
                onUnknown_(Kind, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="CortiApi.AgentsTask"/> and returns true if successful.
    /// </summary>
    public bool TryAsTask(out CortiApi.AgentsTask? value)
    {
        if (Kind == "task")
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
    public bool TryAsMessage(out CortiApi.AgentsMessage? value)
    {
        if (Kind == "message")
        {
            value = (CortiApi.AgentsMessage)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator AgentsContextItemsItem(AgentsContextItemsItem.Task value) =>
        new(value);

    public static implicit operator AgentsContextItemsItem(AgentsContextItemsItem.Message value) =>
        new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<AgentsContextItemsItem>
    {
        public override bool CanConvert(System.Type typeToConvert) =>
            typeof(AgentsContextItemsItem).IsAssignableFrom(typeToConvert);

        public override AgentsContextItemsItem Read(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("kind", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'kind'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'kind' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'kind' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'kind' is null");

            var value = discriminator switch
            {
                "task" => json.Deserialize<CortiApi.AgentsTask?>(options)
                    ?? throw new JsonException("Failed to deserialize CortiApi.AgentsTask"),
                "message" => json.Deserialize<CortiApi.AgentsMessage?>(options)
                    ?? throw new JsonException("Failed to deserialize CortiApi.AgentsMessage"),
                _ => json.Deserialize<object?>(options),
            };
            return new AgentsContextItemsItem(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentsContextItemsItem value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Kind switch
                {
                    "task" => JsonSerializer.SerializeToNode(value.Value, options),
                    "message" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["kind"] = value.Kind;
            json.WriteTo(writer, options);
        }
    }

    /// <summary>
    /// Discriminated union type for task
    /// </summary>
    [Serializable]
    public struct Task
    {
        public Task(CortiApi.AgentsTask value)
        {
            Value = value;
        }

        internal CortiApi.AgentsTask Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentsContextItemsItem.Task(CortiApi.AgentsTask value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for message
    /// </summary>
    [Serializable]
    public struct Message
    {
        public Message(CortiApi.AgentsMessage value)
        {
            Value = value;
        }

        internal CortiApi.AgentsMessage Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentsContextItemsItem.Message(
            CortiApi.AgentsMessage value
        ) => new(value);
    }
}
