using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti;

[Serializable]
public record GuidedDocumentsUpdateRequest
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("stringDocument")]
    public Dictionary<string, string>? StringDocument { get; set; }

    [JsonPropertyName("structuredDocument")]
    public Dictionary<string, object?>? StructuredDocument { get; set; }

    /// <summary>
    /// Replace the document's labels. Omit to leave labels unchanged; pass `[]` to clear all labels.
    /// </summary>
    [JsonPropertyName("labels")]
    public IEnumerable<GuidedLabel>? Labels { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
