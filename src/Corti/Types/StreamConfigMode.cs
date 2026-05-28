using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record StreamConfigMode : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Processing mode
    /// </summary>
    [JsonPropertyName("type")]
    public required StreamConfigModeType Type { get; set; }

    /// <summary>
    /// Output language locale specific to facts.
    /// </summary>
    [JsonPropertyName("outputLocale")]
    public string? OutputLocale { get; set; }

    /// <summary>
    /// Rate at which fact generation should process and return results. If no value is set, the default is `fixed` and will trigger fact generation at the standard interval of around 60s. With `fast_init`, fact generation will follow a logarithmic curve.
    /// </summary>
    [JsonPropertyName("factGenerationInterval")]
    public StreamConfigModeFactGenerationInterval? FactGenerationInterval { get; set; }

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
