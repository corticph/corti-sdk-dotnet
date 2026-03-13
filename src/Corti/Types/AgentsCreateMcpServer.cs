using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record AgentsCreateMcpServer : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Name of the MCP server.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// A brief description of the MCP server's capabilities.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Type of transport used by the MCP server.
    /// </summary>
    [JsonPropertyName("transportType")]
    public required AgentsCreateMcpServerTransportType TransportType { get; set; }

    /// <summary>
    /// Type of authorization used by the MCP server.
    /// </summary>
    [JsonPropertyName("authorizationType")]
    public required AgentsCreateMcpServerAuthorizationType AuthorizationType { get; set; }

    /// <summary>
    /// OAuth2.0 authorization scope to request.
    /// </summary>
    [JsonPropertyName("authorizationScope")]
    public string? AuthorizationScope { get; set; }

    /// <summary>
    /// URL of the MCP server.
    /// </summary>
    [JsonPropertyName("url")]
    public required string Url { get; set; }

    /// <summary>
    /// Redirect URI for OAuth2.0 authorization.
    /// </summary>
    [JsonPropertyName("redirectUrl")]
    public string? RedirectUrl { get; set; }

    /// <summary>
    /// Bearer token to be used in MCP client.
    /// </summary>
    [JsonPropertyName("token")]
    public string? Token { get; set; }

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
