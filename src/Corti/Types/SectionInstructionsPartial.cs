using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// Partial form of SectionInstructions used when inheriting from another section. Any field omitted is inherited.
/// </summary>
[Serializable]
public record SectionInstructionsPartial : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Override the inherited content prompt.
    /// </summary>
    [JsonPropertyName("contentPrompt")]
    public string? ContentPrompt { get; set; }

    /// <summary>
    /// Override the inherited writing style prompt.
    /// </summary>
    [JsonPropertyName("writingStylePrompt")]
    public string? WritingStylePrompt { get; set; }

    /// <summary>
    /// Override the inherited misc prompt.
    /// </summary>
    [JsonPropertyName("miscPrompt")]
    public string? MiscPrompt { get; set; }

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
