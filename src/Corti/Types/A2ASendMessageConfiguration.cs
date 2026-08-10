using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Per-request options controlling how a message is processed.
/// </summary>
[Serializable]
public record A2ASendMessageConfiguration : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// If `true`, return as soon as the task is submitted, even if processing is still in progress. If `false` (default), wait until the task reaches a terminal (`COMPLETED`, `FAILED`, `CANCELED`, `REJECTED`) or interrupted (`INPUT_REQUIRED`, `AUTH_REQUIRED`) state.
    /// </summary>
    [JsonPropertyName("returnImmediately")]
    public bool? ReturnImmediately { get; set; }

    /// <summary>
    /// Maximum number of prior messages to include as context.
    /// </summary>
    [JsonPropertyName("historyLength")]
    public int? HistoryLength { get; set; }

    /// <summary>
    /// Output media types the caller accepts.
    /// </summary>
    [JsonPropertyName("acceptedOutputModes")]
    public IEnumerable<string>? AcceptedOutputModes { get; set; }

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
