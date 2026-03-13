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

    [JsonPropertyName("grant_type")]
    public string GrantType
    {
        get => "authorization_code";
        set =>
            value.Assert(
                value == "authorization_code",
                string.Format("'GrantType' must be {0}", "authorization_code")
            );
    }

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
}
