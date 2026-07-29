using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// A JSON-RPC 2.0 response envelope.
/// </summary>
[Serializable]
public record A2AjsonrpcResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// JSON-RPC protocol version; always `2.0`.
    /// </summary>
    [JsonRequired]
    [JsonPropertyName("jsonrpc")]
    public A2AjsonrpcResponse.JsonrpcLiteral Jsonrpc { get;
#if NET5_0_OR_GREATER
        init;
#else
        set;
#endif
    } = new();

    [JsonPropertyName("id")]
    public A2AjsonrpcResponseId? Id { get; set; }

    /// <summary>
    /// JSON-RPC result object (present on success).
    /// </summary>
    [JsonPropertyName("result")]
    public Dictionary<string, object?>? Result { get; set; }

    /// <summary>
    /// JSON-RPC error object (present on failure).
    /// </summary>
    [JsonPropertyName("error")]
    public A2AjsonrpcResponseError? Error { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }

    [JsonConverter(typeof(JsonrpcLiteralConverter))]
    public readonly struct JsonrpcLiteral
    {
        public const string Value = "2.0";

        public static implicit operator string(JsonrpcLiteral _) => Value;

        public override string ToString() => Value;

        public override int GetHashCode() =>
            global::System.StringComparer.Ordinal.GetHashCode(Value);

        public override bool Equals(object? obj) => obj is JsonrpcLiteral;

        public static bool operator ==(JsonrpcLiteral _, JsonrpcLiteral __) => true;

        public static bool operator !=(JsonrpcLiteral _, JsonrpcLiteral __) => false;

        internal sealed class JsonrpcLiteralConverter : JsonConverter<JsonrpcLiteral>
        {
            public override JsonrpcLiteral Read(
                ref Utf8JsonReader reader,
                global::System.Type typeToConvert,
                JsonSerializerOptions options
            )
            {
                var value = reader.GetString();
                if (value != JsonrpcLiteral.Value)
                {
                    throw new JsonException(
                        "Expected \""
                            + JsonrpcLiteral.Value
                            + "\" for type discriminator but got \""
                            + value
                            + "\"."
                    );
                }
                return new JsonrpcLiteral();
            }

            public override void Write(
                Utf8JsonWriter writer,
                JsonrpcLiteral value,
                JsonSerializerOptions options
            ) => writer.WriteStringValue(JsonrpcLiteral.Value);

            public override JsonrpcLiteral ReadAsPropertyName(
                ref Utf8JsonReader reader,
                global::System.Type typeToConvert,
                JsonSerializerOptions options
            )
            {
                var value = reader.GetString();
                if (value != JsonrpcLiteral.Value)
                {
                    throw new JsonException(
                        "Expected \""
                            + JsonrpcLiteral.Value
                            + "\" for type discriminator but got \""
                            + value
                            + "\"."
                    );
                }
                return new JsonrpcLiteral();
            }

            public override void WriteAsPropertyName(
                Utf8JsonWriter writer,
                JsonrpcLiteral value,
                JsonSerializerOptions options
            ) => writer.WritePropertyName(JsonrpcLiteral.Value);
        }
    }
}
