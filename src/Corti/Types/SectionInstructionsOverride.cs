using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// Partial section-instructions patch used in override and fork contexts. Each field is independent: provide only the fields you want to replace, and any field you omit is inherited from the parent's published version.
/// </summary>
[Serializable]
public record SectionInstructionsOverride : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// When provided, replaces the section's content prompt. Omit to inherit from the parent.
    /// </summary>
    [JsonPropertyName("contentPrompt")]
    public string? ContentPrompt { get; set; }

    /// <summary>
    /// When provided, replaces the section's writing style prompt. Omit to inherit from the parent.
    /// </summary>
    [JsonPropertyName("writingStylePrompt")]
    public string? WritingStylePrompt { get; set; }

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
