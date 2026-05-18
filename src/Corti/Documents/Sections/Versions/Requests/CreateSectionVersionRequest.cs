using System.Text.Json.Serialization;
using Corti;
using Corti.Core;

namespace Corti.Documents.Sections;

[Serializable]
public record CreateSectionVersionRequest
{
    [JsonPropertyName("generation")]
    public required SectionGeneration Generation { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
