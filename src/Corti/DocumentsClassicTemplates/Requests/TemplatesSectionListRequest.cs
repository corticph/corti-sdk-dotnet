using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record TemplatesSectionListRequest
{
    /// <summary>
    /// Filter template sections by organization.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Org { get; set; } = new List<string>();

    /// <summary>
    /// Filter template sections by language.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Lang { get; set; } = new List<string>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
