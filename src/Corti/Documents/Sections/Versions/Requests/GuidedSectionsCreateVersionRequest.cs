using System.Text.Json.Serialization;
using Corti;
using Corti.Core;

namespace Corti.Documents.Sections;

[Serializable]
public record GuidedSectionsCreateVersionRequest
{
    [JsonPropertyName("generation")]
    public required GuidedSectionGenerationPartial Generation { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
