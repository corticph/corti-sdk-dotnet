using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record StreamConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("transcription")]
    public required StreamConfigTranscription Transcription { get; set; }

    [JsonPropertyName("mode")]
    public required StreamConfigMode Mode { get; set; }

    /// <summary>
    /// Optional parameter to specify data retention policy for the generated transcripts and facts. Use value 'none' to indicate data should not be stored in the database. Use value 'retain' to indicate that the data should be retained according to standard retention policies. If configuration is not provided, then the default retention policy will apply.
    /// </summary>
    [JsonPropertyName("X-Corti-Retention-Policy")]
    public StreamConfigXCortiRetentionPolicy? XCortiRetentionPolicy { get; set; }

    /// <summary>
    /// The audio format of the incoming audio stream
    /// </summary>
    [JsonPropertyName("audioFormat")]
    public string? AudioFormat { get; set; }

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
