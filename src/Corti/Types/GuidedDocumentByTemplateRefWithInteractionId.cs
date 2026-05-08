using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record GuidedDocumentByTemplateRefWithInteractionId : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// When supplied, all facts and transcripts already attached to the referenced interaction are passed implicitly as input context.
    /// </summary>
    [JsonPropertyName("interactionId")]
    public required string InteractionId { get; set; }

    /// <summary>
    /// Reference an existing stored template, optionally with overrides.
    /// </summary>
    [JsonPropertyName("templateRef")]
    public required GuidedTemplateRef TemplateRef { get; set; }

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
