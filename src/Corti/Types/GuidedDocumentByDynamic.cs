using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// Generate a document from a fully inline template definition supplied in the request body. Sections and the wrapping template are created and immediately published as auto-generated resources. At least one of `context` or `interactionId` must be supplied as input context for the model.
/// </summary>
[Serializable]
public record GuidedDocumentByDynamic : IJsonOnDeserialized
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
    /// Fully inline template defined in the request body.
    /// </summary>
    [JsonPropertyName("dynamicTemplate")]
    public required GuidedDynamicRequest DynamicTemplate { get; set; }

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
