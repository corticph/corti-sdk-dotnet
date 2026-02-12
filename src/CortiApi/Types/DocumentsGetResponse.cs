using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record DocumentsGetResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique ID of the generated document
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Name of the generated document
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Reference for the used template
    /// </summary>
    [JsonPropertyName("templateRef")]
    public required string TemplateRef { get; set; }

    [JsonPropertyName("isStream")]
    public required bool IsStream { get; set; }

    /// <summary>
    /// Individual document sections
    /// </summary>
    [JsonPropertyName("sections")]
    public IEnumerable<DocumentsSection> Sections { get; set; } = new List<DocumentsSection>();

    /// <summary>
    /// The original timestamp when the document was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The timestamp when the document was last updated.
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public required DateTime UpdatedAt { get; set; }

    /// <summary>
    /// The language in which the document will be generated. Check https://docs.corti.ai/about/languages for more.
    /// </summary>
    [JsonPropertyName("outputLanguage")]
    public required string OutputLanguage { get; set; }

    [JsonPropertyName("usageInfo")]
    public required CommonUsageInfo UsageInfo { get; set; }

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
