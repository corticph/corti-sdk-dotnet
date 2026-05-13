using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti.Documents;

[Serializable]
public record ListTemplatesRequest
{
    /// <summary>
    /// Filter templates by language (BCP 47 tag). Repeatable.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Lang { get; set; } = new List<string>();

    /// <summary>
    /// Filter templates by label. Repeatable; matches templates that have any of the given labels.
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
