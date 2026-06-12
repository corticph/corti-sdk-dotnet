// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(GuidedOutputSchema.JsonConverter))]
[Serializable]
public class GuidedOutputSchema
{
    private GuidedOutputSchema(string type, object? value)
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
    /// Factory method to create a union from a Corti.GuidedStringNode value.
    /// </summary>
    public static GuidedOutputSchema FromGuidedStringNode(Corti.GuidedStringNode value) =>
        new("guidedStringNode", value);

    /// <summary>
    /// Factory method to create a union from a Corti.GuidedNumberNode value.
    /// </summary>
    public static GuidedOutputSchema FromGuidedNumberNode(Corti.GuidedNumberNode value) =>
        new("guidedNumberNode", value);

    /// <summary>
    /// Factory method to create a union from a Corti.GuidedBoolNode value.
    /// </summary>
    public static GuidedOutputSchema FromGuidedBoolNode(Corti.GuidedBoolNode value) =>
        new("guidedBoolNode", value);

    /// <summary>
    /// Factory method to create a union from a Corti.GuidedObjectNode value.
    /// </summary>
    public static GuidedOutputSchema FromGuidedObjectNode(Corti.GuidedObjectNode value) =>
        new("guidedObjectNode", value);

    /// <summary>
    /// Factory method to create a union from a Corti.GuidedArrayNode value.
    /// </summary>
    public static GuidedOutputSchema FromGuidedArrayNode(Corti.GuidedArrayNode value) =>
        new("guidedArrayNode", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guidedStringNode"
    /// </summary>
    public bool IsGuidedStringNode() => Type == "guidedStringNode";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guidedNumberNode"
    /// </summary>
    public bool IsGuidedNumberNode() => Type == "guidedNumberNode";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guidedBoolNode"
    /// </summary>
    public bool IsGuidedBoolNode() => Type == "guidedBoolNode";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guidedObjectNode"
    /// </summary>
    public bool IsGuidedObjectNode() => Type == "guidedObjectNode";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guidedArrayNode"
    /// </summary>
    public bool IsGuidedArrayNode() => Type == "guidedArrayNode";

    /// <summary>
    /// Returns the value as a <see cref="Corti.GuidedStringNode"/> if <see cref="Type"/> is 'guidedStringNode', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'guidedStringNode'.</exception>
    public Corti.GuidedStringNode AsGuidedStringNode() =>
        IsGuidedStringNode()
            ? (Corti.GuidedStringNode)Value!
            : throw new CortiClientException("Union type is not 'guidedStringNode'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.GuidedNumberNode"/> if <see cref="Type"/> is 'guidedNumberNode', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'guidedNumberNode'.</exception>
    public Corti.GuidedNumberNode AsGuidedNumberNode() =>
        IsGuidedNumberNode()
            ? (Corti.GuidedNumberNode)Value!
            : throw new CortiClientException("Union type is not 'guidedNumberNode'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.GuidedBoolNode"/> if <see cref="Type"/> is 'guidedBoolNode', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'guidedBoolNode'.</exception>
    public Corti.GuidedBoolNode AsGuidedBoolNode() =>
        IsGuidedBoolNode()
            ? (Corti.GuidedBoolNode)Value!
            : throw new CortiClientException("Union type is not 'guidedBoolNode'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.GuidedObjectNode"/> if <see cref="Type"/> is 'guidedObjectNode', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'guidedObjectNode'.</exception>
    public Corti.GuidedObjectNode AsGuidedObjectNode() =>
        IsGuidedObjectNode()
            ? (Corti.GuidedObjectNode)Value!
            : throw new CortiClientException("Union type is not 'guidedObjectNode'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.GuidedArrayNode"/> if <see cref="Type"/> is 'guidedArrayNode', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'guidedArrayNode'.</exception>
    public Corti.GuidedArrayNode AsGuidedArrayNode() =>
        IsGuidedArrayNode()
            ? (Corti.GuidedArrayNode)Value!
            : throw new CortiClientException("Union type is not 'guidedArrayNode'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.GuidedStringNode"/> and returns true if successful.
    /// </summary>
    public bool TryGetGuidedStringNode(out Corti.GuidedStringNode? value)
    {
        if (Type == "guidedStringNode")
        {
            value = (Corti.GuidedStringNode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.GuidedNumberNode"/> and returns true if successful.
    /// </summary>
    public bool TryGetGuidedNumberNode(out Corti.GuidedNumberNode? value)
    {
        if (Type == "guidedNumberNode")
        {
            value = (Corti.GuidedNumberNode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.GuidedBoolNode"/> and returns true if successful.
    /// </summary>
    public bool TryGetGuidedBoolNode(out Corti.GuidedBoolNode? value)
    {
        if (Type == "guidedBoolNode")
        {
            value = (Corti.GuidedBoolNode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.GuidedObjectNode"/> and returns true if successful.
    /// </summary>
    public bool TryGetGuidedObjectNode(out Corti.GuidedObjectNode? value)
    {
        if (Type == "guidedObjectNode")
        {
            value = (Corti.GuidedObjectNode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.GuidedArrayNode"/> and returns true if successful.
    /// </summary>
    public bool TryGetGuidedArrayNode(out Corti.GuidedArrayNode? value)
    {
        if (Type == "guidedArrayNode")
        {
            value = (Corti.GuidedArrayNode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Corti.GuidedStringNode, T> onGuidedStringNode,
        Func<Corti.GuidedNumberNode, T> onGuidedNumberNode,
        Func<Corti.GuidedBoolNode, T> onGuidedBoolNode,
        Func<Corti.GuidedObjectNode, T> onGuidedObjectNode,
        Func<Corti.GuidedArrayNode, T> onGuidedArrayNode
    )
    {
        return Type switch
        {
            "guidedStringNode" => onGuidedStringNode(AsGuidedStringNode()),
            "guidedNumberNode" => onGuidedNumberNode(AsGuidedNumberNode()),
            "guidedBoolNode" => onGuidedBoolNode(AsGuidedBoolNode()),
            "guidedObjectNode" => onGuidedObjectNode(AsGuidedObjectNode()),
            "guidedArrayNode" => onGuidedArrayNode(AsGuidedArrayNode()),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Corti.GuidedStringNode> onGuidedStringNode,
        Action<Corti.GuidedNumberNode> onGuidedNumberNode,
        Action<Corti.GuidedBoolNode> onGuidedBoolNode,
        Action<Corti.GuidedObjectNode> onGuidedObjectNode,
        Action<Corti.GuidedArrayNode> onGuidedArrayNode
    )
    {
        switch (Type)
        {
            case "guidedStringNode":
                onGuidedStringNode(AsGuidedStringNode());
                break;
            case "guidedNumberNode":
                onGuidedNumberNode(AsGuidedNumberNode());
                break;
            case "guidedBoolNode":
                onGuidedBoolNode(AsGuidedBoolNode());
                break;
            case "guidedObjectNode":
                onGuidedObjectNode(AsGuidedObjectNode());
                break;
            case "guidedArrayNode":
                onGuidedArrayNode(AsGuidedArrayNode());
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
        if (obj is not GuidedOutputSchema other)
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

    public static implicit operator GuidedOutputSchema(Corti.GuidedStringNode value) =>
        new("guidedStringNode", value);

    public static implicit operator GuidedOutputSchema(Corti.GuidedNumberNode value) =>
        new("guidedNumberNode", value);

    public static implicit operator GuidedOutputSchema(Corti.GuidedBoolNode value) =>
        new("guidedBoolNode", value);

    public static implicit operator GuidedOutputSchema(Corti.GuidedObjectNode value) =>
        new("guidedObjectNode", value);

    public static implicit operator GuidedOutputSchema(Corti.GuidedArrayNode value) =>
        new("guidedArrayNode", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<GuidedOutputSchema>
    {
        public override GuidedOutputSchema? Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
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
                    ("guidedStringNode", typeof(Corti.GuidedStringNode)),
                    ("guidedNumberNode", typeof(Corti.GuidedNumberNode)),
                    ("guidedBoolNode", typeof(Corti.GuidedBoolNode)),
                    ("guidedObjectNode", typeof(Corti.GuidedObjectNode)),
                    ("guidedArrayNode", typeof(Corti.GuidedArrayNode)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            GuidedOutputSchema result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into GuidedOutputSchema"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            GuidedOutputSchema value,
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

        public override GuidedOutputSchema ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            GuidedOutputSchema result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GuidedOutputSchema value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
