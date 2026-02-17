using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record AgentsCreateAgent
{
    /// <summary>
    /// If set to true, the agent will be created as ephemeral, it won't be listed in the agents_list but can still be fetched by ID. Ephemeral agents will be deleted periodically.
    /// </summary>
    [JsonIgnore]
    public bool? Ephemeral { get; set; }

    /// <summary>
    /// The name of the agent.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Optional type of agent.
    /// </summary>
    [JsonPropertyName("agentType")]
    public AgentsCreateAgentAgentType? AgentType { get; set; }

    /// <summary>
    /// The system prompt that defines the overall agents behavior and expectations. This field is optional as there is a default system orchestrator.
    /// </summary>
    [JsonPropertyName("systemPrompt")]
    public string? SystemPrompt { get; set; }

    /// <summary>
    /// A brief description of the agent's capabilities.
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    [JsonPropertyName("experts")]
    public IEnumerable<AgentsCreateAgentExpertsItem>? Experts { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
