using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti;

[Serializable]
public record TranscriptsListRequest
{
    /// <summary>
    /// Display full transcripts in listing
    /// </summary>
    [JsonIgnore]
    public bool? Full { get; set; }

    /// <summary>
    /// Return only the transcripts of this recording. Must be a valid UUID.
    /// </summary>
    [JsonIgnore]
    public string? RecordingId { get; set; }

    /// <summary>
    /// Field used to sort transcripts. Default is createdAt.
    /// </summary>
    [JsonIgnore]
    public TranscriptsListRequestSort? Sort { get; set; }

    /// <summary>
    /// Sorting order. Allowed values: [asc, desc]. Default is desc.
    /// </summary>
    [JsonIgnore]
    public CommonSortingDirectionEnum? Direction { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
