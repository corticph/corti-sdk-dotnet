using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// Generate a document from a fully inline template definition supplied in the request body, with input context drawn implicitly from an existing interaction's facts and transcripts. Sections and the wrapping template are created and immediately published as auto-generated resources.
/// </summary>
[Serializable]
public record GuidedDocumentByDynamicWithInteractionId : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// All facts and transcripts already attached to the referenced interaction are passed implicitly as input context.
    /// </summary>
    [JsonPropertyName("interactionId")]
    public required string InteractionId { get; set; }

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
