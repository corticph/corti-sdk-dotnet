using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

/// <summary>
/// Exchange an authorization code for tokens (after user redirect).
/// </summary>
[Serializable]
public record GetTokenRequestAuthorizationCode : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("grant_type")]
    public string GrantType { get; set; } = "authorization_code";

    /// <summary>
    /// Authorization code from the redirect
    /// </summary>
    [JsonPropertyName("code")]
    public required string Code { get; set; }

    [JsonPropertyName("redirect_uri")]
    public required string RedirectUri { get; set; }

    [JsonPropertyName("client_id")]
    public required string ClientId { get; set; }

    /// <summary>
    /// Required for confidential clients
    /// </summary>
    [JsonPropertyName("client_secret")]
    public string? ClientSecret { get; set; }

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
