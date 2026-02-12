using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record MentionData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Character range for document type.
    /// </summary>
    [JsonPropertyName("range")]
    public IEnumerable<int>? Range { get; set; }

    /// <summary>
    /// Time range in seconds for transcript type.
    /// </summary>
    [JsonPropertyName("time")]
    public IEnumerable<int>? Time { get; set; }

    /// <summary>
    /// Text snippet for the mention.
    /// </summary>
    [JsonPropertyName("snippet")]
    public string? Snippet { get; set; }

    /// <summary>
    /// The document ID if applicable.
    /// </summary>
    [JsonPropertyName("documentId")]
    public string? DocumentId { get; set; }

    /// <summary>
    /// The utterance ID if applicable.
    /// </summary>
    [JsonPropertyName("utteranceId")]
    public string? UtteranceId { get; set; }

    /// <summary>
    /// The timestamp for transcript mentions.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public DateTime? Timestamp { get; set; }

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
