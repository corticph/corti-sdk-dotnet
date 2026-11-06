using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti;

[Serializable]
public record RecordingsListRequest
{
    /// <summary>
    /// Field used to sort recordings. Default is startedAt.
    /// </summary>
    [JsonIgnore]
    public RecordingsListRequestSort? Sort { get; set; }

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
