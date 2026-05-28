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
