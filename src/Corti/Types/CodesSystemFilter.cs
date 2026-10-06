using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// System-scoped filter to restrict the set of codes the model can predict for a single coding system.
/// </summary>
[Serializable]
public record CodesSystemFilter : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The coding system this filter applies to. Must match one of the systems in the `system` field.
    /// </summary>
    [JsonPropertyName("systemId")]
    public required string SystemId { get; set; }

    /// <summary>
    /// Codes matching this group of conditions are eligible. Omitted means every code in the system is eligible.
    /// </summary>
    [JsonPropertyName("include")]
    public CodesConditionGroup? Include { get; set; }

    /// <summary>
    /// Codes matching this group of conditions are removed from the eligible set. Omitted means nothing is removed.
    /// </summary>
    [JsonPropertyName("exclude")]
    public CodesConditionGroup? Exclude { get; set; }

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
