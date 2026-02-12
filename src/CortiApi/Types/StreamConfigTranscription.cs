using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record StreamConfigTranscription : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Primary spoken language for transcription
    /// </summary>
    [JsonPropertyName("primaryLanguage")]
    public required string PrimaryLanguage { get; set; }

    /// <summary>
    /// Enable speaker diarization
    /// </summary>
    [JsonPropertyName("isDiarization")]
    public bool? IsDiarization { get; set; }

    /// <summary>
    /// Enable multi-channel audio processing
    /// </summary>
    [JsonPropertyName("isMultichannel")]
    public bool? IsMultichannel { get; set; }

    /// <summary>
    /// List of participants with roles assigned to a channel
    /// </summary>
    [JsonPropertyName("participants")]
    public IEnumerable<StreamConfigParticipant> Participants { get; set; } =
        new List<StreamConfigParticipant>();

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
