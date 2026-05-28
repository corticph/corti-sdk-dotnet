using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record GuidedSectionsCreatePolicyRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("kind")]
    public required GuidedTemplatePolicyKind Kind { get; set; }

    /// <summary>
    /// Required when `kind` is `customers`. List of customer tenant identifiers that should have access.
    /// </summary>
    [JsonPropertyName("customerIds")]
    public IEnumerable<string>? CustomerIds { get; set; }

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
