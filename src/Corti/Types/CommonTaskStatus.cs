using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// A task's current state, with an optional status message and timestamp.
/// </summary>
[Serializable]
public record CommonTaskStatus : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("state")]
    public required CommonTaskState State { get; set; }

    [JsonPropertyName("message")]
    public CommonMessage? Message { get; set; }

    /// <summary>
    /// When the status was last updated.
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
