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

    [JsonPropertyName("grant_type")]
    public string GrantType
    {
        get => "refresh_token";
        set =>
            value.Assert(
                value == "refresh_token",
                string.Format("'GrantType' must be {0}", "refresh_token")
            );
    }

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
}
