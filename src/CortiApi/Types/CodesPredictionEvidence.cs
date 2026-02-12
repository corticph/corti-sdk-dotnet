using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

/// <summary>
/// Evidence span supporting a predicted code, linked to the input context.
/// </summary>
[Serializable]
public record CodesPredictionEvidence : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Index from the request `context` array where this evidence was found.
    /// </summary>
    [JsonPropertyName("contextIndex")]
    public required int ContextIndex { get; set; }

    /// <summary>
    /// Extracted text snippet supporting the prediction.
    /// </summary>
    [JsonPropertyName("text")]
    public required string Text { get; set; }

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
