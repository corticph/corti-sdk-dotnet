using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// Generate a document by assembling a template from existing stored sections. The resulting template aggregate is auto-saved and can be referenced in future calls. At least one of `context` or `interactionId` must be supplied as input context for the model.
/// </summary>
[Serializable]
public record GuidedDocumentByAssembly : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
