using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record AgentsUpdateAgent
{
    /// <summary>
    /// The name of the agent.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The system prompt that defines the overall agents behavior and expectations. This field is optional as there is a default system orchestrator.
    /// </summary>
    [JsonPropertyName("systemPrompt")]
    public string? SystemPrompt { get; set; }

    /// <summary>
    /// A brief description of the agent's capabilities.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("experts")]
    public IEnumerable<AgentsUpdateAgentExpertsItem>? Experts { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
