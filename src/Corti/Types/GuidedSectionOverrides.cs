using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// Patches a section's content at link time without mutating the underlying section. Override semantics are per-field for instructions (any field you omit is inherited from the parent's published version) and wholesale for `outputSchema` (whatever you submit fully replaces the parent schema). The same applies when a section is forked via `inheritFromId`.
/// </summary>
[Serializable]
public record GuidedSectionOverrides : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// When provided, replaces the section's heading for this call.
    /// </summary>
    [JsonPropertyName("heading")]
    public string? Heading { get; set; }

    [JsonPropertyName("instructions")]
    public GuidedSectionInstructionsOverride? Instructions { get; set; }

    /// <summary>
    /// When provided, fully replaces the parent's output schema.
    /// </summary>
    [JsonPropertyName("outputSchema")]
    public GuidedOutputSchema? OutputSchema { get; set; }

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
