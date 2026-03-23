using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// OAuth 2.0 refresh token grant. Optional client_secret for confidential clients (e.g. after ROPC or PKCE).
/// </summary>
[Serializable]
public record AuthTokenRequestRefresh : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Client identifier.
    /// </summary>
    [JsonPropertyName("client_id")]
    public required string ClientId { get; set; }

    /// <summary>
    /// Client secret. Optional for public clients (e.g. when refresh was issued via PKCE or ROPC).
    /// </summary>
    [JsonPropertyName("client_secret")]
    public string? ClientSecret { get; set; }

    [JsonRequired]
    [JsonPropertyName("grant_type")]
    public AuthTokenRequestRefresh.GrantTypeLiteral GrantType { get;
#if NET5_0_OR_GREATER
        init;
#else
        set;
#endif
    } = new();

    /// <summary>
    /// Refresh token received from a previous token response.
    /// </summary>
    [JsonPropertyName("refresh_token")]
    public required string RefreshToken { get; set; }

    /// <summary>
    /// Space-separated scopes. Optional; may request a subset of originally granted scopes.
    /// </summary>
    [JsonPropertyName("scope")]
    public string? Scope { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }

    [JsonConverter(typeof(GrantTypeLiteralConverter))]
    public readonly struct GrantTypeLiteral
    {
        public const string Value = "refresh_token";

        public static implicit operator string(GrantTypeLiteral _) => Value;

        public override string ToString() => Value;

        public override int GetHashCode() =>
            global::System.StringComparer.Ordinal.GetHashCode(Value);

        public override bool Equals(object? obj) => obj is GrantTypeLiteral;

        public static bool operator ==(GrantTypeLiteral _, GrantTypeLiteral __) => true;

        public static bool operator !=(GrantTypeLiteral _, GrantTypeLiteral __) => false;

        internal sealed class GrantTypeLiteralConverter : JsonConverter<GrantTypeLiteral>
        {
            public override GrantTypeLiteral Read(
                ref Utf8JsonReader reader,
                global::System.Type typeToConvert,
                JsonSerializerOptions options
            )
            {
                var value = reader.GetString();
                if (value != GrantTypeLiteral.Value)
                {
                    throw new JsonException(
                        "Expected \""
                            + GrantTypeLiteral.Value
                            + "\" for type discriminator but got \""
                            + value
                            + "\"."
                    );
                }
                return new GrantTypeLiteral();
            }

            public override void Write(
                Utf8JsonWriter writer,
                GrantTypeLiteral value,
                JsonSerializerOptions options
            ) => writer.WriteStringValue(GrantTypeLiteral.Value);

            public override GrantTypeLiteral ReadAsPropertyName(
                ref Utf8JsonReader reader,
                global::System.Type typeToConvert,
                JsonSerializerOptions options
            )
            {
                var value = reader.GetString();
                if (value != GrantTypeLiteral.Value)
                {
                    throw new JsonException(
                        "Expected \""
                            + GrantTypeLiteral.Value
                            + "\" for type discriminator but got \""
                            + value
                            + "\"."
                    );
                }
                return new GrantTypeLiteral();
            }

            public override void WriteAsPropertyName(
                Utf8JsonWriter writer,
                GrantTypeLiteral value,
                JsonSerializerOptions options
            ) => writer.WritePropertyName(GrantTypeLiteral.Value);
        }
    }
}
