using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record FactsUpdateResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The unique identifier of the fact.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The updated text content of the fact.
    /// </summary>
    [JsonPropertyName("text")]
    public required string Text { get; set; }

    /// <summary>
    /// The updated group key to which the fact belongs.
    /// </summary>
    [JsonPropertyName("group")]
    public required string Group { get; set; }

    /// <summary>
    /// The unique identifier of the associated group.
    /// </summary>
    [JsonPropertyName("groupId")]
    public required string GroupId { get; set; }

    /// <summary>
    /// The updated origin of the fact.
    /// </summary>
    [JsonPropertyName("source")]
    public required CommonSourceEnum Source { get; set; }

    /// <summary>
    /// Indicates whether the fact is marked as discarded.
    /// </summary>
    [JsonPropertyName("isDiscarded")]
    public required bool IsDiscarded { get; set; }

    /// <summary>
    /// The original timestamp when the fact was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The timestamp when the fact was last updated.
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public required DateTime UpdatedAt { get; set; }

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
