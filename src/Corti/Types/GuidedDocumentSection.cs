using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// One section of a generated document, in template order. The `heading` is the section heading at generation time, after overrides. The `orderIndex` is the zero-based position in the template version's section list.
/// </summary>
[Serializable]
public record GuidedDocumentSection : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The section ID. Use this as the key into `stringDocument` and `structuredDocument`.
    /// </summary>
    [JsonPropertyName("sectionId")]
    public required string SectionId { get; set; }

    /// <summary>
    /// The section heading at generation time, after overrides.
    /// </summary>
    [JsonPropertyName("heading")]
    public required string Heading { get; set; }

    /// <summary>
    /// The zero-based position of this section in the template version's section list.
    /// </summary>
    [JsonPropertyName("orderIndex")]
    public required int OrderIndex { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
