using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti.Documents.Templates;

[Serializable]
public record GuidedTemplatesCreateVersionRequest
{
    [JsonPropertyName("generation")]
    public required GuidedTemplatesCreateVersionRequestGeneration Generation { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
