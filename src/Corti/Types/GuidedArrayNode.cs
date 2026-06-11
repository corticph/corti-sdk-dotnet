using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record GuidedArrayNode : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonRequired]
    [JsonPropertyName("type")]
    public GuidedArrayNode.TypeLiteral Type { get;
#if NET5_0_OR_GREATER
        init;
#else
        set;
#endif
    } = new();

    /// <summary>
    /// Guide the LLM in what to output for this node. Supplements the section-level instructions.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Must be another output schema node (string, number, boolean, array, or object).
    /// </summary>
    [JsonPropertyName("items")]
    public required GuidedOutputSchema Items { get; set; }

    /// <summary>
    /// Format string used to render each array item in the generated output. Use the `{item}` placeholder for the item value.
    /// </summary>
    [JsonPropertyName("itemFormat")]
    public string? ItemFormat { get; set; }

    /// <summary>
    /// Minimum number of array items to generate.
    /// </summary>
    [JsonPropertyName("minItems")]
    public int? MinItems { get; set; }

    /// <summary>
    /// Maximum number of array items to generate.
    /// </summary>
    [JsonPropertyName("maxItems")]
    public int? MaxItems { get; set; }

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
        public const string Value = "array";

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
