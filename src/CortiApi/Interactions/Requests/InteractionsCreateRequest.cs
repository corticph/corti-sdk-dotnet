using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record InteractionsCreateRequest
{
    /// <summary>
    /// A unique identifier for the medical professional responsible for this interaction. If nulled, automatically set to a uuid.
    /// </summary>
    [JsonPropertyName("assignedUserId")]
    public string? AssignedUserId { get; set; }

    /// <summary>
    /// Details about the encounter.
    /// </summary>
    [JsonPropertyName("encounter")]
    public required InteractionsEncounterCreateRequest Encounter { get; set; }

    /// <summary>
    /// Optional patient details.
    /// </summary>
    [JsonPropertyName("patient")]
    public InteractionsPatient? Patient { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
