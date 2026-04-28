using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record CreateTemplateVersionRequest
{
    [JsonPropertyName("instructions")]
    public TemplateInstructions? Instructions { get; set; }

    [JsonPropertyName("sections")]
    public IEnumerable<TemplateVersionSectionRequest>? Sections { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
