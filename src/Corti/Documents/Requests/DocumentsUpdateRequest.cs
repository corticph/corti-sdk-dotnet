using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti;

[Serializable]
public record DocumentsUpdateRequest
{
    /// <summary>
    /// An optional name for the document.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("sections")]
    public IEnumerable<DocumentsSectionInput>? Sections { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
