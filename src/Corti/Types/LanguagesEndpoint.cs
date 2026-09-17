using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

[Serializable]
public record LanguagesEndpoint : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Streams endpoint with its supported attributes.
    /// </summary>
    [JsonPropertyName("streams")]
    public required LanguagesEndpointAttributes Streams { get; set; }

    /// <summary>
    /// Transcribe endpoint with its supported attributes.
    /// </summary>
    [JsonPropertyName("transcribe")]
    public required LanguagesEndpointAttributes Transcribe { get; set; }

    /// <summary>
    /// Transcripts endpoint with its supported attributes.
    /// </summary>
    [JsonPropertyName("transcripts")]
    public required LanguagesEndpointAttributes Transcripts { get; set; }

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
