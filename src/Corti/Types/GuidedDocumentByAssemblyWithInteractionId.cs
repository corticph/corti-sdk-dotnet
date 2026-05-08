using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// Generate a document by assembling a template from existing stored sections, with input context drawn implicitly from an existing interaction's facts and transcripts. The resulting template aggregate is auto-saved and can be referenced in future calls.
/// </summary>
[Serializable]
public record GuidedDocumentByAssemblyWithInteractionId : IJsonOnDeserialized
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
    /// Assemble a template from existing stored sections.
    /// </summary>
    [JsonPropertyName("assemblyTemplate")]
    public required GuidedAssemblyRequest AssemblyTemplate { get; set; }

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
