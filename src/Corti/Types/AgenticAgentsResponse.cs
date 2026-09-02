using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// A configured agent — its metadata, model, and attached connectors.
/// </summary>
[Serializable]
public record AgenticAgentsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Human-readable, unique-per-tenant agent name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Free-form agent description shown to users and in tooling.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// System prompt prepended to every invocation.
    /// </summary>
    [JsonPropertyName("systemPrompt")]
    public string? SystemPrompt { get; set; }

    /// <summary>
    /// Model identifier. Tenant default if omitted or `null`.
    /// **Open question** — in the current implementation a model is configured per *expert*, not per *agent* (`Expert.modelName`), and an `Agent` has no model field at all. The desired end state is that there is **no distinction between an expert and an agent**, so `model` lives uniformly on this resource. Until that convergence lands, the precedence of an agent-level `model` over a connector/expert-level override is undecided and MUST be resolved before this field ships.
    /// </summary>
    [JsonPropertyName("model")]
    public string? Model { get; set; }

    /// <summary>
    /// Effective cap on the orchestrator's ReAct loop iterations per run. Always present: agents created without `maxLoops` report the server default (10).
    /// </summary>
    [JsonPropertyName("maxLoops")]
    public required int MaxLoops { get; set; }

    [JsonPropertyName("visibility")]
    public required AgentsVisibility Visibility { get; set; }

    [JsonPropertyName("lifecycle")]
    public required AgentsLifecycle Lifecycle { get; set; }

    /// <summary>
    /// Connectors attached to the agent, discriminated by `type`.
    /// </summary>
    [JsonPropertyName("connectors")]
    public IEnumerable<CommonConnectorResponse> Connectors { get; set; } =
        new List<CommonConnectorResponse>();

    [JsonPropertyName("labels")]
    public Dictionary<string, string>? Labels { get; set; }

    /// <summary>
    /// When the agent was created.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// When the agent was last updated.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Principal (user or service principal) that created the agent.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("createdBy")]
    public string? CreatedBy { get; set; }

    /// <summary>
    /// When the agent expires; `null` means it does not expire. Ephemeral agents get a 24h expiry at creation time; persistent agents never expire.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("expiresAt")]
    public DateTime? ExpiresAt { get; set; }

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
