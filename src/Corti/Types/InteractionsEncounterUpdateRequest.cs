using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record InteractionsEncounterUpdateRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A unique identifier for the encounter, essential for tracking and referencing specific patient interactions.
    /// </summary>
    [JsonPropertyName("identifier")]
    public string? Identifier { get; set; }

    /// <summary>
    /// Indicates the current state of the encounter, crucial for understanding the progression and current state of care.
    /// </summary>
    [JsonPropertyName("status")]
    public InteractionsEncounterStatusEnum? Status { get; set; }

    /// <summary>
    /// The specific type of encounter, providing context about the nature and setting of the patient interaction.
    /// </summary>
    [JsonPropertyName("type")]
    public InteractionsEncounterTypeEnum? Type { get; set; }

    /// <summary>
    /// The time period during which the encounter takes place.
    /// </summary>
    [JsonPropertyName("period")]
    public InteractionsEncounterPeriod? Period { get; set; }

    /// <summary>
    /// A readable name for the interaction
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

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
