using Corti;
using Corti.Core;
using global::System.Text.Json.Serialization;

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
