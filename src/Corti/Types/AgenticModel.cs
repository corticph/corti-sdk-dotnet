using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// An LLM model available on the gateway.
/// </summary>
[Serializable]
public record AgenticModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Model identifier, usable as the `model` field on agent create/update.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Unix timestamp (seconds) when the model was created.
    /// </summary>
    [JsonPropertyName("created")]
    public long? Created { get; set; }

    /// <summary>
    /// Owner of the model.
    /// </summary>
    [JsonPropertyName("ownedBy")]
    public string? OwnedBy { get; set; }

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
