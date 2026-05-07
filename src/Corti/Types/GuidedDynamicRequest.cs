using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// Fully inline template definition. Sections and the wrapping template are created and immediately published as auto-generated resources.
/// </summary>
[Serializable]
public record GuidedDynamicRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// BCP 47 language tag.
    /// </summary>
    [JsonPropertyName("language")]
    public required string Language { get; set; }

    [JsonPropertyName("generation")]
    public required GuidedDynamicInline Generation { get; set; }

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
