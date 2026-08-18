using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Customer-provided provenance and correlation information.
/// </summary>
[Serializable]
public record AgenticFeedbackMetadata : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// How the customer collected the feedback. Informational only; does not affect rating validation or normalization.
    /// </summary>
    [JsonPropertyName("collectionMethod")]
    public string? CollectionMethod { get; set; }

    /// <summary>
    /// Customer-defined reference to correlate the feedback with an object
    /// in the customer's own system. Not unique and does not provide
    /// idempotency. Should not contain sensitive information.
    /// </summary>
    [JsonPropertyName("clientReference")]
    public string? ClientReference { get; set; }

    [JsonPropertyName("actor")]
    public AgenticFeedbackActor? Actor { get; set; }

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
