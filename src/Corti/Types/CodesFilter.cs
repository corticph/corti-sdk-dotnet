using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

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
    /// Codes or categories to include. When empty, the full set of codes for the requested systems is used.
    /// </summary>
    [JsonPropertyName("include")]
    public IEnumerable<string>? Include { get; set; }

    /// <summary>
    /// Codes or categories to subtract from the include set.
    /// </summary>
    [JsonPropertyName("exclude")]
    public IEnumerable<string>? Exclude { get; set; }

    /// <summary>
    /// When true (default), category codes are expanded to their leaf codes.
    /// </summary>
    [JsonPropertyName("expand")]
    public bool? Expand { get; set; }

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
