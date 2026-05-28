using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti.Documents;

[Serializable]
public record GuidedTemplatesListRequest
{
    /// <summary>
    /// Filter templates by BCP 47 language tag (e.g. `fr`, `de`, or `en-GB`). Repeatable.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Lang { get; set; } = new List<string>();

    /// <summary>
    /// Filter templates by ISO 3166-1 alpha-3 region code (e.g. `BEL`). Repeatable.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Region { get; set; } = new List<string>();

    /// <summary>
    /// Filter templates by clinical specialty. Repeatable.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Specialty { get; set; } = new List<string>();

    /// <summary>
    /// Filter templates by label in `key:value` format. Repeatable; matches templates that have any of the given labels.
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
