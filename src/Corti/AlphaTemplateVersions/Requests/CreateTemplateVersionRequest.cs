using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record CreateTemplateVersionRequest
{
    [JsonPropertyName("generation")]
    public required CreateTemplateVersionRequestGeneration Generation { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
