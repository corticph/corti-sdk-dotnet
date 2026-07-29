using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

[Serializable]
public record AgentCardResponseSupportedInterfacesItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A2A protocol binding type.
    /// </summary>
    [JsonPropertyName("protocolBinding")]
    public required AgentCardResponseSupportedInterfacesItemProtocolBinding ProtocolBinding { get; set; }

    /// <summary>
    /// A2A protocol version; always `1.0`.
    /// </summary>
    [JsonRequired]
    [JsonPropertyName("protocolVersion")]
    public AgentCardResponseSupportedInterfacesItem.ProtocolVersionLiteral ProtocolVersion { get;
#if NET5_0_OR_GREATER
        init;
#else
        set;
#endif
    } = new();

    /// <summary>
    /// Endpoint URL for this protocol binding.
    /// </summary>
    [JsonPropertyName("url")]
    public required string Url { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }

    [JsonConverter(typeof(ProtocolVersionLiteralConverter))]
    public readonly struct ProtocolVersionLiteral
    {
        public const string Value = "1.0";

        public static implicit operator string(ProtocolVersionLiteral _) => Value;

        public override string ToString() => Value;

        public override int GetHashCode() =>
            global::System.StringComparer.Ordinal.GetHashCode(Value);

        public override bool Equals(object? obj) => obj is ProtocolVersionLiteral;

        public static bool operator ==(ProtocolVersionLiteral _, ProtocolVersionLiteral __) => true;

        public static bool operator !=(ProtocolVersionLiteral _, ProtocolVersionLiteral __) =>
            false;

        internal sealed class ProtocolVersionLiteralConverter
            : JsonConverter<ProtocolVersionLiteral>
        {
            public override ProtocolVersionLiteral Read(
                ref Utf8JsonReader reader,
                global::System.Type typeToConvert,
                JsonSerializerOptions options
            )
            {
                var value = reader.GetString();
                if (value != ProtocolVersionLiteral.Value)
                {
                    throw new JsonException(
                        "Expected \""
                            + ProtocolVersionLiteral.Value
                            + "\" for type discriminator but got \""
                            + value
                            + "\"."
                    );
                }
                return new ProtocolVersionLiteral();
            }

            public override void Write(
                Utf8JsonWriter writer,
                ProtocolVersionLiteral value,
                JsonSerializerOptions options
            ) => writer.WriteStringValue(ProtocolVersionLiteral.Value);

            public override ProtocolVersionLiteral ReadAsPropertyName(
                ref Utf8JsonReader reader,
                global::System.Type typeToConvert,
                JsonSerializerOptions options
            )
            {
                var value = reader.GetString();
                if (value != ProtocolVersionLiteral.Value)
                {
                    throw new JsonException(
                        "Expected \""
                            + ProtocolVersionLiteral.Value
                            + "\" for type discriminator but got \""
                            + value
                            + "\"."
                    );
                }
                return new ProtocolVersionLiteral();
            }

            public override void WriteAsPropertyName(
                Utf8JsonWriter writer,
                ProtocolVersionLiteral value,
                JsonSerializerOptions options
            ) => writer.WritePropertyName(ProtocolVersionLiteral.Value);
        }
    }
}
