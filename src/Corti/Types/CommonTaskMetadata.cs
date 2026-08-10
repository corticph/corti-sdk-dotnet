using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Free-form A2A task metadata. Corti's first-party keys are prefixed with
/// `$` (à la Mixpanel) to set them apart from caller-supplied keys. Token and
/// credit accounting is carried under `$usage`. Arbitrary additional keys are
/// permitted.
/// </summary>
[Serializable]
public record CommonTaskMetadata : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [JsonPropertyName("$usage")]
    public CommonUsage? Usage { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
