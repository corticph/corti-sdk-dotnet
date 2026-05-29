using System.Text.Json.Serialization;
using Corti;
using Corti.Core;

namespace Corti.Documents;

[Serializable]
public record GuidedSectionsListRequest
{
    /// <summary>
    /// Filter sections by BCP 47 language tag (e.g. `fr`, `de`, or `en-GB`). Repeatable.
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

    /// <summary>
    /// Filter by source. Omit to return both. `user` returns only user-created sections; `corti` returns only Corti standard sections.
    /// </summary>
    [JsonIgnore]
    public GuidedSourceFilter? Source { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
