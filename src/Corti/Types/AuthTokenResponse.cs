using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// Successful token response (Keycloak/OIDC token endpoint).
/// </summary>
[Serializable]
public record AuthTokenResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Short-lived JWT access token (e.g. 5 minutes).
    /// </summary>
    [JsonPropertyName("access_token")]
    public required string AccessToken { get; set; }

    /// <summary>
    /// Token lifetime in seconds.
    /// </summary>
    [JsonPropertyName("expires_in")]
    public required int ExpiresIn { get; set; }

    /// <summary>
    /// Refresh token lifetime in seconds (0 if refresh not supported).
    /// </summary>
    [JsonPropertyName("refresh_expires_in")]
    public int? RefreshExpiresIn { get; set; }

    [JsonPropertyName("token_type")]
    public required string TokenType { get; set; }

    /// <summary>
    /// OpenID Connect ID token JWT (when scope includes openid).
    /// </summary>
    [JsonPropertyName("id_token")]
    public string? IdToken { get; set; }

    /// <summary>
    /// Keycloak not-before policy (seconds).
    /// </summary>
    [JsonPropertyName("not-before-policy")]
    public int? NotBeforePolicy { get; set; }

    /// <summary>
    /// Granted scope(s), space-separated.
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
