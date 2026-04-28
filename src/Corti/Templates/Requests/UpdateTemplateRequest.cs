using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record UpdateTemplateRequest
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("language")]
    public string? Language { get; set; }

    [JsonPropertyName("labels")]
    public IEnumerable<string>? Labels { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
