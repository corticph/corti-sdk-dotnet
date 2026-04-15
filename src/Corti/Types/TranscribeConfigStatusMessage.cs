using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record TranscribeConfigStatusMessage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Configuration status result
    /// </summary>
    [JsonPropertyName("type")]
    public required TranscribeConfigStatusMessageType Type { get; set; }

    /// <summary>
    /// Optional reason for rejection
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    /// <summary>
    /// Session identifier returned when configuration is accepted
    /// </summary>
    [JsonPropertyName("sessionId")]
    public required string SessionId { get; set; }

    /// <summary>
    /// The resolved configuration, returned when configuration is accepted
    /// </summary>
    [JsonPropertyName("configuration")]
    public TranscribeConfig? Configuration { get; set; }

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
