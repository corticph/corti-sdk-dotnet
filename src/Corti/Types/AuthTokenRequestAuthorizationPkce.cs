using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// OAuth 2.0 authorization code grant with PKCE (no client secret; uses code_verifier).
/// </summary>
[Serializable]
public record AuthTokenRequestAuthorizationPkce : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Client identifier.
    /// </summary>
    [JsonPropertyName("client_id")]
    public required string ClientId { get; set; }

    [JsonRequired]
    [JsonPropertyName("grant_type")]
    public AuthTokenRequestAuthorizationPkce.GrantTypeLiteral GrantType { get;
#if NET5_0_OR_GREATER
        init;
#else
        set;
#endif
    } = new();

    /// <summary>
    /// Redirect URI used in the authorization request (must match exactly).
    /// </summary>
    [JsonPropertyName("redirect_uri")]
    public required string RedirectUri { get; set; }

    /// <summary>
    /// Authorization code received from the redirect.
    /// </summary>
    [JsonPropertyName("code")]
    public required string Code { get; set; }

    /// <summary>
    /// PKCE code verifier (matches the code_challenge used in the authorization request).
    /// </summary>
    [JsonPropertyName("code_verifier")]
    public required string CodeVerifier { get; set; }

    /// <summary>
    /// Space-separated scopes. Optional.
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
        public const string Value = "authorization_code";

        public static implicit operator string(GrantTypeLiteral _) => Value;

        public override string ToString() => Value;

        public override int GetHashCode() =>
            Value.GetHashCode(global::System.StringComparison.Ordinal);

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
        }
    }
}
