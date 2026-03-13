using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record InteractionsListRequest
{
    /// <summary>
    /// Field used to sort interactions. Default is createdAt.
    /// </summary>
    [JsonIgnore]
    public InteractionsListRequestSort? Sort { get; set; }

    /// <summary>
    /// Sorting order. Allowed values: [asc, desc]. Default is desc.
    /// </summary>
    [JsonIgnore]
    public CommonSortingDirectionEnum? Direction { get; set; }

    /// <summary>
    /// Number of interactions to return per page. Must be greater than 0. Default is 10.
    /// </summary>
    [JsonIgnore]
    public long? PageSize { get; set; }

    /// <summary>
    /// Page number to retrieve. Starts at 1. For example, index=2 with pageSize=10 will return interactions 11–20. Must be greater than 0. Default is 1.
    /// </summary>
    [JsonIgnore]
    public long? Index { get; set; }

    /// <summary>
    /// The status of the encounter. To filter on multiple statuses, pass the same parameter again.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<InteractionsEncounterStatusEnum> EncounterStatus { get; set; } =
        new List<InteractionsEncounterStatusEnum>();

    /// <summary>
    /// A unique identifier for the patient.
    /// </summary>
    [JsonIgnore]
    public string? Patient { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
