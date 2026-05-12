using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// Generation result. The shape mirrors the resolved template's section output schemas.
/// </summary>
[Serializable]
public record GuidedGenerationResult : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The generated document as a map of section key to rendered string output.
    /// </summary>
    [JsonPropertyName("stringDocument")]
    public Dictionary<string, string>? StringDocument { get; set; }

    /// <summary>
    /// The generated document as a structured object keyed by section.
    /// </summary>
    [JsonPropertyName("structuredDocument")]
    public Dictionary<string, object?>? StructuredDocument { get; set; }

    [JsonPropertyName("usage")]
    public GuidedGenerationResultUsage? Usage { get; set; }

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
