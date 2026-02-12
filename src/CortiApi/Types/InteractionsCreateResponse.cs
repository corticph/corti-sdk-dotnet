using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record InteractionsCreateResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier for the interaction.
    /// </summary>
    [JsonPropertyName("interactionId")]
    public required string InteractionId { get; set; }

    /// <summary>
    /// WebSocket URL for streaming real-time interactions. Append a token in the format: /interactions/{interactionID}/streams?token=Bearer token-value-here
    /// </summary>
    [JsonPropertyName("websocketUrl")]
    public required string WebsocketUrl { get; set; }

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
