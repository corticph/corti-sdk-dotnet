using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record InteractionsGetResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier for the interaction.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// A unique identifier for the medical professional responsible for this interaction. If nulled, automatically set to a uuid.
    /// </summary>
    [JsonPropertyName("assignedUserId")]
    public required string AssignedUserId { get; set; }

    /// <summary>
    /// Information about the encounter, including type, status, and timing.
    /// </summary>
    [JsonPropertyName("encounter")]
    public required InteractionsEncounterResponse Encounter { get; set; }

    /// <summary>
    /// Details about the patient involved in the interaction, if applicable.
    /// </summary>
    [JsonPropertyName("patient")]
    public required InteractionsPatient Patient { get; set; }

    /// <summary>
    /// The timestamp when the interaction concluded (UTC).
    /// </summary>
    [JsonPropertyName("endedAt")]
    public DateTime? EndedAt { get; set; }

    /// <summary>
    /// The timestamp when the interaction was started (UTC).
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The timestamp when the interaction was last modified (UTC).
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public required DateTime UpdatedAt { get; set; }

    /// <summary>
    /// WebSocket URL for streaming real-time interactions. Append a token in the format: /interactions/{interactionID}/streams?token=Bearer token-value-here
    /// </summary>
    [JsonPropertyName("websocketUrl")]
    public required string WebsocketUrl { get; set; }

    /// <summary>
    /// The timestamp indicating the last recorded update for this interaction.
    /// </summary>
    [JsonPropertyName("lastUpdated")]
    public required DateTime LastUpdated { get; set; }

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
