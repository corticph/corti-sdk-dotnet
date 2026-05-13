// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(OutputSchema.JsonConverter))]
[Serializable]
public class OutputSchema
{
    private OutputSchema(string type, object? value)
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
    /// Factory method to create a union from a Corti.StringNode value.
    /// </summary>
    public static OutputSchema FromStringNode(Corti.StringNode value) => new("stringNode", value);

    /// <summary>
    /// Factory method to create a union from a Corti.NumberNode value.
    /// </summary>
    public static OutputSchema FromNumberNode(Corti.NumberNode value) => new("numberNode", value);

    /// <summary>
    /// Factory method to create a union from a Corti.BoolNode value.
    /// </summary>
    public static OutputSchema FromBoolNode(Corti.BoolNode value) => new("boolNode", value);

    /// <summary>
    /// Factory method to create a union from a Corti.ObjectNode value.
    /// </summary>
    public static OutputSchema FromObjectNode(Corti.ObjectNode value) => new("objectNode", value);

    /// <summary>
    /// Factory method to create a union from a Corti.ArrayNode value.
    /// </summary>
    public static OutputSchema FromArrayNode(Corti.ArrayNode value) => new("arrayNode", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "stringNode"
    /// </summary>
    public bool IsStringNode() => Type == "stringNode";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "numberNode"
    /// </summary>
    public bool IsNumberNode() => Type == "numberNode";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "boolNode"
    /// </summary>
    public bool IsBoolNode() => Type == "boolNode";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "objectNode"
    /// </summary>
    public bool IsObjectNode() => Type == "objectNode";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "arrayNode"
    /// </summary>
    public bool IsArrayNode() => Type == "arrayNode";

    /// <summary>
    /// Returns the value as a <see cref="Corti.StringNode"/> if <see cref="Type"/> is 'stringNode', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'stringNode'.</exception>
    public Corti.StringNode AsStringNode() =>
        IsStringNode()
            ? (Corti.StringNode)Value!
            : throw new CortiClientException("Union type is not 'stringNode'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.NumberNode"/> if <see cref="Type"/> is 'numberNode', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'numberNode'.</exception>
    public Corti.NumberNode AsNumberNode() =>
        IsNumberNode()
            ? (Corti.NumberNode)Value!
            : throw new CortiClientException("Union type is not 'numberNode'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.BoolNode"/> if <see cref="Type"/> is 'boolNode', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'boolNode'.</exception>
    public Corti.BoolNode AsBoolNode() =>
        IsBoolNode()
            ? (Corti.BoolNode)Value!
            : throw new CortiClientException("Union type is not 'boolNode'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.ObjectNode"/> if <see cref="Type"/> is 'objectNode', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'objectNode'.</exception>
    public Corti.ObjectNode AsObjectNode() =>
        IsObjectNode()
            ? (Corti.ObjectNode)Value!
            : throw new CortiClientException("Union type is not 'objectNode'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.ArrayNode"/> if <see cref="Type"/> is 'arrayNode', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'arrayNode'.</exception>
    public Corti.ArrayNode AsArrayNode() =>
        IsArrayNode()
            ? (Corti.ArrayNode)Value!
            : throw new CortiClientException("Union type is not 'arrayNode'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.StringNode"/> and returns true if successful.
    /// </summary>
    public bool TryGetStringNode(out Corti.StringNode? value)
    {
        if (Type == "stringNode")
        {
            value = (Corti.StringNode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.NumberNode"/> and returns true if successful.
    /// </summary>
    public bool TryGetNumberNode(out Corti.NumberNode? value)
    {
        if (Type == "numberNode")
        {
            value = (Corti.NumberNode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.BoolNode"/> and returns true if successful.
    /// </summary>
    public bool TryGetBoolNode(out Corti.BoolNode? value)
    {
        if (Type == "boolNode")
        {
            value = (Corti.BoolNode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.ObjectNode"/> and returns true if successful.
    /// </summary>
    public bool TryGetObjectNode(out Corti.ObjectNode? value)
    {
        if (Type == "objectNode")
        {
            value = (Corti.ObjectNode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.ArrayNode"/> and returns true if successful.
    /// </summary>
    public bool TryGetArrayNode(out Corti.ArrayNode? value)
    {
        if (Type == "arrayNode")
        {
            value = (Corti.ArrayNode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Corti.StringNode, T> onStringNode,
        Func<Corti.NumberNode, T> onNumberNode,
        Func<Corti.BoolNode, T> onBoolNode,
        Func<Corti.ObjectNode, T> onObjectNode,
        Func<Corti.ArrayNode, T> onArrayNode
    )
    {
        return Type switch
        {
            "stringNode" => onStringNode(AsStringNode()),
            "numberNode" => onNumberNode(AsNumberNode()),
            "boolNode" => onBoolNode(AsBoolNode()),
            "objectNode" => onObjectNode(AsObjectNode()),
            "arrayNode" => onArrayNode(AsArrayNode()),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Corti.StringNode> onStringNode,
        Action<Corti.NumberNode> onNumberNode,
        Action<Corti.BoolNode> onBoolNode,
        Action<Corti.ObjectNode> onObjectNode,
        Action<Corti.ArrayNode> onArrayNode
    )
    {
        switch (Type)
        {
            case "stringNode":
                onStringNode(AsStringNode());
                break;
            case "numberNode":
                onNumberNode(AsNumberNode());
                break;
            case "boolNode":
                onBoolNode(AsBoolNode());
                break;
            case "objectNode":
                onObjectNode(AsObjectNode());
                break;
            case "arrayNode":
                onArrayNode(AsArrayNode());
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
        if (obj is not OutputSchema other)
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

    public static implicit operator OutputSchema(Corti.StringNode value) =>
        new("stringNode", value);

    public static implicit operator OutputSchema(Corti.NumberNode value) =>
        new("numberNode", value);

    public static implicit operator OutputSchema(Corti.BoolNode value) => new("boolNode", value);

    public static implicit operator OutputSchema(Corti.ObjectNode value) =>
        new("objectNode", value);

    public static implicit operator OutputSchema(Corti.ArrayNode value) => new("arrayNode", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<OutputSchema>
    {
        public override OutputSchema? Read(
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
                    ("stringNode", typeof(Corti.StringNode)),
                    ("numberNode", typeof(Corti.NumberNode)),
                    ("boolNode", typeof(Corti.BoolNode)),
                    ("objectNode", typeof(Corti.ObjectNode)),
                    ("arrayNode", typeof(Corti.ArrayNode)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            OutputSchema result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into OutputSchema"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            OutputSchema value,
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
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override OutputSchema ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            OutputSchema result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OutputSchema value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
