using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti;

[Serializable]
public record GuidedDocumentsListRequest
{
    /// <summary>
    /// Filter documents by template UUID.
    /// </summary>
    [JsonIgnore]
    public string? TemplateId { get; set; }

    /// <summary>
    /// Filter documents by interaction UUID.
    /// </summary>
    [JsonIgnore]
    public string? InteractionId { get; set; }

    /// <summary>
    /// Filter documents by label in `key:value` format. Repeatable; matches documents that have any of the given labels.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Label { get; set; } = new List<string>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
