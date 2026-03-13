using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record AgentsMcpServer : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier for the MCP server.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Name of the MCP server.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Type of transport used by the MCP server.
    /// </summary>
    [JsonPropertyName("transportType")]
    public required AgentsMcpServerTransportType TransportType { get; set; }

    /// <summary>
    /// Type of authorization used by the MCP server.
    /// </summary>
    [JsonPropertyName("authorizationType")]
    public required AgentsMcpServerAuthorizationType AuthorizationType { get; set; }

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
