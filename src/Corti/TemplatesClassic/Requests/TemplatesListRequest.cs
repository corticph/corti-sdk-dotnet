using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record TemplatesListRequest
{
    /// <summary>
    /// Filter templates by organization.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Org { get; set; } = new List<string>();

    /// <summary>
    /// Filter templates by language.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Lang { get; set; } = new List<string>();

    /// <summary>
    /// Filter templates by their status.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Status { get; set; } = new List<string>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
