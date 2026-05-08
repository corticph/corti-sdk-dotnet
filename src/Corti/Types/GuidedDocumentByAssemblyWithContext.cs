using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record GuidedDocumentByAssemblyWithContext : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Ordered list of context items the model reasons over. Each item is one of text, a transcript (with optional metadata and segments), or a batch of facts. Items are interleaved by timestamps where present on transcript segments; otherwise array order is preserved.
    /// </summary>
    [JsonPropertyName("context")]
    public IEnumerable<GuidedDocumentContext> Context { get; set; } =
        new List<GuidedDocumentContext>();

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
