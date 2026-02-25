using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record AgentsAgentCard : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The version of the A2A protocol this agents supports.
    /// </summary>
    [JsonPropertyName("protocolVersion")]
    public required string ProtocolVersion { get; set; }

    /// <summary>
    /// The name of the agent.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// A human readable description of the agent.
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    /// <summary>
    /// The URL where the agent can be reached to process messages.
    /// </summary>
    [JsonPropertyName("url")]
    public required string Url { get; set; }

    [JsonPropertyName("preferredTransport")]
    public string? PreferredTransport { get; set; }

    /// <summary>
    /// A list of additional transport protocols and URL combinations  the agent supports.
    /// </summary>
    [JsonPropertyName("additionalInterfaces")]
    public IEnumerable<AgentsAgentInterface>? AdditionalInterfaces { get; set; }

    /// <summary>
    /// A URL to an icon representing the agent.
    /// </summary>
    [JsonPropertyName("iconUrl")]
    public string? IconUrl { get; set; }

    /// <summary>
    /// A URL to documentation describing how to interact with the agent.
    /// </summary>
    [JsonPropertyName("documentationUrl")]
    public string? DocumentationUrl { get; set; }

    [JsonPropertyName("provider")]
    public AgentsAgentProvider? Provider { get; set; }

    /// <summary>
    /// The version of the agent.
    /// </summary>
    [JsonPropertyName("version")]
    public required string Version { get; set; }

    [JsonPropertyName("capabilities")]
    public required AgentsAgentCapabilities Capabilities { get; set; }

    /// <summary>
    /// A declaration of the security schemes available to authorize requests. The key is the scheme name. Follows the OpenAPI 3.0 Security Scheme Object.
    /// </summary>
    [JsonPropertyName("securitySchemes")]
    public Dictionary<string, object?>? SecuritySchemes { get; set; }

    /// <summary>
    /// A list of security requirement objects that apply to all agent interactions. Each object lists security schemes that can be used. Follows the OpenAPI 3.0 Security Requirement Object. This list can be seen as an OR of ANDs. Each object in the list describes one possible set of security requirements that must be present on a request. This allows specifying, for example, "callers must either use OAuth OR an API Key AND mTLS."
    /// </summary>
    [JsonPropertyName("security")]
    public Dictionary<string, object?>? Security { get; set; }

    /// <summary>
    /// Default set of supported input MIME types for all skills, which can be overridden on a per-skill basis.
    /// </summary>
    [JsonPropertyName("defaultInputModes")]
    public IEnumerable<string> DefaultInputModes { get; set; } = new List<string>();

    /// <summary>
    /// Default set of supported output MIME types for all skills, which can be overridden on a per-skill basis.
    /// </summary>
    [JsonPropertyName("defaultOutputModes")]
    public IEnumerable<string> DefaultOutputModes { get; set; } = new List<string>();

    /// <summary>
    /// The set of skills, or distinct capabilities, that the agent can perform.
    /// </summary>
    [JsonPropertyName("skills")]
    public IEnumerable<AgentsAgentSkill> Skills { get; set; } = new List<AgentsAgentSkill>();

    /// <summary>
    /// Indicates whether the agent supports returning an extended agent card when called with authentication.
    /// </summary>
    [JsonPropertyName("supportsAuthenticatedExtendedCard")]
    public bool? SupportsAuthenticatedExtendedCard { get; set; }

    /// <summary>
    /// JSON Web Signatures computed for this AgentCard.
    /// </summary>
    [JsonPropertyName("signatures")]
    public IEnumerable<AgentsAgentCardSignature>? Signatures { get; set; }

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
