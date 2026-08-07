using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// An A2A agent card describing capabilities, skills, and supported interfaces.
/// </summary>
[Serializable]
public record AgenticAgentsAgentCard : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Agent display name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Agent description.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// A URL providing additional documentation about the agent.
    /// </summary>
    [JsonPropertyName("documentationUrl")]
    public string? DocumentationUrl { get; set; }

    /// <summary>
    /// Optional URL to an icon for the agent.
    /// </summary>
    [JsonPropertyName("iconUrl")]
    public string? IconUrl { get; set; }

    /// <summary>
    /// Agent card version (SemVer).
    /// </summary>
    [JsonPropertyName("version")]
    public required string Version { get; set; }

    /// <summary>
    /// Agent capability flags (streaming, push notifications).
    /// </summary>
    [JsonPropertyName("capabilities")]
    public required AgenticAgentsAgentCardCapabilities Capabilities { get; set; }

    /// <summary>
    /// Default input media types.
    /// </summary>
    [JsonPropertyName("defaultInputModes")]
    public IEnumerable<string>? DefaultInputModes { get; set; }

    /// <summary>
    /// Default output media types.
    /// </summary>
    [JsonPropertyName("defaultOutputModes")]
    public IEnumerable<string>? DefaultOutputModes { get; set; }

    /// <summary>
    /// Publishing organization and URL.
    /// </summary>
    [JsonPropertyName("provider")]
    public AgenticAgentsAgentCardProvider? Provider { get; set; }

    /// <summary>
    /// Security requirements for contacting the agent.
    /// </summary>
    [JsonPropertyName("securityRequirements")]
    public IEnumerable<Dictionary<string, object?>>? SecurityRequirements { get; set; }

    /// <summary>
    /// The security scheme details used for authenticating with this agent.
    /// </summary>
    [JsonPropertyName("securitySchemes")]
    public Dictionary<string, object?>? SecuritySchemes { get; set; }

    /// <summary>
    /// JSON Web Signatures (JWS, RFC 7515) computed for this agent card.
    /// </summary>
    [JsonPropertyName("signatures")]
    public IEnumerable<AgenticAgentsAgentCardSignaturesItem>? Signatures { get; set; }

    /// <summary>
    /// Skills the agent exposes.
    /// </summary>
    [JsonPropertyName("skills")]
    public IEnumerable<AgenticAgentsAgentCardSkillsItem>? Skills { get; set; }

    /// <summary>
    /// A2A protocol bindings. v2 advertises protocolVersion `1.0` only.
    /// </summary>
    [JsonPropertyName("supportedInterfaces")]
    public IEnumerable<AgenticAgentsAgentCardSupportedInterfacesItem> SupportedInterfaces { get; set; } =
        new List<AgenticAgentsAgentCardSupportedInterfacesItem>();

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
