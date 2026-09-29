using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Authentication configuration for an outbound connector.
/// </summary>
[Serializable]
public record CommonConnectorAuth : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Authentication mechanism.
    /// `inherit` forwards the caller's bearer token to the MCP server,
    /// which is required for internal MCP gateways that expect the
    /// Corti platform token for auth.
    /// </summary>
    [JsonPropertyName("type")]
    public required CommonConnectorAuthType Type { get; set; }

    /// <summary>
    /// OAuth2 scope requested.
    /// </summary>
    [JsonPropertyName("scope")]
    public string? Scope { get; set; }

    /// <summary>
    /// OAuth2 redirect URL.
    /// </summary>
    [JsonPropertyName("redirectUrl")]
    public string? RedirectUrl { get; set; }

    /// <summary>
    /// Reference to a server-side stored secret. Mutually exclusive with inline credentials passed at call time.
    /// </summary>
    [JsonPropertyName("ref")]
    public string? Ref { get; set; }

    /// <summary>
    /// Header names the MCP server requires the client to send in the authorization data part. The client must supply values for each listed name; missing headers trigger an auth-required challenge that lists them.
    /// </summary>
    [JsonPropertyName("requiredHeaders")]
    public IEnumerable<string>? RequiredHeaders { get; set; }

    /// <summary>
    /// Header names the client may optionally send. Headers not in requiredHeaders or optionalHeaders are rejected as undeclared.
    /// </summary>
    [JsonPropertyName("optionalHeaders")]
    public IEnumerable<string>? OptionalHeaders { get; set; }

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
