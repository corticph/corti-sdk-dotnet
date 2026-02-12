using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;
using OneOf;

namespace CortiApi;

[Serializable]
public record AgentsAgent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The unique identifier of the agent.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The name of the agent.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// A brief description of the agent's capabilities.
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    /// <summary>
    /// The system prompt that defines the overall agents behavior and expectations.
    /// </summary>
    [JsonPropertyName("systemPrompt")]
    public required string SystemPrompt { get; set; }

    [JsonPropertyName("experts")]
    public IEnumerable<OneOf<AgentsExpert, AgentsExpertReference>>? Experts { get; set; }

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
