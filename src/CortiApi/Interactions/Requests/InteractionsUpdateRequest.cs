using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record InteractionsUpdateRequest
{
    /// <summary>
    /// The unique identifier of the interaction. Must be a valid UUID.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <summary>
    /// The unique identifier of the medical professional responsible for this interaction.  If nulled, automatically set to a uuid.
    /// </summary>
    [JsonPropertyName("assignedUserId")]
    public string? AssignedUserId { get; set; }

    /// <summary>
    /// Details of the encounter being updated.
    /// </summary>
    [JsonPropertyName("encounter")]
    public InteractionsEncounterUpdateRequest? Encounter { get; set; }

    /// <summary>
    /// Patient-related updates.
    /// </summary>
    [JsonPropertyName("patient")]
    public InteractionsPatient? Patient { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
