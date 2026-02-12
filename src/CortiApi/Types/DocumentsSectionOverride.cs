using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record DocumentsSectionOverride : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The key that references the section to use for document generation.
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    /// <summary>
    /// Overrides the section name used in document generation and response.
    /// </summary>
    [JsonPropertyName("nameOverride")]
    public string? NameOverride { get; set; }

    /// <summary>
    /// Overrides the section's default writing style with your custom prompt.
    /// </summary>
    [JsonPropertyName("writingStyleOverride")]
    public string? WritingStyleOverride { get; set; }

    /// <summary>
    /// Overrides the section's default format rule with your custom prompt.
    /// </summary>
    [JsonPropertyName("formatRuleOverride")]
    public string? FormatRuleOverride { get; set; }

    /// <summary>
    /// Overrides and sets the section-level additional instructions with your custom prompt.
    /// </summary>
    [JsonPropertyName("additionalInstructionsOverride")]
    public string? AdditionalInstructionsOverride { get; set; }

    /// <summary>
    /// Overrides the section's content prompt used for input assignment with documentationMode: routed_parallel, and section generation.
    /// </summary>
    [JsonPropertyName("contentOverride")]
    public string? ContentOverride { get; set; }

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
