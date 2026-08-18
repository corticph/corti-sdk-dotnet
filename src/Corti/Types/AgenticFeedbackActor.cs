using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Customer-defined opaque identifier for the feedback submitter.
/// </summary>
[Serializable]
public record AgenticFeedbackActor : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Scoped to the authenticated customer; not globally unique and not
    /// independently verified. Should preferably be pseudonymous and must
    /// not contain names, emails, national identifiers, or medical record
    /// numbers.
    /// </summary>
    [JsonPropertyName("externalId")]
    public required string ExternalId { get; set; }

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
