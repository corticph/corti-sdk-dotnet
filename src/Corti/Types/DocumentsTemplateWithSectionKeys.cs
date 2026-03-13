using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record DocumentsTemplateWithSectionKeys : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// An array of section keys.
    /// </summary>
    [JsonPropertyName("sectionKeys")]
    public IEnumerable<string> SectionKeys { get; set; } = new List<string>();

    /// <summary>
    /// The name of the document.
    /// </summary>
    [JsonPropertyName("documentName")]
    public string? DocumentName { get; set; }

    /// <summary>
    /// Any additional instructions to be considered during document generation.
    /// </summary>
    [JsonPropertyName("additionalInstructions")]
    public string? AdditionalInstructions { get; set; }

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
