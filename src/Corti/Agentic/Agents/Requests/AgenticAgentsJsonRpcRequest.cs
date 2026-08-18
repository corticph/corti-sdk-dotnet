using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti.Agentic;

[Serializable]
public record AgenticAgentsJsonRpcRequest
{
    /// <summary>
    /// A2A protocol version in `Major.Minor` form (A2A §3.6). Optional; defaults to `1.0` when absent. This surface implements `1.0` only. Patch versions MUST NOT be sent and are not considered during negotiation.
    /// </summary>
    [JsonIgnore]
    public string A2AVersion { get; set; } = "1.0";

    /// <summary>
    /// JSON-RPC protocol version; always `2.0`.
    /// </summary>
    [JsonRequired]
    [JsonPropertyName("jsonrpc")]
    public AgenticAgentsJsonRpcRequest.JsonrpcLiteral Jsonrpc { get;
#if NET5_0_OR_GREATER
        init;
#else
        set;
#endif
    } = new();

    [JsonPropertyName("id")]
    public required AgenticAgentsJsonRpcRequestId Id { get; set; }

    /// <summary>
    /// JSON-RPC method name (PascalCase on the wire).
    /// </summary>
    [JsonPropertyName("method")]
    public required AgenticAgentsJsonRpcRequestMethod Method { get; set; }

    /// <summary>
    /// JSON-RPC params object.
    /// </summary>
    [JsonPropertyName("params")]
    public Dictionary<string, object?>? Params { get; set; }

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
