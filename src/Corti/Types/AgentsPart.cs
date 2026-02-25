// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

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
    /// Returns the value as a <see cref="Corti.AgentsTextPart"/> if <see cref="Kind"/> is 'text', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'text'.</exception>
    public Corti.AgentsTextPart AsText() =>
        IsText
            ? (Corti.AgentsTextPart)Value!
            : throw new System.Exception("AgentsPart.Kind is not 'text'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.AgentsFilePart"/> if <see cref="Kind"/> is 'file', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'file'.</exception>
    public Corti.AgentsFilePart AsFile() =>
        IsFile
            ? (Corti.AgentsFilePart)Value!
            : throw new System.Exception("AgentsPart.Kind is not 'file'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.AgentsDataPart"/> if <see cref="Kind"/> is 'data', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'data'.</exception>
    public Corti.AgentsDataPart AsData() =>
        IsData
            ? (Corti.AgentsDataPart)Value!
            : throw new System.Exception("AgentsPart.Kind is not 'data'");

    public T Match<T>(
        Func<Corti.AgentsTextPart, T> onText,
        Func<Corti.AgentsFilePart, T> onFile,
        Func<Corti.AgentsDataPart, T> onData,
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
        Action<Corti.AgentsTextPart> onText,
        Action<Corti.AgentsFilePart> onFile,
        Action<Corti.AgentsDataPart> onData,
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
    /// Attempts to cast the value to a <see cref="Corti.AgentsTextPart"/> and returns true if successful.
    /// </summary>
    public bool TryAsText(out Corti.AgentsTextPart? value)
    {
        if (Kind == "text")
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
    public bool TryAsFile(out Corti.AgentsFilePart? value)
    {
        if (Kind == "file")
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
    public bool TryAsData(out Corti.AgentsDataPart? value)
    {
        if (Kind == "data")
        {
            value = (Corti.AgentsDataPart)Value!;
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
                "text" => json.Deserialize<Corti.AgentsTextPart?>(options)
                    ?? throw new JsonException("Failed to deserialize Corti.AgentsTextPart"),
                "file" => json.Deserialize<Corti.AgentsFilePart?>(options)
                    ?? throw new JsonException("Failed to deserialize Corti.AgentsFilePart"),
                "data" => json.Deserialize<Corti.AgentsDataPart?>(options)
                    ?? throw new JsonException("Failed to deserialize Corti.AgentsDataPart"),
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
        public Text(Corti.AgentsTextPart value)
        {
            Value = value;
        }

        internal Corti.AgentsTextPart Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentsPart.Text(Corti.AgentsTextPart value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for file
    /// </summary>
    [Serializable]
    public struct File
    {
        public File(Corti.AgentsFilePart value)
        {
            Value = value;
        }

        internal Corti.AgentsFilePart Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentsPart.File(Corti.AgentsFilePart value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for data
    /// </summary>
    [Serializable]
    public struct Data
    {
        public Data(Corti.AgentsDataPart value)
        {
            Value = value;
        }

        internal Corti.AgentsDataPart Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentsPart.Data(Corti.AgentsDataPart value) => new(value);
    }
}
