using Corti;
using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti.Agentic;

[Serializable]
public record GetUsageRequest
{
    /// <summary>
    /// Inclusive start of the range, as an RFC 3339 timestamp (UTC).
    /// Defaults to 30 days before `to`. Must not be after `to`.
    /// </summary>
    [JsonIgnore]
    public DateTime? From { get; set; }

    /// <summary>
    /// Exclusive end of the range, as an RFC 3339 timestamp (UTC).
    /// Defaults to the current time.
    /// </summary>
    [JsonIgnore]
    public DateTime? To { get; set; }

    /// <summary>
    /// Size of each reporting bucket. Defaults to `day`.
    /// </summary>
    [JsonIgnore]
    public UsageGranularity? Granularity { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
