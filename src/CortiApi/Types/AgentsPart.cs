// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(AgentsPart.JsonConverter))]
[Serializable]
public record AgentsPart
{
    internal AgentsPart(string type, object? value)
    {
        Kind = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of AgentsPart with <see cref="AgentsPart.Text"/>.
    /// </summary>
    public AgentsPart(AgentsPart.Text value)
    {
        Kind = "text";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AgentsPart with <see cref="AgentsPart.File"/>.
    /// </summary>
    public AgentsPart(AgentsPart.File value)
    {
        Kind = "file";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AgentsPart with <see cref="AgentsPart.Data"/>.
    /// </summary>
    public AgentsPart(AgentsPart.Data value)
    {
        Kind = "data";
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
    /// Returns true if <see cref="Kind"/> is "text"
    /// </summary>
    public bool IsText => Kind == "text";

    /// <summary>
    /// Returns true if <see cref="Kind"/> is "file"
    /// </summary>
    public bool IsFile => Kind == "file";

    /// <summary>
    /// Returns true if <see cref="Kind"/> is "data"
    /// </summary>
    public bool IsData => Kind == "data";

    /// <summary>
    /// Returns the value as a <see cref="CortiApi.AgentsTextPart"/> if <see cref="Kind"/> is 'text', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'text'.</exception>
    public CortiApi.AgentsTextPart AsText() =>
        IsText
            ? (CortiApi.AgentsTextPart)Value!
            : throw new System.Exception("AgentsPart.Kind is not 'text'");

    /// <summary>
    /// Returns the value as a <see cref="CortiApi.AgentsFilePart"/> if <see cref="Kind"/> is 'file', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'file'.</exception>
    public CortiApi.AgentsFilePart AsFile() =>
        IsFile
            ? (CortiApi.AgentsFilePart)Value!
            : throw new System.Exception("AgentsPart.Kind is not 'file'");

    /// <summary>
    /// Returns the value as a <see cref="CortiApi.AgentsDataPart"/> if <see cref="Kind"/> is 'data', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'data'.</exception>
    public CortiApi.AgentsDataPart AsData() =>
        IsData
            ? (CortiApi.AgentsDataPart)Value!
            : throw new System.Exception("AgentsPart.Kind is not 'data'");

    public T Match<T>(
        Func<CortiApi.AgentsTextPart, T> onText,
        Func<CortiApi.AgentsFilePart, T> onFile,
        Func<CortiApi.AgentsDataPart, T> onData,
        Func<string, object?, T> onUnknown_
    )
    {
        return Kind switch
        {
            "text" => onText(AsText()),
            "file" => onFile(AsFile()),
            "data" => onData(AsData()),
            _ => onUnknown_(Kind, Value),
        };
    }

    public void Visit(
        Action<CortiApi.AgentsTextPart> onText,
        Action<CortiApi.AgentsFilePart> onFile,
        Action<CortiApi.AgentsDataPart> onData,
        Action<string, object?> onUnknown_
    )
    {
        switch (Kind)
        {
            case "text":
                onText(AsText());
                break;
            case "file":
                onFile(AsFile());
                break;
            case "data":
                onData(AsData());
                break;
            default:
                onUnknown_(Kind, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="CortiApi.AgentsTextPart"/> and returns true if successful.
    /// </summary>
    public bool TryAsText(out CortiApi.AgentsTextPart? value)
    {
        if (Kind == "text")
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
    public bool TryAsFile(out CortiApi.AgentsFilePart? value)
    {
        if (Kind == "file")
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
    public bool TryAsData(out CortiApi.AgentsDataPart? value)
    {
        if (Kind == "data")
        {
            value = (CortiApi.AgentsDataPart)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator AgentsPart(AgentsPart.Text value) => new(value);

    public static implicit operator AgentsPart(AgentsPart.File value) => new(value);

    public static implicit operator AgentsPart(AgentsPart.Data value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<AgentsPart>
    {
        public override bool CanConvert(System.Type typeToConvert) =>
            typeof(AgentsPart).IsAssignableFrom(typeToConvert);

        public override AgentsPart Read(
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
                "text" => json.Deserialize<CortiApi.AgentsTextPart?>(options)
                    ?? throw new JsonException("Failed to deserialize CortiApi.AgentsTextPart"),
                "file" => json.Deserialize<CortiApi.AgentsFilePart?>(options)
                    ?? throw new JsonException("Failed to deserialize CortiApi.AgentsFilePart"),
                "data" => json.Deserialize<CortiApi.AgentsDataPart?>(options)
                    ?? throw new JsonException("Failed to deserialize CortiApi.AgentsDataPart"),
                _ => json.Deserialize<object?>(options),
            };
            return new AgentsPart(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentsPart value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Kind switch
                {
                    "text" => JsonSerializer.SerializeToNode(value.Value, options),
                    "file" => JsonSerializer.SerializeToNode(value.Value, options),
                    "data" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["kind"] = value.Kind;
            json.WriteTo(writer, options);
        }
    }

    /// <summary>
    /// Discriminated union type for text
    /// </summary>
    [Serializable]
    public struct Text
    {
        public Text(CortiApi.AgentsTextPart value)
        {
            Value = value;
        }

        internal CortiApi.AgentsTextPart Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentsPart.Text(CortiApi.AgentsTextPart value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for file
    /// </summary>
    [Serializable]
    public struct File
    {
        public File(CortiApi.AgentsFilePart value)
        {
            Value = value;
        }

        internal CortiApi.AgentsFilePart Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentsPart.File(CortiApi.AgentsFilePart value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for data
    /// </summary>
    [Serializable]
    public struct Data
    {
        public Data(CortiApi.AgentsDataPart value)
        {
            Value = value;
        }

        internal CortiApi.AgentsDataPart Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentsPart.Data(CortiApi.AgentsDataPart value) =>
            new(value);
    }
}
