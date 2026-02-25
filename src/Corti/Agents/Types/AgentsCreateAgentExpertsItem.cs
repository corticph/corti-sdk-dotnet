// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(AgentsCreateAgentExpertsItem.JsonConverter))]
[Serializable]
public record AgentsCreateAgentExpertsItem
{
    internal AgentsCreateAgentExpertsItem(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of AgentsCreateAgentExpertsItem with <see cref="AgentsCreateAgentExpertsItem.New"/>.
    /// </summary>
    public AgentsCreateAgentExpertsItem(AgentsCreateAgentExpertsItem.New value)
    {
        Type = "new";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AgentsCreateAgentExpertsItem with <see cref="AgentsCreateAgentExpertsItem.Reference"/>.
    /// </summary>
    public AgentsCreateAgentExpertsItem(AgentsCreateAgentExpertsItem.Reference value)
    {
        Type = "reference";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Type"/> is "new"
    /// </summary>
    public bool IsNew => Type == "new";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "reference"
    /// </summary>
    public bool IsReference => Type == "reference";

    /// <summary>
    /// Returns the value as a <see cref="Corti.AgentsCreateExpert"/> if <see cref="Type"/> is 'new', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'new'.</exception>
    public Corti.AgentsCreateExpert AsNew() =>
        IsNew
            ? (Corti.AgentsCreateExpert)Value!
            : throw new System.Exception("AgentsCreateAgentExpertsItem.Type is not 'new'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.AgentsCreateExpertReference"/> if <see cref="Type"/> is 'reference', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'reference'.</exception>
    public Corti.AgentsCreateExpertReference AsReference() =>
        IsReference
            ? (Corti.AgentsCreateExpertReference)Value!
            : throw new System.Exception("AgentsCreateAgentExpertsItem.Type is not 'reference'");

    public T Match<T>(
        Func<Corti.AgentsCreateExpert, T> onNew,
        Func<Corti.AgentsCreateExpertReference, T> onReference,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "new" => onNew(AsNew()),
            "reference" => onReference(AsReference()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<Corti.AgentsCreateExpert> onNew,
        Action<Corti.AgentsCreateExpertReference> onReference,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "new":
                onNew(AsNew());
                break;
            case "reference":
                onReference(AsReference());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.AgentsCreateExpert"/> and returns true if successful.
    /// </summary>
    public bool TryAsNew(out Corti.AgentsCreateExpert? value)
    {
        if (Type == "new")
        {
            value = (Corti.AgentsCreateExpert)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.AgentsCreateExpertReference"/> and returns true if successful.
    /// </summary>
    public bool TryAsReference(out Corti.AgentsCreateExpertReference? value)
    {
        if (Type == "reference")
        {
            value = (Corti.AgentsCreateExpertReference)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator AgentsCreateAgentExpertsItem(
        AgentsCreateAgentExpertsItem.New value
    ) => new(value);

    public static implicit operator AgentsCreateAgentExpertsItem(
        AgentsCreateAgentExpertsItem.Reference value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<AgentsCreateAgentExpertsItem>
    {
        public override bool CanConvert(System.Type typeToConvert) =>
            typeof(AgentsCreateAgentExpertsItem).IsAssignableFrom(typeToConvert);

        public override AgentsCreateAgentExpertsItem Read(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("type", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'type'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'type' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'type' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'type' is null");

            var value = discriminator switch
            {
                "new" => json.Deserialize<Corti.AgentsCreateExpert?>(options)
                    ?? throw new JsonException("Failed to deserialize Corti.AgentsCreateExpert"),
                "reference" => json.Deserialize<Corti.AgentsCreateExpertReference?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Corti.AgentsCreateExpertReference"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new AgentsCreateAgentExpertsItem(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentsCreateAgentExpertsItem value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "new" => JsonSerializer.SerializeToNode(value.Value, options),
                    "reference" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }
    }

    /// <summary>
    /// Discriminated union type for new
    /// </summary>
    [Serializable]
    public struct New
    {
        public New(Corti.AgentsCreateExpert value)
        {
            Value = value;
        }

        internal Corti.AgentsCreateExpert Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentsCreateAgentExpertsItem.New(
            Corti.AgentsCreateExpert value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for reference
    /// </summary>
    [Serializable]
    public struct Reference
    {
        public Reference(Corti.AgentsCreateExpertReference value)
        {
            Value = value;
        }

        internal Corti.AgentsCreateExpertReference Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentsCreateAgentExpertsItem.Reference(
            Corti.AgentsCreateExpertReference value
        ) => new(value);
    }
}
