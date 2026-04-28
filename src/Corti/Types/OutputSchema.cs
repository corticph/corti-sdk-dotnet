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
    /// Factory method to create a union from a Corti.IntegerNode value.
    /// </summary>
    public static OutputSchema FromIntegerNode(Corti.IntegerNode value) =>
        new("integerNode", value);

    /// <summary>
    /// Factory method to create a union from a Corti.FloatNode value.
    /// </summary>
    public static OutputSchema FromFloatNode(Corti.FloatNode value) => new("floatNode", value);

    /// <summary>
    /// Factory method to create a union from a Corti.BoolNode value.
    /// </summary>
    public static OutputSchema FromBoolNode(Corti.BoolNode value) => new("boolNode", value);

    /// <summary>
    /// Factory method to create a union from a Corti.DictNode value.
    /// </summary>
    public static OutputSchema FromDictNode(Corti.DictNode value) => new("dictNode", value);

    /// <summary>
    /// Factory method to create a union from a Corti.ListNode value.
    /// </summary>
    public static OutputSchema FromListNode(Corti.ListNode value) => new("listNode", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "stringNode"
    /// </summary>
    public bool IsStringNode() => Type == "stringNode";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "integerNode"
    /// </summary>
    public bool IsIntegerNode() => Type == "integerNode";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "floatNode"
    /// </summary>
    public bool IsFloatNode() => Type == "floatNode";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "boolNode"
    /// </summary>
    public bool IsBoolNode() => Type == "boolNode";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "dictNode"
    /// </summary>
    public bool IsDictNode() => Type == "dictNode";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "listNode"
    /// </summary>
    public bool IsListNode() => Type == "listNode";

    /// <summary>
    /// Returns the value as a <see cref="Corti.StringNode"/> if <see cref="Type"/> is 'stringNode', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'stringNode'.</exception>
    public Corti.StringNode AsStringNode() =>
        IsStringNode()
            ? (Corti.StringNode)Value!
            : throw new CortiClientException("Union type is not 'stringNode'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.IntegerNode"/> if <see cref="Type"/> is 'integerNode', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'integerNode'.</exception>
    public Corti.IntegerNode AsIntegerNode() =>
        IsIntegerNode()
            ? (Corti.IntegerNode)Value!
            : throw new CortiClientException("Union type is not 'integerNode'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.FloatNode"/> if <see cref="Type"/> is 'floatNode', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'floatNode'.</exception>
    public Corti.FloatNode AsFloatNode() =>
        IsFloatNode()
            ? (Corti.FloatNode)Value!
            : throw new CortiClientException("Union type is not 'floatNode'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.BoolNode"/> if <see cref="Type"/> is 'boolNode', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'boolNode'.</exception>
    public Corti.BoolNode AsBoolNode() =>
        IsBoolNode()
            ? (Corti.BoolNode)Value!
            : throw new CortiClientException("Union type is not 'boolNode'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.DictNode"/> if <see cref="Type"/> is 'dictNode', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'dictNode'.</exception>
    public Corti.DictNode AsDictNode() =>
        IsDictNode()
            ? (Corti.DictNode)Value!
            : throw new CortiClientException("Union type is not 'dictNode'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.ListNode"/> if <see cref="Type"/> is 'listNode', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'listNode'.</exception>
    public Corti.ListNode AsListNode() =>
        IsListNode()
            ? (Corti.ListNode)Value!
            : throw new CortiClientException("Union type is not 'listNode'");

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
    /// Attempts to cast the value to a <see cref="Corti.IntegerNode"/> and returns true if successful.
    /// </summary>
    public bool TryGetIntegerNode(out Corti.IntegerNode? value)
    {
        if (Type == "integerNode")
        {
            value = (Corti.IntegerNode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.FloatNode"/> and returns true if successful.
    /// </summary>
    public bool TryGetFloatNode(out Corti.FloatNode? value)
    {
        if (Type == "floatNode")
        {
            value = (Corti.FloatNode)Value!;
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
    /// Attempts to cast the value to a <see cref="Corti.DictNode"/> and returns true if successful.
    /// </summary>
    public bool TryGetDictNode(out Corti.DictNode? value)
    {
        if (Type == "dictNode")
        {
            value = (Corti.DictNode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.ListNode"/> and returns true if successful.
    /// </summary>
    public bool TryGetListNode(out Corti.ListNode? value)
    {
        if (Type == "listNode")
        {
            value = (Corti.ListNode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Corti.StringNode, T> onStringNode,
        Func<Corti.IntegerNode, T> onIntegerNode,
        Func<Corti.FloatNode, T> onFloatNode,
        Func<Corti.BoolNode, T> onBoolNode,
        Func<Corti.DictNode, T> onDictNode,
        Func<Corti.ListNode, T> onListNode
    )
    {
        return Type switch
        {
            "stringNode" => onStringNode(AsStringNode()),
            "integerNode" => onIntegerNode(AsIntegerNode()),
            "floatNode" => onFloatNode(AsFloatNode()),
            "boolNode" => onBoolNode(AsBoolNode()),
            "dictNode" => onDictNode(AsDictNode()),
            "listNode" => onListNode(AsListNode()),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Corti.StringNode> onStringNode,
        Action<Corti.IntegerNode> onIntegerNode,
        Action<Corti.FloatNode> onFloatNode,
        Action<Corti.BoolNode> onBoolNode,
        Action<Corti.DictNode> onDictNode,
        Action<Corti.ListNode> onListNode
    )
    {
        switch (Type)
        {
            case "stringNode":
                onStringNode(AsStringNode());
                break;
            case "integerNode":
                onIntegerNode(AsIntegerNode());
                break;
            case "floatNode":
                onFloatNode(AsFloatNode());
                break;
            case "boolNode":
                onBoolNode(AsBoolNode());
                break;
            case "dictNode":
                onDictNode(AsDictNode());
                break;
            case "listNode":
                onListNode(AsListNode());
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

    public static implicit operator OutputSchema(Corti.IntegerNode value) =>
        new("integerNode", value);

    public static implicit operator OutputSchema(Corti.FloatNode value) => new("floatNode", value);

    public static implicit operator OutputSchema(Corti.BoolNode value) => new("boolNode", value);

    public static implicit operator OutputSchema(Corti.DictNode value) => new("dictNode", value);

    public static implicit operator OutputSchema(Corti.ListNode value) => new("listNode", value);

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
                    ("integerNode", typeof(Corti.IntegerNode)),
                    ("floatNode", typeof(Corti.FloatNode)),
                    ("boolNode", typeof(Corti.BoolNode)),
                    ("dictNode", typeof(Corti.DictNode)),
                    ("listNode", typeof(Corti.ListNode)),
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
