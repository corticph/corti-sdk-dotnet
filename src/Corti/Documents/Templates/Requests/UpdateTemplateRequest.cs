using System.Text.Json.Serialization;
using Corti;
using Corti.Core;

namespace Corti.Documents;

[Serializable]
public record UpdateTemplateRequest
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("languages")]
    public IEnumerable<string>? Languages { get; set; }

    [JsonPropertyName("regions")]
    public IEnumerable<string>? Regions { get; set; }

    [JsonPropertyName("specialties")]
    public IEnumerable<string>? Specialties { get; set; }

    [JsonPropertyName("labels")]
    public IEnumerable<Label>? Labels { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
