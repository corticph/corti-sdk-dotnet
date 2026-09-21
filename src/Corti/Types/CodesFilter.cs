using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Optional filter to restrict the set of codes the model can predict.
/// </summary>
[Serializable]
public record CodesFilter : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Condition objects to include. When empty, the full set of codes for the requested systems is used.
    /// </summary>
    [JsonPropertyName("include")]
    public IEnumerable<CodesFilterCondition>? Include { get; set; }

    /// <summary>
    /// Condition objects to subtract from the include set.
    /// </summary>
    [JsonPropertyName("exclude")]
    public IEnumerable<CodesFilterCondition>? Exclude { get; set; }

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
