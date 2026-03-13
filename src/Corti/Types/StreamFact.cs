using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record StreamFact : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier for the fact
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Text description of the fact
    /// </summary>
    [JsonPropertyName("text")]
    public required string Text { get; set; }

    /// <summary>
    /// Categorization of the fact (e.g., medical-history)
    /// </summary>
    [JsonPropertyName("group")]
    public required string Group { get; set; }

    /// <summary>
    /// Unique identifier for the group
    /// </summary>
    [JsonPropertyName("groupId")]
    public required string GroupId { get; set; }

    /// <summary>
    /// Indicates if the fact was discarded
    /// </summary>
    [JsonPropertyName("isDiscarded")]
    public required bool IsDiscarded { get; set; }

    /// <summary>
    /// Source of the fact (e.g., core for generated automatically)
    /// </summary>
    [JsonPropertyName("source")]
    public required string Source { get; set; }

    /// <summary>
    /// Timestamp when the fact was created
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// Timestamp when the fact was last updated
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Timezone offset for createdAt timestamp
    /// </summary>
    [JsonPropertyName("createdAtTzOffset")]
    public DateTime? CreatedAtTzOffset { get; set; }

    /// <summary>
    /// Timezone offset for updatedAt timestamp
    /// </summary>
    [JsonPropertyName("updatedAtTzOffset")]
    public DateTime? UpdatedAtTzOffset { get; set; }

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
