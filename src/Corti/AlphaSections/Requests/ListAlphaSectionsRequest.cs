using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record ListAlphaSectionsRequest
{
    /// <summary>
    /// Filter sections by BCP 47 language subtag (e.g. `fr`, `de`). Repeatable.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Lang { get; set; } = new List<string>();

    /// <summary>
    /// Filter sections by ISO 3166-1 alpha-3 region code (e.g. `BEL`). Repeatable.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Region { get; set; } = new List<string>();

    /// <summary>
    /// Filter sections by clinical specialty. Repeatable.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Specialty { get; set; } = new List<string>();

    /// <summary>
    /// Filter sections by label in `key:value` format. Repeatable; matches sections that have any of the given labels.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Label { get; set; } = new List<string>();

    /// <summary>
    /// Filter by publish status. Omit to return both published and unpublished items; set to `true` for published only, `false` for unpublished only.
    /// </summary>
    [JsonIgnore]
    public bool? Published { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
