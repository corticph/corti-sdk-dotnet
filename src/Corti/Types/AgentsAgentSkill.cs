using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record AgentsAgentSkill : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier for the skill.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The name of the skill.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// A brief description of the skill's capabilities.
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    /// <summary>
    /// A list of tags or keywords associated with the skill, useful for categorization and search.
    /// </summary>
    [JsonPropertyName("tags")]
    public IEnumerable<string> Tags { get; set; } = new List<string>();

    /// <summary>
    /// A list of example messages that demonstrate how to use this skill.
    /// </summary>
    [JsonPropertyName("examples")]
    public IEnumerable<AgentsMessage>? Examples { get; set; }

    /// <summary>
    /// A list of supported input MIME types for this skill. If omitted, the agent's default input modes apply.
    /// </summary>
    [JsonPropertyName("inputModes")]
    public IEnumerable<string>? InputModes { get; set; }

    /// <summary>
    /// A list of supported output MIME types for this skill. If omitted, the agent's default output modes apply.
    /// </summary>
    [JsonPropertyName("outputModes")]
    public IEnumerable<string>? OutputModes { get; set; }

    /// <summary>
    /// Security schemes necessary for the agent to leverage this skill. As in the overall AgentCard.security, this list represents a logical OR of security requirement objects. Each object is a set of security schemes that must be used together (a logical AND).
    /// </summary>
    [JsonPropertyName("security")]
    public Dictionary<string, object?>? Security { get; set; }

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
