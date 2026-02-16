using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record TranscriptsListRequest
{
    /// <summary>
    /// Display full transcripts in listing
    /// </summary>
    [JsonIgnore]
    public bool? Full { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
