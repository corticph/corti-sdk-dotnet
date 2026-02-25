// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(AgentsAgentExpertsItem.JsonConverter))]
[Serializable]
public record AgentsAgentExpertsItem
{
    internal AgentsAgentExpertsItem(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of AgentsAgentExpertsItem with <see cref="AgentsAgentExpertsItem.Expert"/>.
    /// </summary>
    public AgentsAgentExpertsItem(AgentsAgentExpertsItem.Expert value)
    {
        Type = "expert";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AgentsAgentExpertsItem with <see cref="AgentsAgentExpertsItem.Reference"/>.
    /// </summary>
    public AgentsAgentExpertsItem(AgentsAgentExpertsItem.Reference value)
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
    /// Returns true if <see cref="Type"/> is "expert"
    /// </summary>
    public bool IsExpert => Type == "expert";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "reference"
    /// </summary>
    public bool IsReference => Type == "reference";

    /// <summary>
    /// Returns the value as a <see cref="Corti.AgentsExpert"/> if <see cref="Type"/> is 'expert', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'expert'.</exception>
    public Corti.AgentsExpert AsExpert() =>
        IsExpert
            ? (Corti.AgentsExpert)Value!
            : throw new System.Exception("AgentsAgentExpertsItem.Type is not 'expert'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.AgentsExpertReference"/> if <see cref="Type"/> is 'reference', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'reference'.</exception>
    public Corti.AgentsExpertReference AsReference() =>
        IsReference
            ? (Corti.AgentsExpertReference)Value!
            : throw new System.Exception("AgentsAgentExpertsItem.Type is not 'reference'");

    public T Match<T>(
        Func<Corti.AgentsExpert, T> onExpert,
        Func<Corti.AgentsExpertReference, T> onReference,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "expert" => onExpert(AsExpert()),
            "reference" => onReference(AsReference()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<Corti.AgentsExpert> onExpert,
        Action<Corti.AgentsExpertReference> onReference,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "expert":
                onExpert(AsExpert());
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
    /// Attempts to cast the value to a <see cref="Corti.AgentsExpert"/> and returns true if successful.
    /// </summary>
    public bool TryAsExpert(out Corti.AgentsExpert? value)
    {
        if (Type == "expert")
        {
            value = (Corti.AgentsExpert)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.AgentsExpertReference"/> and returns true if successful.
    /// </summary>
    public bool TryAsReference(out Corti.AgentsExpertReference? value)
    {
        if (Type == "reference")
        {
            value = (Corti.AgentsExpertReference)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator AgentsAgentExpertsItem(AgentsAgentExpertsItem.Expert value) =>
        new(value);

    public static implicit operator AgentsAgentExpertsItem(
        AgentsAgentExpertsItem.Reference value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<AgentsAgentExpertsItem>
    {
        public override bool CanConvert(System.Type typeToConvert) =>
            typeof(AgentsAgentExpertsItem).IsAssignableFrom(typeToConvert);

        public override AgentsAgentExpertsItem Read(
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
                "expert" => json.Deserialize<Corti.AgentsExpert?>(options)
                    ?? throw new JsonException("Failed to deserialize Corti.AgentsExpert"),
                "reference" => json.Deserialize<Corti.AgentsExpertReference?>(options)
                    ?? throw new JsonException("Failed to deserialize Corti.AgentsExpertReference"),
                _ => json.Deserialize<object?>(options),
            };
            return new AgentsAgentExpertsItem(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentsAgentExpertsItem value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "expert" => JsonSerializer.SerializeToNode(value.Value, options),
                    "reference" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }
    }

    /// <summary>
    /// Discriminated union type for expert
    /// </summary>
    [Serializable]
    public struct Expert
    {
        public Expert(Corti.AgentsExpert value)
        {
            Value = value;
        }

        internal Corti.AgentsExpert Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentsAgentExpertsItem.Expert(Corti.AgentsExpert value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for reference
    /// </summary>
    [Serializable]
    public struct Reference
    {
        public Reference(Corti.AgentsExpertReference value)
        {
            Value = value;
        }

        internal Corti.AgentsExpertReference Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentsAgentExpertsItem.Reference(
            Corti.AgentsExpertReference value
        ) => new(value);
    }
}
