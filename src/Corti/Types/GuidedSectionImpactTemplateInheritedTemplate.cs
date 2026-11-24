using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// The template inherits its section list from a parent template that links this section.
/// </summary>
[Serializable]
public record GuidedSectionImpactTemplateInheritedTemplate : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The UUID of the template.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The name of the template.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonRequired]
    [JsonPropertyName("via")]
    public GuidedSectionImpactTemplateInheritedTemplate.ViaLiteral Via { get;
#if NET5_0_OR_GREATER
        init;
#else
        set;
#endif
    } = new();

    /// <summary>
    /// The parent template that the template inherits from.
    /// </summary>
    [JsonPropertyName("viaTemplateId")]
    public required string ViaTemplateId { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }

    [JsonConverter(typeof(ViaLiteralConverter))]
    public readonly struct ViaLiteral
    {
        public const string Value = "inheritedTemplate";

        public static implicit operator string(ViaLiteral _) => Value;

        public override string ToString() => Value;

        public override int GetHashCode() =>
            global::System.StringComparer.Ordinal.GetHashCode(Value);

        public override bool Equals(object? obj) => obj is ViaLiteral;

        public static bool operator ==(ViaLiteral _, ViaLiteral __) => true;

        public static bool operator !=(ViaLiteral _, ViaLiteral __) => false;

        internal sealed class ViaLiteralConverter : JsonConverter<ViaLiteral>
        {
            public override ViaLiteral Read(
                ref Utf8JsonReader reader,
                global::System.Type typeToConvert,
                JsonSerializerOptions options
            )
            {
                var value = reader.GetString();
                if (value != ViaLiteral.Value)
                {
                    throw new JsonException(
                        "Expected \""
                            + ViaLiteral.Value
                            + "\" for type discriminator but got \""
                            + value
                            + "\"."
                    );
                }
                return new ViaLiteral();
            }

            public override void Write(
                Utf8JsonWriter writer,
                ViaLiteral value,
                JsonSerializerOptions options
            ) => writer.WriteStringValue(ViaLiteral.Value);

            public override ViaLiteral ReadAsPropertyName(
                ref Utf8JsonReader reader,
                global::System.Type typeToConvert,
                JsonSerializerOptions options
            )
            {
                var value = reader.GetString();
                if (value != ViaLiteral.Value)
                {
                    throw new JsonException(
                        "Expected \""
                            + ViaLiteral.Value
                            + "\" for type discriminator but got \""
                            + value
                            + "\"."
                    );
                }
                return new ViaLiteral();
            }

            public override void WriteAsPropertyName(
                Utf8JsonWriter writer,
                ViaLiteral value,
                JsonSerializerOptions options
            ) => writer.WritePropertyName(ViaLiteral.Value);
        }
    }
}
