using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// A connector backed by a schema definition.
/// </summary>
[Serializable]
public record CommonSchemaConnector : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonRequired]
    [JsonPropertyName("type")]
    public CommonSchemaConnector.TypeLiteral Type { get;
#if NET5_0_OR_GREATER
        init;
#else
        set;
#endif
    } = new();

    /// <summary>
    /// Schema connector name. Used as the tool name the LLM calls.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// What the tool does. Read by the LLM to decide when to call it.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// JSON Schema defining the tool's output shape.
    /// </summary>
    [JsonPropertyName("schema")]
    public Dictionary<string, object?> Schema { get; set; } = new Dictionary<string, object?>();

    /// <summary>
    /// If set, calling this tool terminates the loop in the given state after validating and storing the data part. No further LLM call.
    /// </summary>
    [JsonPropertyName("transition")]
    public CommonSchemaConnectorTransition? Transition { get; set; }

    /// <summary>
    /// Server-generated connector identifier (prefixed UUIDv7). Stable across PATCH
    /// replacements where the underlying spec is unchanged. Used by
    /// observability/HITL to reference a connector unambiguously.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Whether the connector is active for invocations. Only `schema` connectors return this field today; `mcp`, `registry`, `agent`, and `a2a` connectors omit it (treat as enabled).
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }

    [JsonConverter(typeof(TypeLiteralConverter))]
    public readonly struct TypeLiteral
    {
        public const string Value = "schema";

        public static implicit operator string(TypeLiteral _) => Value;

        public override string ToString() => Value;

        public override int GetHashCode() =>
            global::System.StringComparer.Ordinal.GetHashCode(Value);

        public override bool Equals(object? obj) => obj is TypeLiteral;

        public static bool operator ==(TypeLiteral _, TypeLiteral __) => true;

        public static bool operator !=(TypeLiteral _, TypeLiteral __) => false;

        internal sealed class TypeLiteralConverter : JsonConverter<TypeLiteral>
        {
            public override TypeLiteral Read(
                ref Utf8JsonReader reader,
                global::System.Type typeToConvert,
                JsonSerializerOptions options
            )
            {
                var value = reader.GetString();
                if (value != TypeLiteral.Value)
                {
                    throw new JsonException(
                        "Expected \""
                            + TypeLiteral.Value
                            + "\" for type discriminator but got \""
                            + value
                            + "\"."
                    );
                }
                return new TypeLiteral();
            }

            public override void Write(
                Utf8JsonWriter writer,
                TypeLiteral value,
                JsonSerializerOptions options
            ) => writer.WriteStringValue(TypeLiteral.Value);

            public override TypeLiteral ReadAsPropertyName(
                ref Utf8JsonReader reader,
                global::System.Type typeToConvert,
                JsonSerializerOptions options
            )
            {
                var value = reader.GetString();
                if (value != TypeLiteral.Value)
                {
                    throw new JsonException(
                        "Expected \""
                            + TypeLiteral.Value
                            + "\" for type discriminator but got \""
                            + value
                            + "\"."
                    );
                }
                return new TypeLiteral();
            }

            public override void WriteAsPropertyName(
                Utf8JsonWriter writer,
                TypeLiteral value,
                JsonSerializerOptions options
            ) => writer.WritePropertyName(TypeLiteral.Value);
        }
    }
}
