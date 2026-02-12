using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record DocumentsUpdateRequest
{
    /// <summary>
    /// The unique identifier of the interaction. Must be a valid UUID.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <summary>
    /// The document ID representing the context for the request. Must be a valid UUID.
    /// </summary>
    [JsonIgnore]
    public required string DocumentId { get; set; }

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
