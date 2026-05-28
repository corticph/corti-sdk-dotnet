using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti.Documents.Templates;

[Serializable]
public record GuidedTemplatesCreateVersionRequest
{
    /// <summary>
    /// When the template inherits from another template, all inner fields are optional. Any field omitted is inherited from the parent's published version.
    /// </summary>
    [JsonPropertyName("generation")]
    public required GuidedTemplatesCreateVersionRequestGeneration Generation { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
