using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// A single Server-Sent Event frame (W3C SSE wire format). The server currently writes only `id` and `data` lines; `event` and `retry` are declared for forward compatibility but not sent.
/// </summary>
[Serializable]
public record A2AsseEvent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// SSE payload (JSON-encoded).
    /// </summary>
    [JsonPropertyName("data")]
    public required string Data { get; set; }

    /// <summary>
    /// Event type. Absent for the default `message` event.
    /// </summary>
    [JsonPropertyName("event")]
    public string? Event { get; set; }

    /// <summary>
    /// Opaque event id. Clients echo the most recent value in the
    /// `Last-Event-ID` header to resume a dropped stream.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Reconnection time in milliseconds the client should use.
    /// </summary>
    [JsonPropertyName("retry")]
    public int? Retry { get; set; }

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
