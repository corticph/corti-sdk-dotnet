using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record GuidedFieldDefinition : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Use to set a key to reference.
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    /// <summary>
    /// Guide the LLM in what to output for this node. Supplements the section-level instructions.
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    /// <summary>
    /// Must be another output schema node (string, number, boolean, array, or object).
    /// </summary>
    [JsonPropertyName("value")]
    public required GuidedOutputSchema Value { get; set; }

    /// <summary>
    /// If nothing is outputted for this field, this default value is used in the rendered output.
    /// </summary>
    [JsonPropertyName("default")]
    public string? Default { get; set; }

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
