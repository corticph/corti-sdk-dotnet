using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// Generate a document using a stored template. Optionally supply runtime overrides to patch instructions or sections without mutating the base template. At least one of `context` or `interactionId` must be supplied as input context for the model.
/// </summary>
[Serializable]
public record GuidedDocumentByTemplateRef : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Ordered list of context items the model reasons over. Each item is one of text, a transcript (with optional metadata and segments), or a single fact. Items are interleaved by timestamps where present on transcript segments; otherwise array order is preserved.
    /// </summary>
    [JsonPropertyName("context")]
    public IEnumerable<GuidedDocumentContext>? Context { get; set; }

    /// <summary>
    /// When supplied, all facts and transcripts already attached to the referenced interaction are passed implicitly as input context.
    /// </summary>
    [JsonPropertyName("interactionId")]
    public string? InteractionId { get; set; }

    /// <summary>
    /// Reference an existing stored template, optionally with overrides.
    /// </summary>
    [JsonPropertyName("templateRef")]
    public required GuidedTemplateRef TemplateRef { get; set; }

    /// <summary>
    /// The language in which the document will be generated as a BCP 47 tag.
    /// </summary>
    [JsonPropertyName("outputLanguage")]
    public required string OutputLanguage { get; set; }

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
