using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record DocumentsCreateRequestWithTemplate : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// An array of context objects. Currently only accepts multiple objects when of type `transcript`. See [guide](/textgen/documents-standard#generate-document-from-transcript-as-input).
    /// </summary>
    [JsonPropertyName("context")]
    public IEnumerable<DocumentsContext> Context { get; set; } = new List<DocumentsContext>();

    /// <summary>
    /// Template details if the template should be generated during the request.
    /// </summary>
    [JsonPropertyName("template")]
    public required DocumentsTemplate Template { get; set; }

    /// <summary>
    /// An optional name for the document.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The language in which the document will be generated. Check [languages page](/about/languages) for more.
    /// </summary>
    [JsonPropertyName("outputLanguage")]
    public required string OutputLanguage { get; set; }

    /// <summary>
    /// Set to true to disable guardrails during document generation, default is false.
    /// </summary>
    [JsonPropertyName("disableGuardrails")]
    public bool? DisableGuardrails { get; set; }

    [JsonPropertyName("documentationMode")]
    public TemplatesDocumentationModeEnum? DocumentationMode { get; set; }

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
