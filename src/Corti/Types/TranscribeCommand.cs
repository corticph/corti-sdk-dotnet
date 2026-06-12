using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

[Serializable]
public record TranscribeCommand : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique value to identify the command when it is detected and returned over the WebSocket
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// One or more word sequence(s) that can be spoken to trigger the command. At least one phrase is required per command.
    /// </summary>
    [JsonPropertyName("phrases")]
    public IEnumerable<string> Phrases { get; set; } = new List<string>();

    /// <summary>
    /// Placeholders that can (optionally) be added in phrases to provide flexibility and extensibility for triggering commands.
    /// </summary>
    [JsonPropertyName("variables")]
    public IEnumerable<TranscribeCommandVariable>? Variables { get; set; }

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
